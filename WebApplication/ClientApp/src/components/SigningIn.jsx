import React, { Component } from "react";
import axios from "axios";
import "./SigningIn.css";
import './Home.css';
import { setToken } from "./AuthService";
import { getLanguage } from "./AuthService";
import { Form, Message, Button } from "semantic-ui-react";
import logo from "./logo.png";
import LocalizedStrings from 'react-localization';
import {
  noUsername,
  noPassword,
  userSignInApi,
  successfullSignIn,
  noUser,
  HttpRequestPath
} from "./Constants.jsx";

let strings = new LocalizedStrings({
    en: {
        username: "Username",
        password: "Password",
        signIn: "Sign in",
        tryAgain: "Try again!",
        notValid: "Username or password not valid",
        submit: "Submit",
        
    },
    lt: {
        username: "Prisijungimo vardas",
        password: "Slaptažodis",
        signIn: "Prisijungti",
        tryAgain: "Bandykite dar kartą!",
        notValid: "Neteisingas prisijungimo vardas arba slaptažodis",
        submit: "Pateikti",
    }
});

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
        _onSetLanguageTo(lang) {
            strings.setLanguage(lang);
        }
    render() {
        const lang = getLanguage();
      return (
      this._onSetLanguageTo(lang),
      <div className="boxSignin">
            <center><img className="logoSignIn" src={logo} height="140" width="120" /></center>
            <h3>{strings.signIn}</h3>
            {this.state.badCredentials ? (
                <Message error header={strings.tryAgain} list={ strings.notValid } />
              ) : null}
      <div className="sigginForm">
      <Form size="big">
                    <Form.Field>
                        <label>{strings.username}</label>
              <input
                name="username"
                placeholder={strings.username}
                onChange={this.handleInputChange}
              />
            </Form.Field>
            <Form.Field>
                        <label>{strings.password}</label>
              <input
                name="password"
                placeholder={strings.password}
                onChange={this.handleInputChange}
              />
            </Form.Field>
            <center>
                <Button onClick={this.handleSubmit} size="large" primary>
                            {strings.submit}
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
