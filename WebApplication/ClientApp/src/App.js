import React, { Component } from "react";
import { Switch, Route, Redirect } from "react-router";
import decode from "jwt-decode";

import { Layout } from "./components/Layout";
import { Start } from "./components/Start";
import { Registration } from "./components/Registration";
import { SigningIn } from "./components/SigningIn";
import { BookTaking } from "./components/BookTaking";
import { HomePage } from "./components/HomePage";
import { RegistrationCamera } from "./components/RegistrationCamera";
import { ReturnBooks } from "./components/ReturnBooks";
import { BookList } from "./components/BookList";
import { BookSearch } from "./components/BookSearch";
import { LogInCamera } from "./components/LogInCamera";
import { loggedIn } from "./components/AuthService";


export default class App extends Component {
  render() {
    const AuthRoute = ({ component: Component, ...rest }) => (
      <Route
        {...rest}
        render={props =>
          loggedIn() ? (
            <Component {...props} />
          ) : (
            <Redirect to={{ pathname: "/" }} />
          )
        }
      />
    );
    return (
      <Switch>
        <Route exact path="/" component={Start} />
        <Route exact path="/registration" component={Registration} />
        <Route exact path="/signIn" component={SigningIn} />
        <Route
          exact
          path="/registration/camera"
          component={RegistrationCamera}
        />
        <Route exact path="/signIn/camera" component={LogInCamera} />
        <Layout>
          <AuthRoute exact path="/homePage" component={HomePage} />
          <AuthRoute exact path="/bookTaking" component={BookTaking} />
          <AuthRoute exact path="/returnBooks" component={ReturnBooks} />
          <AuthRoute exact path="/books" component={BookList} />
          <AuthRoute exact path='/bookSearch' component={BookSearch} />
        </Layout>
      </Switch>
    );
  }
}
