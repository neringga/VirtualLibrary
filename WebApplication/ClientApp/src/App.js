import React, { Component } from 'react';
import { Switch, Route } from 'react-router';

import { Start } from './components/Start';
import { Registration } from './components/Registration';
import { Cam } from './components/Cam';
import { NavBar } from './components/NavBar';
import { BookList } from './components/BookList';
import { HomePage } from './components/HomePage';

export default class App extends Component {

	render() {
		return (
			<Switch>
				<Route exact path='/' component={Start} />
				<Route exact path='/registration' component={Registration} />
				<Route exact path='/camera' component={Cam} />
				<Route exact path='/homePage' component={HomePage} />

			</Switch>
		);
	}
}
