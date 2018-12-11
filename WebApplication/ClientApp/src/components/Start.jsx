import React, { Component } from "react";
import "./Home.css";
import { Link } from "react-router-dom";
import logo from "./logo.png";
import LocalizedStrings from 'react-localization';
import { setLanguage } from "./AuthService";

let strings = new LocalizedStrings({
    en: {
        welcome: "Welcome!",
        login: "Login",
        notInMood: "Not in the mood for camera?",
        loginNoCamera: "Login without camera",
        noAccount: "Don't have an account?",
        signUp: "Sign up now!",
    },
    lt: {
        welcome: "Sveiki!",
        login: "Prisijungti",
        notInMood: "Neturite nuotaikos žiūrėti į kamerą?",
        loginNoCamera: "Prisijungti be kameros",
        noAccount: "Neturite paskyros?",
        signUp: "Prisiregistruokite dabar!",

    }
});


export class Start extends Component {
    _onSetLanguageTo(lang) {
        strings.setLanguage(lang);
        this.setState({});
        setLanguage(lang);
    }
  render() {
    return (
      <div className="box">
            <img className="logo" src={logo} height="140" width="120" />
            <h2 className="belowLogo">{strings.welcome}</h2>
            <button className="btn btn-secondary btn-lg active" role="button"
                onClick={() => this._onSetLanguageTo('lt')}>lt
                </button>
            <button className= "btn btn-secondary btn-lg active" role = "button"
                onClick={() => this._onSetLanguageTo('en')}>en
                </button>
        <div className="ui padded segment">
          <Link to={"/signIn/camera"}>
          <button className="ui fluid primary large button" role="button">
          {strings.login}
          </button>
                </Link>
                <div className="ui horizontal divider">{strings.notInMood}</div>
          <Link to={"/signIn"}>
          <button className="ui fluid secondary large button" role="button">
          {strings.loginNoCamera}
          </button>
          </Link>
            </div>
            <p className="spacing">{strings.noAccount}
        </p>
            <Link to={"/registration"}>
                <p className="signUpLink"> {strings.signUp}</p>
        </Link>
      </div>
    );
  }
}
