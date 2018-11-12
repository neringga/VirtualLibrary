import React, { Component } from "react";
import "./Home.css";
import { Link } from "react-router-dom";
import { Button, ButtonGroup, ButtonToolbar, Form, FormControl, FormGroup } from 'react-bootstrap';
import logo from "./logo.png";

export class Start extends Component {
  render() {
    return (
      <div className="container">
        <div className="box">
        <Form>
          <FormGroup className="form">
          <img src={logo} height="200" width="180"/>
          </FormGroup>
          <FormGroup>
          <Link to={"/signIn"}>
          <Button bsStyle="success">Sign In</Button>
          </Link>
          </FormGroup>
          <FormGroup>
          <Link to={"/registration"}>
          <Button bsStyle="primary">Sign Up</Button>
          </Link>
          </FormGroup>
          </Form>
        </div>
      </div>
    );
  }
}
