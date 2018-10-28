import React, { Component } from 'react';
import axios from 'axios';
import "./Registration.css";
import {HttpRequestPath, userRegistrationApi, emailRegex, emailErr, emailRegisteredErr, successfullRegistration,
	 usernameErr, passordNotMatchErr, emailRegexErr, usernameShortErr} from "./Constants.jsx";
import { Link } from 'react-router-dom'


export class Registration extends Component {
	constructor(props) {
		super(props)
		this.state = {
			username: "",
			firstName: "",
			lastName: "",
			email: "",
			password: "",
			repPassword: ""
		}
	}

	handleInputChange = (event) => {
		event.preventDefault()
		this.setState({
			[event.target.name]: event.target.value
		});
		
	}

	checkInput = (event) => {
		if (this.state.username == null || this.state.username.length < 3) {
			alert(usernameShortErr)
			return false
		}
		if (this.state.password == null || this.state.password != this.state.repPassword) {
			alert(passordNotMatchErr)
			return false
		}
		if (this.state.email == null || 
			!this.state.email.match(emailRegex)) {
			alert(emailRegexErr)
			return false
		}
		
		return true
	}

	handleSubmit = (event) => {
		event.preventDefault()
		if (this.checkInput()) {
		const data = this.state
		axios.put(HttpRequestPath + userRegistrationApi, data)
			.then(response => {
				if (response.data) {
					alert(successfullRegistration)
				}
				else if (response.data == emailErr){
					alert(emailRegisteredErr)
				}
				else if (response.data == usernameErr){
					alert(usernameErr)
				}
			});
		}

	}

	render() {
		return (
			<div className="container">
				<form className="box" onSubmit={this.handleSubmit}>
					<input
						name="username"
						placeholder="Username"
						onChange={this.handleInputChange}
					/>
					<br />
					<input
						name="firstName"
						placeholder="First name"
						onChange={this.handleInputChange}
					/>
					<br />
					<input
						name="lastName"
						placeholder="Last name"
						onChange={this.handleInputChange}
					/>
					<br />
					<input
						name="email"
						placeholder="Email"
						onChange={this.handleInputChange}
					/>
					<br />
					<input
						name="password"
						placeholder="Password"
						type="Password"
						onChange={this.handleInputChange}
					/>
					<br />
					<input
						name="repPassword"
						placeholder="Repeat Password"
						type="Password"
						onChange={this.handleInputChange}
					/>
					<br />
					<Link to={'/camera'}>                   
						<button className="button">
							Take a pic
						</button>
					</Link>
					<br />
					<button >Register</button>
				</form>
			</div>
		);
	}
}
