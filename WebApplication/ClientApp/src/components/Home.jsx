import React, { Component } from 'react';
import "./Home.css";
import { Link } from 'react-router-dom'

export class Home extends Component {

	render() {
		return (
			<div className="container">
				<div className="box">
                    <h1>Welcome to Virtual Library!</h1>
                    <Link to={'/signIn'}>
                        <button className="button">
                            SignIn
                        </button>
                    </Link>
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
