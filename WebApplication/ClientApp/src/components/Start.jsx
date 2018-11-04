import React, { Component } from 'react';
import "./Home.css";
import { Link } from 'react-router-dom'

export class Start extends Component {

	render() {
		return (
			<div className="container">
				<div className="box">
					<h1>Welcome to Virtual Library!</h1>
					<button className="button"> Sign In</button>
					<Link to={'/registration'}>                   
						<button className="button">
							Register
						</button>
					</Link>
				</div>
			</div>
		);
	}



}
