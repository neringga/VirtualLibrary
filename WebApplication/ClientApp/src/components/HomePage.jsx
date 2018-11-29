import React, { Component } from "react";
import { ReturnBooks } from "./ReturnBooks";
import { Button } from "semantic-ui-react";
import { logout } from './AuthService';

export class HomePage extends Component {

  // Logout = () => {
  //   localStorage.removeItem("id_token");

  // }
  render() {
    return (<div><ReturnBooks />
    <Button onClick={logout()}>Logout</Button></div>
      );
  }
}
