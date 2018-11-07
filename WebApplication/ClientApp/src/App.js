import React, { Component } from 'react';
import { Switch, Route } from 'react-router';

import { Start } from './components/Start';
import { Registration } from './components/Registration';
import { SigningIn } from './components/SigningIn'
import { BookTaking } from './components/BookTaking';
import { NavBar } from './components/NavBar';
import { BookList } from './components/BookList';
import { HomePage } from './components/HomePage';
import { RegistrationCamera } from './components/RegistrationCamera';

export default class App extends Component {

	render() {
		return (
			<Switch>
				<Route exact path='/' component={Start} />
                <Route exact path='/registration' component={Registration} />
                <Route exact path='/signIn' component={SigningIn} />
                <Route exact path='/registration/camera' component={RegistrationCamera} />
				<Route exact path='/homePage' component={HomePage} />

				<Route exact path='/bookTaking' component={BookTaking} />
			</Switch>
		);
	}
}
