import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { Glyphicon, Nav, Navbar, NavItem } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import './NavMenu.css';
import logo from './logo.png';

 export class NavMenu extends Component {
   render() {
    return (
      <Navbar inverse fixedTop fluid collapseOnSelect>
        <Navbar.Header>
          <Navbar.Brand>
            <a>LIBRY</a>
              {/* TODO Add logo */}
              {/* <a href="#"><img src={logo} color='white' weight="40" height="40"/></a>   */}
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
            <LinkContainer to={'/Statistics'} exact>
              <NavItem>
                <Glyphicon glyph='glyphicon glyphicon-stats' /> Your statistics
              </NavItem>
            </LinkContainer>
            <LinkContainer to={'/'} exact>
              <NavItem>
                <Glyphicon glyph='glyphicon glyphicon-comment' /> Reviews
              </NavItem>
            </LinkContainer>
            {/* <LinkContainer to={'/counter'}>
              <NavItem>
                <Glyphicon glyph='education' /> Counter
              </NavItem>
            </LinkContainer>
            <LinkContainer to={'/fetchdata'}>
              <NavItem>
                <Glyphicon glyph='th-list' /> Fetch data
              </NavItem>
            </LinkContainer> */} */}
          </Nav>
        </Navbar.Collapse>
      </Navbar>
    );
  }
}