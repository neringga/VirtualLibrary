import React, { Component } from "react";
import axios from "axios";
import "./Registration.css";
import {
  HttpRequestPath,
  userRegistrationApi,
  emailRegex,
  emailErr,
  emailRegisteredErr,
  successfullRegistration,
  usernameErr,
  passordNotMatchErr,
  emailRegexErr,
  usernameShortErr,
  usernameRegisteredErr
} from "./Constants.jsx";
import { Link } from "react-router-dom";

export class Registration extends Component {
  constructor(props) {
    super(props);
    this.state = {
      username: "",
      firstName: "",
      lastName: "",
      email: "",
      password: "",
      repPassword: "",
      validInput: false
    };
  }

  handleInputChange = event => {
    event.preventDefault();
    this.setState({
      [event.target.name]: event.target.value
    });
  };

  checkInput = event => {
    if (this.state.username == null ) {
      alert(usernameShortErr);
      return false;
    }
    if (
      this.state.password == null ||
      this.state.password != this.state.repPassword
    ) {
      alert(passordNotMatchErr);
      return false;
    }
    if (this.state.email == null || !this.state.email.match(emailRegex)) {
      alert(emailRegexErr);
      return false;
    }

    return true;
  };

  handleSubmit = event => {
    event.preventDefault();
    if (this.checkInput()) {
      const data = this.state;
      axios.put(HttpRequestPath + userRegistrationApi, data).then(response => {
		  if (response.data) {
			  console.log(response.data)
          alert(successfullRegistration);
        } else if (response.data == emailErr) {
          alert(emailRegisteredErr);
        } else if (response.data == usernameErr) {
          alert(usernameRegisteredErr);
        } else if (response.data) {
          alert(successfullRegistration);
        }
      });
    }
    this.setState({ validInput: true });
  };

  render() {
    const validInput = this.state.validInput;
    let button;
    if (validInput) {
      button = <Link to={'/HomePage'}><button type="submit" className="btn btn-primary">Submit</button></Link>
    }
    else {
      button = <button type="submit" className="btn btn-primary">Submit</button>
    }
    return (
      <div className="container">
        <div className="scrollableBox" overflow-y="scroll">
          <form onSubmit={this.handleSubmit}>
            <div className="form-group">
              <label>Username</label>
              <input
                type="username"
                className="form-control"
                placeholder="Username"
                onChange={this.handleInputChange}
              />
            </div>
            <div className="form-group">
              <label>First name</label>
              <input
                className="form-control"
                name="firstName"
                placeholder="First name"
                onChange={this.handleInputChange}
              />
            </div>
            <div className="form-group">
              <label>Last name</label>
              <input
                className="form-control"
                name="lastName"
                placeholder="Last name"
                onChange={this.handleInputChange}
              />
            </div>
            <div className="form-group">
              <label>Email</label>
              <input
                className="form-control"
                name="email"
                placeholder="Email"
                onChange={this.handleInputChange}
              />
              <small id="emailHelp" class="form-text text-muted">
                We'll never share your email with anyone else.
              </small>
            </div>
            <div className="form-group">
              <label>Password</label>
              <input
                className="form-control"
                name="password"
                placeholder="Password"
                type="Password"
                onChange={this.handleInputChange}
              />
            </div>
            <div className="form-group">
              <label>Repeat password</label>
              <input
                className="form-control"
                name="repPassword"
                type="Password"
                onChange={this.handleInputChange}
              />
            </div>
            <div className="form-group">
            <Link to={"/registration/camera"}>
            <button type="button" class="btn btn-secondary">Take a picture</button>
            </Link>
            </div>
            <div className="form-group">

            <button type="submit" className="btn btn-primary">Submit</button>

            </div>
          </form>
        </div>
      </div>
    );
  }
}
