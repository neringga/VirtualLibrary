import React, { Component } from "react";
import { BookList } from './BookList';
import { NavBar } from './NavBar';
import { Statistics } from './Statistics';
import { Reviews } from './Reviews';

export class HomePage extends Component {
  render() {
    return (
      <div className="containerHome">
        <BookList/>
        <Statistics/>
        <Reviews/>
        <NavBar/>
      </div>
    );
  }
}
