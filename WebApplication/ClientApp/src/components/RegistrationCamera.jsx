import React, { Component } from 'react';
import Webcam from 'react-webcam';
import axios from "axios"
import "./RegistrationCamera.css";
import {
    successfullSignIn,
    faceDetectionApi,
    userSignInApi,
    HttpRequestPath
} from "./Constants.jsx";

export class RegistrationCamera extends Component {

  constructor(props) {
    super(props);
    this.state = {
        base64image: null
    };
  }

    setRef = webcam => {
        this.webcam = webcam;
    };

    capture = () => {
        //this.setState({base64image: this.webcam.getScreenshot()}); 
        const jsonUrl = JSON.stringify(this.webcam.getScreenshot());
        console.log(jsonUrl);
        axios
            .post(HttpRequestPath + '/api/FaceDetection', this.webcam.getScreenshot())
            .then (response => {
                console.log(response);
            });
    };
    
    handleRecognision() {
        axios
            .post(HttpRequestPath + 'api/FaceDetection')
            .then (response => {

            });
    }
    

  render() {

      const videoConstraints = {
      width: 1980,
      height: 1080,
      facingMode: "user"
      };

    return (
        <div className="container">
            <center>
            <Webcam className = "center"
                audio={false}
                ref={this.setRef}
                screenshotFormat="image/jpeg"
                videoConstraints={videoConstraints}
                    /></center>
                <center>
                <button onClick={this.capture}>Capture photo</button>
                </center>
        </div>
    );
  }
}