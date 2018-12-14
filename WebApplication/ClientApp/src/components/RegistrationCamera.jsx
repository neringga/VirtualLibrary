import React, { Component } from "react";
import Webcam from "react-webcam";
import axios from "axios";
import "./RegistrationCamera.css";
import { HttpRequestPath } from "./Constants.jsx";
import { Button } from "semantic-ui-react";
import LocalizedStrings from "react-localization";
import { getLanguage } from "./LangService";

//Get constants from .config
const imagesPerPerson = 5;
const maxUserError = 2;
const maxServerError = 2;
const timeBetweenTakingPictures = 1000;
const timeBetweenSavingPictures = 250;

var saveRequestsMade = 0;
var saveErrorHappened = false;
var photosSent = 0;

let strings = new LocalizedStrings({
  en: {
    capture: "Capture photo",
    save: "Save and finish Registration",
    cancel: "Cancel Face recognition"
  },
  lt: {
    capture: "Padaryti nuotrauką",
    save: "Išsaugoti ir užbaigti registraciją",
    cancel: "Atšaukti veido atpažinimą"
  }
});

export class RegistrationCamera extends Component {
  constructor(props) {
    super(props);
    this.state = {
      photos: null,
      successes: 0,
      userError: 0,
      serverError: 0
    };
    window.onload = function() {
      document.getElementById("saveAndContinueButton").disabled = true;
    };
  }

  setRef = webcam => {
    this.webcam = webcam;
  };

  capture = () => {
    this.lockButtons();

    this.reset();

    var stopFuction = function() {
      if (
        this.state.userError > maxUserError ||
        this.state.serverError > maxServerError ||
        this.state.successes == imagesPerPerson
      ) {
        clearInterval(interval);
        clearInterval(self);
      }
    };

    var interval = setInterval(
      this.takePhoto.bind(this),
      timeBetweenTakingPictures
    );

    var self = setInterval(
      stopFuction.bind(this),
      timeBetweenTakingPictures - 100
    );
  };

  takePhoto() {
    let screenshot = this.webcam.getScreenshot();
    var data = screenshot.replace(/^data:image\/\w+;base64,/, "");
    var buf = new Buffer(data, "base64");

    axios
      .post(HttpRequestPath + "api/FaceDetection", buf, {
        headers: {
          "Content-Type": "application/json"
        }
      })
      .then(response => {
        /*  response.data  -->  buffer with base64 gray 100x100 user face image
                    response.data == false  -->  Face not detected (user error) (bad lighting, no face and etc.)
                    response.data == null  -->  Exception happened (server error) (exception of some kind)          */

        if (response.data != null && response.data != false) {
          this.state.photos[this.state.successes] = response.data;
          this.savePhotos.bind(this);
          this.state.successes += 1;
          if (this.state.successes == imagesPerPerson) {
            this.success();
            this.unlockButtons();
          }
        }
        if (response.data == false) {
          this.state.userError += 1;
          if (this.state.userError > maxUserError) {
            console.log("user fault"); //temp
            this.unlockButtons();
            //Inform user about problem on his end, give suggestions
          }
        }
        if (response.data == null) {
          this.state.serverError += 1;
          if (this.state.serverError > maxServerError) {
            console.log("server fault"); //temp
            this.unlockButtons();
            //Inform user about problem in server
          }
        }
      });
  }

  lockButtons() {
    document.getElementById("captureButton").disabled = true;
    document.getElementById("saveAndContinueButton").disabled = true;
  }

  unlockButtons() {
    document.getElementById("captureButton").disabled = false;
    document.getElementById("saveAndContinueButton").disabled = false;
  }

  reset() {
    this.state.photos = [];
    this.state.serverError = 0;
    this.state.userError = 0;
    this.state.successes = 0;
  }

  savePhoto() {
    this.lockButtons();

    const data = {
      Bytes: this.state.photos[photosSent],
      Nickname: localStorage.getItem("Nickname")
    };
    photosSent++;

    axios.put(HttpRequestPath + "api/ImageSaving", data).then(response => {
      saveRequestsMade++;
      if (response.data === null) {
        saveErrorHappened = true;
      }
      if (saveRequestsMade == imagesPerPerson) {
        if (saveErrorHappened == true) {
          console.log("Server saving error");
          this.unlockButtons();
          //Inform user about problem in server
        } else {
          window.location = "/";
          //Inform user about successful save
        }
      }
      console.log(response);
    });
  }

  savePhotos() {
    saveRequestsMade = 0;
    saveErrorHappened = false;
    photosSent = 0;

    for (var i = 0; i < imagesPerPerson; i++) {
      setTimeout(this.savePhoto.bind(this), i * timeBetweenSavingPictures);
    }
  }

  OnLoad = () => {
    document.getElementById("saveAndContinueButton").disabled = true;
  };

  _onSetLanguageTo(lang) {
    strings.setLanguage(lang);
  }

  render() {
    const lang = getLanguage();

    const videoConstraints = {
      width: 800,
      height: 500,
      facingMode: "user"
    };

    return (
      this._onSetLanguageTo(lang),
      (
        <div className="container">
          <center>
            <Webcam
              className="center"
              audio={false}
              ref={this.setRef}
              screenshotFormat="image/jpeg"
              videoConstraints={videoConstraints}
            />
          </center>
          <center>
          <Button primary size="big" id="captureButton" onClick={this.capture}>{strings.capture}</Button>
          </center>
          <center>
          <Button primary size="big" id="saveAndContinueButton" onClick={this.savePhotos.bind(this)}>{strings.save}</Button>
          </center>
        </div>
      )
    );
  }
}
