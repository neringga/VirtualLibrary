import React, { Component } from "react";
import axios from "axios";
import "./Registration.css";
import { FormGroup, FormControl } from "react-bootstrap";
import {
  HttpRequestPath,
  userRegistrationApi,
  emailRegex,
  emailErr,
  successfullRegistration,
  usernameErr,
  passordNotMatchErr,
  emailRegexErr,
  usernameShortErr,
} from "./Constants.jsx";
import { Link } from "react-router-dom";
import "./Home.css";
import { Progress, Form, Label, Button, Message } from "semantic-ui-react";

export class Registration extends Component {
  constructor(props) {
    super(props);
    this.state = {
      emailErr: null,
      passRepErr: null,
      notFilledErr: false,
      emailRegisteredErr: null,
      usernameRegisteredErr: null,
      notFilledFieldsErr: null
    };
  }

  handleInputChange = event => {
    event.preventDefault();
    console.log(event.target.name);
    this.setState({
      [event.target.name]: event.target.value
    });
  };

  handleEmailChange = event => {
    event.preventDefault();
    this.setState({
      email: event.target.value
    });
    if (!event.target.value.match(emailRegex)) {
      this.setState({ emailErr: true });
      return false;
    }
    this.setState({ emailErr: false });
    return true;
  };

  handlePasswordChange = event => {
    event.preventDefault();
    this.setState({
      repPassword: event.target.value
    });
    console.log(this.state.password + " " + event.target.value);
    if (this.state.password !== event.target.value) {
      this.setState({ passRepErr: true });
      return false;
    }
    this.setState({ passRepErr: false });
    return true;
  };
  checkInput = () => {
    //TODO check not null picture
    if (this.state.username == null) {
      return false;
    }
    if (this.state.password == null) {
      return false;
    }
    if (this.state.firstName == null) {
      return false;
    }
    if (this.state.lastName == null) {
      return false;
    }
    if (this.state.repPassword == null) {
      return false;
    }
    return true;
  };

  handleSubmit = event => {
    event.preventDefault();
    if (this.checkInput()) {
      this.setState({ notFilledErr: false, emailRegisteredErr: null, usernameRegisteredErr:null});
      const data = {
        username: this.state.username,
        firstName: this.state.firstName,
        lastName: this.state.lastName,
        email: this.state.email,
        password: this.state.password
      };
      axios.put(HttpRequestPath + userRegistrationApi, data).then(response => {
        if (response.data == emailErr) {
          this.setState({notFilledErr: true, emailRegisteredErr: "This email is already registered"});
        } else if (response.data == usernameErr) {
          this.setState({notFilledErr: true, usernameRegisteredErr: "This username is already registered"});
        } else if (response.data) {
          window.location = '/SignIn';
        }
      });this.setState({ validInput: true });
    } else {
      this.setState({ notFilledErr: true, notFilledFieldsErr: "Not all fields have been fild"});
    }
  };

  render() {
    return (
      <div className="boxRegistration">
        <h3>Register</h3>
        {this.state.notFilledErr ? (
              <Message error header="Try again!" list={[this.state.notFilledFieldsErr,
              this.state.usernameRegisteredErr, this.state.emailRegisteredErr]} />
            ) : null}
        <div className="regForm">
          <Form size="big">
            <Form.Field required>
              <label>Username</label>
              <input
                name="username"
                placeholder="Username"
                onChange={this.handleInputChange}
              />
            </Form.Field>
            <Form.Group widths="equal">
              <Form.Input
                required
                fluid
                name="firstName"
                label="First name"
                placeholder="First name"
                onChange={this.handleInputChange}
              />
              <Form.Input
                required
                fluid
                name="lastName"
                label="Last name"
                placeholder="Last name"
                onChange={this.handleInputChange}
              />
            </Form.Group>
            <Form.Field required>
              <label>Email</label>
              <input
                placeholder="Email"
                name="email"
                onChange={this.handleEmailChange}
              />
              {this.state.emailErr ? (
                <Label basic color="red" pointing active>
                  Invalid email
                </Label>
              ) : null}
            </Form.Field>
            <Form.Input
              required
              label="Password"
              placeholder="Password"
              name="password"
              type="password"
              onChange={this.handleInputChange}
            />
            <Form.Input
              required
              label="Repeat Password"
              placeholder="Password"
              name="repPassword"
              type="password"
              onChange={this.handlePasswordChange}
            />
            {this.state.passRepErr ? (
              <Label basic color="red" pointing active>
                Passwords do not match
              </Label>
            ) : null}
            <br />
            <Button
              content="Take a picture"
              icon="camera"
              labelPosition="left"
            />
            <br />
            <div className="regButton">
              <center>
                <Button onClick={this.handleSubmit} size="large" primary>
                  Submit
                </Button>
              </center>
            </div>
          </Form>
        </div>
      </div>
    );
  }
}
