import React, { Component } from "react";
import { BookList } from './BookList';
import { NavBar } from './NavBar';

export class HomePage extends Component {
  render() {
    return (
      <div className="containerHome">
        <NavBar/>
        <BookList/>
      </div>
    );
  }
}
