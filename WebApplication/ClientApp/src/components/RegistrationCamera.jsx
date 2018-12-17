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
      serverError: 0,
      capture: true,
      loading: false,
      save: false,
    };

  }

  setRef = webcam => {
    this.webcam = webcam;
  };

  capture = () => {
    this.setState({
      loading: true,
      capture: false,
    })

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
            this.setState({
              save: true,
              loading: false,
            })
          }
        }
        if (response.data == false) {
          this.state.userError += 1;
          if (this.state.userError > maxUserError) {
            console.log("user fault"); //temp
            //Inform user about problem on his end, give suggestions
          }
        }
        if (response.data == null) {
          this.state.serverError += 1;
          if (this.state.serverError > maxServerError) {
            console.log("server fault"); //temp
            //Inform user about problem in server
          }
        }
      });
  }


  reset() {
    this.state.photos = [];
    this.state.serverError = 0;
    this.state.userError = 0;
    this.state.successes = 0;
  }

  savePhoto() {

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
          //Inform user about problem in server
        } else {
          this.props.history.push("/");
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

  showCapture = capture => {
    if (capture) {
      return (
        <Button primary size="big" id="captureButton" onClick={this.capture}>
          {strings.capture}
        </Button>
      );
    } else return null;
  };

  showLoading = loading => {
    if (loading) {
      return (
        <Button loading primary>
          Loading
        </Button>
      );
    } else return null;
  };

  showSave = save => {
    if (save) {
      return (
        <Button
              primary
              size="big"
              id="saveAndContinueButton"
              onClick={this.savePhotos.bind(this)}
            >
              {strings.save}
            </Button>
      );
    } else return null;
  };

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
        <h3>Let us figure out who you are</h3>
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
            {this.showCapture(this.state.capture)}
            {this.showLoading(this.state.loading)}
            {this.showSave(this.state.save)}
          </center>
        </div>
      )
    );
  }
}
