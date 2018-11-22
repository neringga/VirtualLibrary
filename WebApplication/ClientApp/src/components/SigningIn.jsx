import React, { Component } from "react";
import axios from "axios";
import "./SigningIn.css";
import {
    noUser,
    noUsername,
    noPassword,
    successfullSignIn,
    userSignInApi,
    HttpRequestPath
} from "./Constants.jsx";
import { Link } from "react-router-dom";

export class SigningIn extends Component {
    constructor(props) {
        super(props);
        this.state = {
            username: "",
            password: "",
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
        if (
            this.state.password === null) {
            alert(noPassword);
            return false;
        }
        return true;
    };

    handleSubmit = event => {
        event.preventDefault();
        if (this.checkInput()) {
            const data = this.state;
            // Auth.login(this.state.user, this.state.password);
        }
    };

    render() {
        return (
                // <div className="scrollableBox" overflow-y="scroll">
                    <form>
                        <div className="form-group">
                            <label>Username</label>
                            <input
                                type="username"
                                name="username"
                                className="form-control"
                                placeholder="Username"
                                valueLink={this.linkState('user')}
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
                                valueLink={this.linkState("password")}
                                onChange={this.handleInputChange}
                            />
                        </div>
                        <div>
                            <button className="btn btn-primary" onClick={this.handleSubmit}>SignIn</button>
                        </div>

                    </form>
                // </div>
        );
    }
}