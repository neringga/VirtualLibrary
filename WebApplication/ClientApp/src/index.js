import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap/dist/css/bootstrap-theme.css';
import './index.css';
// import 'semantic-ui/dist/semantic.min.css';

import React, { Component } from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter, Redirect } from 'react-router-dom';
import App from './App';
import registerServiceWorker from './registerServiceWorker';
// import { AuthService } from './AuthService';

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');

// const AuthRoute = ({ component: Component, ...rest}) => (
// <Route {...rest} render={props => (
//   AuthService.LoggedIn() ? (
//     <Component {...props} />
//   ) : (
//     <Redirect to={{pathname: '/'}} />
//   )
// )} />
// )
ReactDOM.render(
  <BrowserRouter basename={baseUrl}>
    <App />
  </BrowserRouter>,
  rootElement);

registerServiceWorker();
