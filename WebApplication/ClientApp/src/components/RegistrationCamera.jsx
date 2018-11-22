import React, { Component } from "react";
import Webcam from "react-webcam";
import axios from "axios";
import fs from "browserify-fs";
import "./RegistrationCamera.css";
import {
  successfullSignIn,
  faceDetectionApi,
  userSignInApi,
  HttpRequestPath
} from "./Constants.jsx";

//Get constants from .config
const imagesPerPerson = 5;
const maxUserError = 2;
const maxServerError = 2;
const timeBetweenTakingPictures = 1000;

export class RegistrationCamera extends Component {
  constructor(props) {
    super(props);
    this.state = {
        photos: null,
        successes: 0,
        userError: 0,
        serverError: 0
      };
  }

  setRef = webcam => {
    this.webcam = webcam;
    };

    

    capture = () => {

        this.reset();
        this.state.photos = [];

        var stopFuction = function () {
            if (this.state.userError > maxUserError || this.state.serverError > maxServerError || this.state.successes == imagesPerPerson) {
                clearInterval(interval);
                clearInterval(self);
            }
        }

        var interval = setInterval(this.testPhoto.bind(this), timeBetweenTakingPictures);

        var self = setInterval(stopFuction.bind(this), timeBetweenTakingPictures - 100);
    };


    testPhoto() {

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
                    this.state.successes += 1;
                    if (this.state.successes == imagesPerPerson) {
                        this.success();
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


    success() {
        console.log("success"); //temp
        //display success
        //send this.state.photos to registration
    }


    reset() {
        this.state.photos = null;
        this.state.serverError = 0;
        this.state.userError = 0;
        this.state.successes = 0;
    }

    


  render() {
    const videoConstraints = {
      width: 800,
      height: 500,
      facingMode: "user"
    };

    return (
      <div className="container">
        <center>
          <Webcam
            className="center"
            width="340"
            height="340"
            audio={false}
            ref={this.setRef}
            screenshotFormat="image/jpeg"
            videoConstraints={videoConstraints}
          />
        </center>
        <center>
          <button onClick={this.capture}>Capture photo</button>
        </center>
      </div>
    );
  }
}
