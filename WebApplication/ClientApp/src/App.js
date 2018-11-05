import React, { Component } from 'react';
import { Switch, Route } from 'react-router';

import { Start } from './components/Start';
import { Registration } from './components/Registration';
import { SigningIn } from './components/SigningIn'
import { RegistrationCamera } from './components/RegistrationCamera';
import { NavBar } from './components/NavBar';
import { BookList } from './components/BookList';
import { HomePage } from './components/HomePage';

export default class App extends Component {

	render() {
		return (
			<Switch>
				<Route exact path='/' component={Start} />
                <Route exact path='/registration' component={Registration} />
                <Route exact path='/signIn' component={SigningIn} />
                <Route exact path='/registration/camera' component={RegistrationCamera} />
				<Route exact path='/homePage' component={HomePage} />

			</Switch>
		);
	}
}
