import React, { Component } from 'react';
import Webcam from "react-webcam";
import "./RegistrationCamera.css";

export class RegistrationCamera extends Component {

  constructor(props) {
    super(props);
    
  }

    setRef = webcam => {
        this.webcam = webcam;
    };

    capture = () => {
        const imageSrc = this.webcam.getScreenshot();

    };


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