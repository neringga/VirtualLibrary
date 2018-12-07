import React, { Component } from "react";
import axios from "axios";
import "./SigningIn.css";
import './Home.css';
import { setToken } from "./AuthService";
import { Form, Message, Button } from "semantic-ui-react";
import logo from "./logo.png";

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
      password: "",
      badCredentials: false,
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
        .catch(err => {
          this.setState({badCredentials: true})
        });
    }
  };

  render() {
    return (
      <div className="boxSignin">
      <center><img className="logoSignIn" src={logo} height="140" width="120" /></center>
        <h3>Sign In</h3>
        {this.state.badCredentials ? (
              <Message error header="Try again!" list={["Username or password not valid"]} />
            ) : null}
      <div className="sigginForm">
      <Form size="big">
      <Form.Field>
              <label>Username</label>
              <input
                name="username"
                placeholder="Username"
                onChange={this.handleInputChange}
              />
            </Form.Field>
            <Form.Field>
              <label>Password</label>
              <input
                name="password"
                placeholder="Password"
                type="Password"
                onChange={this.handleInputChange}
              />
            </Form.Field>
            <center>
                <Button onClick={this.handleSubmit} size="large" primary>
                  Submit
                </Button>
              </center>
      </Form>
      </div>
      </div>
      // <form>
      //   <div className="form-group">
      //     <label>Username</label>
      //     <input
      //       type="username"
      //       name="username"
      //       className="form-control"
      //       placeholder="Username"
      //       onChange={this.handleInputChange}
      //     />
      //   </div>
      //   <div>
      //     <label>Password</label>
      //     <input
      //       className="form-control"
      //       name="password"
      //       placeholder="Password"
      //       type="Password"
      //       onChange={this.handleInputChange}
      //     />
      //   </div>
      //   <div>
      //     <button className="btn btn-primary" onClick={this.handleSubmit}>
      //       Sign In
      //     </button>
      //   </div>
      // </form>
    );
  }
}
