import React, { Component } from "react";
import Webcam from "react-webcam";
import axios from "axios";
import { setToken } from "./AuthService";
import "./RegistrationCamera.css";
import {
    HttpRequestPath
} from "./Constants.jsx";


import LocalizedStrings from 'react-localization';
import { getLanguage } from "./LangService";

let strings = new LocalizedStrings({
    en: {
        login: "Log in"
    },
    lt: {
        login: "Prisijungti"
    },

});

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
                setToken(response.data);
                window.location = "/homePage";
            })
            .catch(err => {
                alert("User not recognized");
            });



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
                    <button onClick={this.capture}>{strings.login}</button>
                </center>
            </div>
        );
    }
}
