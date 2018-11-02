import React, { Component } from "react";
import axios from "axios";
import "./SigningIn.css";
import {
    usernameDoesntExist,
    noUsername,
    noPassword
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
            this.state.password == null ) {
            alert(noPassword);
            return false;
        }
        return true;
    };


}