import React, { Component } from "react";
import axios from "axios";
import "./SigningIn.css";
import { setToken } from "./AuthService";
import {
  noUsername,
  noPassword,
  userSignInApi,
  successfullSignIn,
  noUser,
  HttpRequestPath
} from "./Constants.jsx";

export class SigningIn extends Component {
  constructor(props) {
    super(props);
    this.state = {
      username: "",
      password: ""
    };
  }

  handleInputChange = event => {
    event.preventDefault();
    this.setState({
      [event.target.name]: event.target.value
    });
  };

  checkInput = event => {
    if (this.state.username === null) {
      alert(noUsername);
      return false;
    }
    if (this.state.password === null) {
      alert(noPassword);
      return false;
    }
    return true;
  };

  handleSubmit = event => {
    event.preventDefault();
    if (this.checkInput()) {
      const data = {
        username: this.state.username,
        password: this.state.password
      };
      axios
        .put(HttpRequestPath + "/api/UserSignIn", data)
        .then(res => {
          setToken(res.data);
          window.location = "/homePage";
        })
        .catch(err => alert("Invalid username or password"));
    }
  };

  render() {
    return (
      <form>
        <div className="form-group">
          <label>Username</label>
          <input
            type="username"
            name="username"
            className="form-control"
            placeholder="Username"
            onChange={this.handleInputChange}
          />
        </div>
        <div>
          <label>Password</label>
          <input
            className="form-control"
            name="password"
            placeholder="Password"
            type="Password"
            onChange={this.handleInputChange}
          />
        </div>
        <div>
          <button className="btn btn-primary" onClick={this.handleSubmit}>
            Sign In
          </button>
        </div>
      </form>
    );
  }
}
