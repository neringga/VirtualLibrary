import React, { Component } from "react";
import axios from "axios";
import "./Registration.css";
import { FormGroup, FormControl } from "react-bootstrap";
import { confirmAlert } from 'react-confirm-alert';
import 'react-confirm-alert/src/react-confirm-alert.css'
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

import LocalizedStrings from 'react-localization';
import { getLanguage } from "./LangService";

let strings = new LocalizedStrings({
    en: {
        emailRegistered: "This email is already registered",
        usernameRegistered: "This username is already registered",
        notAll: "Not all fields have been fild",
        faceRecognition: "Face Recognition",
        doYou: "Would you like to set up Face recognition ?",
        yes: "Yes",
        no: "No",
        register: "Register",
        tryAgain: "Try again!",
        username: "Username",
        firstName: "First name",
        lastName: "Last name",
        email: "Email",
        ivalidEmail: "Invalid email", 
        password: "Password",
        repeat: "Repeat password",
        doNotMatch: "Passwords do not match",
        submit: "Submit",
    },
    lt: {
        emailRegistered: "Jau egzistuoja vartotojas tokiu elektroniniu paštu",
        usernameRegistered: "Jau egzistuoja vartotojas tokiu prisijungimo vardu",
        notAll: "Yra tuščių laukų",
        faceRecognition: "Veido atpažinimas",
        doYou: "Ar norėtumėte naudoti veido atpažinimą?",
        yes: "Taip",
        no: "Ne",
        register: "Registracija",
        tryAgain: "Bandykite dar kartą!",
        username: "Prisijungimo vardas",
        firstName: "Vardas",
        lastName: "Pavardė",
        email: "Elektroninis paštas",
        ivalidEmail: "Netinkamas elektroninis paštas",
        password: "Slaptažodis",
        repeat: "Pakartokite slaptažodį",
        doNotMatch: "Slaptažodžiai nesutampa",
        submit: "Pateikti",
    },

});

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
            this.setState({ notFilledErr: true, emailRegisteredErr:  strings.emailRegistered  });
        } else if (response.data == usernameErr) {
          this.setState({notFilledErr: true, usernameRegisteredErr: strings.usernameRegistered});
        } else if (response.data) {
            this.faceRecognitionPrompt();
        }
      });this.setState({ validInput: true });
    } else {
      this.setState({ notFilledErr: true, notFilledFieldsErr: strings.notAll});
    }
    };


    faceRecognitionPrompt = () => {
        confirmAlert({
            title:  strings.faceRecognition ,
            message: strings.doYou,
            buttons: [
                {
                    label: strings.yes,
                    onClick: () => {
                        localStorage.setItem("Nickname", this.state.username);
                        window.location = '/registration/camera';
                    }
                },
                {
                    label: strings.no,
                    onClick: () => {
                        window.location = '/SignIn';
                    }
                }
            ]
        })
    };

    _onSetLanguageTo(lang) {
        strings.setLanguage(lang);
    }

    render() {
        const lang = getLanguage();
        return (
            this._onSetLanguageTo(lang),
      <div className="boxRegistration">
                <h3>{strings.register}</h3>
        {this.state.notFilledErr ? (
                    <Message error header={strings.tryAgain} list={[this.state.notFilledFieldsErr,
              this.state.usernameRegisteredErr, this.state.emailRegisteredErr]} />
            ) : null}
        <div className="regForm">
          <Form size="big">
            <Form.Field required>
                            <label>{strings.username}</label>
              <input
                name="username"
                                placeholder={strings.username}
                onChange={this.handleInputChange}
              />
            </Form.Field>
            <Form.Group widths="equal">
              <Form.Input
                required
                fluid
                name="firstName"
                                label={strings.firstName}
                                placeholder={strings.firstName}
                onChange={this.handleInputChange}
              />
              <Form.Input
                required
                fluid
                name="lastName"
                                label={strings.lastName}
                                placeholder={strings.lastName}
                onChange={this.handleInputChange}
              />
            </Form.Group>
            <Form.Field required>
                            <label>{strings.email}</label>
              <input
                                placeholder={strings.email}
                name="email"
                onChange={this.handleEmailChange}
              />
              {this.state.emailErr ? (
                                <Label basic color="red" pointing active>
                                    {strings.ivalidEmail}
                </Label>
              ) : null}
            </Form.Field>
            <Form.Input
              required
                            label={strings.password}
                            placeholder={strings.password}
              name="password"
              type="password"
              onChange={this.handleInputChange}
            />
            <Form.Input
              required
                            label={strings.repeat}
                            placeholder={strings.repeat}
              name="repPassword"
              type="password"
              onChange={this.handlePasswordChange}
            />
            {this.state.passRepErr ? (
              <Label basic color="red" pointing active>
                                {strings.doNotMatch}
              </Label>
            ) : null}
            <br />
            <div className="regButton">
              <center>
                <Button onClick={this.handleSubmit} size="large" primary>
                                    {strings.submit}
                </Button>
              </center>
            </div>
          </Form>
        </div>
      </div>
    );
  }
}
