import React, { Component } from "react";
import Webcam from "react-webcam";
import axios from "axios";
import { setToken } from "./AuthService";
import "./RegistrationCamera.css";
import "./Home.css";
import { HttpRequestPath } from "./Constants.jsx";
import { Button, Icon } from "semantic-ui-react";

export class LogInCamera extends Component {
  constructor(props) {
    super(props);
    this.state = {
      base64image: null,
      notFoundErr: null,
    };
  }

  setRef = webcam => {
    this.webcam = webcam;
  };

  capture = () => {
    let screenshot = this.webcam.getScreenshot();
    var data = screenshot.replace(/^data:image\/\w+;base64,/, "");
    var buf = new Buffer(data, "base64");
    axios
      .post(HttpRequestPath + "api/FaceRecognition", buf, {
        headers: {
          "Content-Type": "application/json"
        }
      })
      .then(response => { 
          if (response.data) {
            setToken(response.data);
            window.location = "/homePage";
          }
          else{
            window.location = "/SignIn";
          }
      })
    // }
  };


  onNotFoundErr = (err) => {
    if (err) {
        return (
            <div></div>
        )
    }
  }

  render() {
    const videoConstraints = {
      width: 750,
      height: 500,
      facingMode: "user"
    };

    return (
      <div>
          
            <h3 className="camTitle">Look at the camera, smile and press login</h3><center>
          <Webcam
            className="center"
            // className="webcam"
            audio={false}
            ref={this.setRef}
            screenshotFormat="image/jpeg"
            videoConstraints={videoConstraints}
          />
        
          <Button size="big" onClick={this.capture}icon labelPosition="right">
            Login
            <Icon name="right arrow" />
          </Button>
        </center>
      </div>
    );
  }
}
