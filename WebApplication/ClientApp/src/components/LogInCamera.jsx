import React, { Component } from "react";
import Webcam from "react-webcam";
import axios from "axios";
import "./RegistrationCamera.css";
import {
    HttpRequestPath
} from "./Constants.jsx";

export class LogInCamera extends Component {
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
                console.log(response);
            });



    };

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
                    <button onClick={this.capture}>Log in</button>
                </center>
            </div>
        );
    }
}
