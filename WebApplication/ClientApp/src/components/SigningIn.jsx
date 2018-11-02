import React, { Component } from "react";
import axios from "axios";
import "./SigningIn.css";
import {
    
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
}