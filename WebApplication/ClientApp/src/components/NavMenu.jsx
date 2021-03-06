﻿import React, { Component } from "react";
import { Glyphicon, Nav, Navbar, NavItem } from "react-bootstrap";
import { LinkContainer } from "react-router-bootstrap";
import "./NavMenu.css";
import { Icon } from "semantic-ui-react";
// import { Logout } from './Logout';
import { Link } from "react-router-dom";
import { logout } from "./AuthService";

import LocalizedStrings from "react-localization";
import { getLanguage } from "./LangService";

let strings = new LocalizedStrings({
  en: {
    home: "Home",
    takeBook: "Take/Return book",
    books: "Books",
    returnBook: "Your taken books",
    searchBooks: "Search books",
    logout: "Logout",
    history: "Your read books"
  },
  lt: {
    home: "Pagrindinis puslapis",
    takeBook: "Paimti/Grąžinti knygą",
    books: "Knygos",
    returnBook: "Mano knygos",
    searchBooks: "Ieškoti knygų",
    logout:"Atsijungti",
    history: "Mano knygų istorija"
  }
});

export class NavMenu extends Component {
  _onSetLanguageTo(lang) {
    strings.setLanguage(lang);
  }
  render() {
    const lang = getLanguage();
    return (
      this._onSetLanguageTo(lang),
      (
        <Navbar inverse fixedTop fluid collapseOnSelect>
          <Navbar.Header>
            <Navbar.Brand>
              <Icon color="white" name="book" />
              <a>LIBRY</a>
            </Navbar.Brand>
            <Navbar.Toggle />
          </Navbar.Header>
          <Navbar.Collapse>
            <Nav>
              <LinkContainer to={"/HomePage"} exact>
                <NavItem>
                  <Glyphicon glyph="home" /> {strings.home}
                </NavItem>
              </LinkContainer>
              <LinkContainer to={"/BookTaking"} exact>
                <NavItem>
                  <Glyphicon glyph="	glyphicon glyphicon-download-alt" />{" "}
                  {strings.takeBook}
                </NavItem>
              </LinkContainer>
              <LinkContainer to={"/books"} exact>
                <NavItem>
                  <Glyphicon glyph="glyphicon glyphicon-book" /> {strings.books}
                </NavItem>
              </LinkContainer>
              <LinkContainer to={"/ReturnBooks"} exact>
                <NavItem>
                  <Glyphicon glyph="glyphicon glyphicon-stats" />{" "}
                  {strings.returnBook}
                </NavItem>
              </LinkContainer>
              <LinkContainer to={"/bookSearch"} exact>
                <NavItem>
                  <Glyphicon glyph="glyphicon glyphicon-search" />{" "}
                  {strings.searchBooks}
                </NavItem>
              </LinkContainer>
              <LinkContainer to={"/history"} exact>
                <NavItem>
                  <Glyphicon glyph="glyphicon glyphicon-search" />{" "}
                  {strings.history}
                </NavItem>
              </LinkContainer>
              <br/>
              <LinkContainer to={"/"} exact>
                <NavItem onClick={logout}>
                  <Icon name="log out" /> {strings.logout}
                </NavItem>
              </LinkContainer>
            </Nav>
          </Navbar.Collapse>
        </Navbar>
      )
    );
  }
}
