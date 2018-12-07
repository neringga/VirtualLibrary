import React, { Component } from 'react';
import { Glyphicon, Nav, Navbar, NavItem } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import './NavMenu.css';
import { Icon } from 'semantic-ui-react';
// import { Logout } from './Logout';
import { Link } from "react-router-dom";
import { logout } from './AuthService';



 export class NavMenu extends Component {
   
   render() {
    return (
      <Navbar inverse fixedTop fluid collapseOnSelect>
        <Navbar.Header>
          <Navbar.Brand>
            <Icon color='white' name='book' />
            <a>LIBRY</a>
          </Navbar.Brand>
          <Navbar.Toggle />
        </Navbar.Header>
        <Navbar.Collapse>
          <Nav>
            <LinkContainer to={'/HomePage'} exact>
              <NavItem>
                <Glyphicon glyph='home' /> Home
              </NavItem>
            </LinkContainer>
            <LinkContainer to={'/BookTaking'} exact>
              <NavItem>
                <Glyphicon glyph='	glyphicon glyphicon-download-alt' /> Take book
              </NavItem>
            </LinkContainer>
            <LinkContainer to={'/books'} exact>
              <NavItem>
                <Glyphicon glyph='glyphicon glyphicon-book' /> Books
              </NavItem>
            </LinkContainer>
            <LinkContainer to={'/ReturnBooks'} exact>
              <NavItem>
                <Glyphicon glyph='glyphicon glyphicon-stats' /> Return book
              </NavItem>
            </LinkContainer>
           
            <LinkContainer to={'/'} exact>
              <NavItem onClick={logout}>
              <Icon name='log out' /> Logout
              </NavItem>
            </LinkContainer>
            <LinkContainer to={'/bookSearch'} exact>
              <NavItem>
                <Glyphicon glyph='glyphicon glyphicon-search' /> Search books
              </NavItem>
            </LinkContainer>
          </Nav>
        </Navbar.Collapse>
      </Navbar>
    );
  }
}