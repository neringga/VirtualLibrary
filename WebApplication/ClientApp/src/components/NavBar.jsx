import React, { Component } from "react";
import "bootstrap/dist/css/bootstrap.css";
import "bootstrap/dist/css/bootstrap-theme.css";

export class NavBar extends Component {
  constructor(props) {
    super(props);
    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      collapsed: true
    };
  }

  toggleNavbar() {
    this.setState({
      collapsed: !this.state.collapsed
    });
  }

  render() {
    const collapsed = this.state.collapsed;
    const classOne = collapsed
      ? "collapse navbar-collapse"
      : "collapse navbar-collapse show";
    const classTwo = collapsed ? "navbar-toggle collapsed" : "navbar-toggle";
    return (
      <nav className="navbar navbar-default">
        <div className="container-fluid">
          <div className="navbar-header">
            <button
              onClick={this.toggleNavbar}
              className={`${classTwo}`}
              type="button"
              data-toggle="collapse"
              data-target="#navbarResponsive"
              aria-controls="navbarResponsive"
              aria-expanded="false"
              aria-label="Toggle navigation"
            >
              <span className="icon-bar" />
              <span className="icon-bar" />
              <span className="icon-bar" />
            </button>

            <div className={`${classOne}`} id="navbarResponsive">
              <a className="navbar-brand" href="#">                     {/*TODO responsive brand(it disapears in small screen*/}
                VILIB
              </a>
              <ul className="nav navbar-nav">
                <li className="active">
                  <a href="/NavBar">Home</a>
                </li>
                <li>
                  <a href="#">My Books</a>
                </li>
              </ul>
              <ul className="nav navbar-nav navbar-right">
        <li><a href="#"><span className="glyphicon glyphicon-log-in"></span> Logout</a></li>
      </ul>
            </div>
          </div>
        </div>
      </nav>
    );
  }
}
