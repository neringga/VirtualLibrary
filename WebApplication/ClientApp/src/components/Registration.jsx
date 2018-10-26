import React, { Component } from 'react';
import axios from 'axios';
import "./Registration.css";
//import constants from "./Constants";


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

	handleSubmit = (event) => {
		event.preventDefault()
		const data = this.state
		console.log(data)
		axios.put("http://localhost:50898/api/User", data)
			.then(response => {
				if (response.data)
					console.log("miau")
				else
					console.log(response)
			});

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
					<button >Register</button>
				</form>
			</div>
		);
	}
}
