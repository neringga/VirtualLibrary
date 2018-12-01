import React, { Component } from 'react';
import { Switch, Route } from 'react-router';

import { Layout } from './components/Layout'
import { Start } from './components/Start';
import { Registration } from './components/Registration';
import { SigningIn } from './components/SigningIn'
import { BookTaking } from './components/BookTaking';
import { HomePage } from './components/HomePage';
import { RegistrationCamera } from './components/RegistrationCamera';
import { ReturnBooks } from './components/ReturnBooks';
import { BookList } from './components/BookList';
import { ReturnBook } from './components/ReturnBook';
import { LogInCamera } from './components/LogInCamera';
import { BookSearch } from './components/BookSearch';

export default class App extends Component {

	render() {
		return (
			
			<Switch>
				<Route exact path='/' component={Start} />
                <Route exact path='/registration' component={Registration} />
                <Route exact path='/signIn' component={SigningIn} />
                <Route exact path='/registration/camera' component={RegistrationCamera} />
                <Route exact path='/signIn/camera' component={LogInCamera} />
				<Layout>
				<Route exact path='/homePage' component={HomePage} />
				<Route exact path='/bookTaking' component={BookTaking} />
				<Route exact path='/returnBooks' component={ReturnBooks} />
				<Route exact path='/returnBook' component={ReturnBook} />
				<Route exact path='/books' component={BookList} />
                <Route exact path='/bookSearch' component={BookSearch} />
				</Layout>
			</Switch>
			
		);
	}
}
