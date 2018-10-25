import React, { Component } from 'react';
import { Switch, Route } from 'react-router';

import { Home } from './components/Home';
import { Registration } from './components/Registration';

export default class App extends Component {

	render() {
		return (
			<Switch>
				<Route exact path='/' component={Home} />
				<Route exact path='/registration' component={Registration} />
			</Switch>
		);
	}
}
