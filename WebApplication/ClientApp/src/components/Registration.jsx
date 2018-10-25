import React, { Component } from 'react';
import "./Registration.css";

export class Registration extends Component {


	render() {
		return (
			<div className="container">
				<div className="box">
					<div className="registration">
						<h1>Register</h1>
						<input type="text" placeholder="Username" />
						<input type="text" placeholder="Name" />
						<input type="text" placeholder="Surname" />
						<input type="text" placeholder="Email" />
						<input type="password" placeholder="Password" />
						<input type="password" placeholder="Repeat Password" />
						<button>Register</button>
					</div>
				</div>
			</div>
		);
	}
}
