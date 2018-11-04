import React, { Component } from "react";
import axios from "axios";
import "./SigningIn.css";
import {
    noUser,
    noUsername,
    noPassword,
    successfullSignIn
    userRegistrationApi,
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
        if (this.state.username == null) {
            alert(noUsername);
            return false;
        }
        if (
            this.state.password == null) {
            alert(noPassword);
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
                    alert(successfullSignIn);
                } else if (response.data == noUser) {
                    alert(noUser);
                }
            });
        }
    };

    render() {
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
                        <Link to={'/NavBar'}>
                            <button type="sign in" className="btn btn-primary">SignIn</button>
                        </Link>
                    </div>

                </form>
            </div>
        </div>
    );
}
}