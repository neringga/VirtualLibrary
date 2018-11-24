import React, { Component } from "react";
import "./Home.css";
import { Link } from "react-router-dom";
import logo from "./logo.png";

export class Start extends Component {
  render() {
    return (
      <div className="box">
        <img className="logo" src={logo} height="140" width="120" />
        <h2 className="belowLogo">Welcome</h2>
        <div className="ui padded segment">
        <Link to={"/signIn"}>
          <button className="ui fluid primary large button" role="button">
            Login
          </button>
          </Link>
          <div className="ui horizontal divider">Not in the mood for camera?</div>
          <Link to={"/registration"}>
          <button className="ui fluid secondary large button" role="button">
            Login without camera
          </button>
          </Link>
        </div>
        <p className="spacing">Don't have an account?
        </p>
        <Link to={"/registration"}>
        <p className="signUpLink"> Sign up now! </p>
        </Link>
      </div>
    );
  }
}
