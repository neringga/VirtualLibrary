import React, { Component } from "react";
import { ReturnBooks } from "./ReturnBooks";
// import { Button, Divider, Grid, Header, Icon, Search, Segment } from 'semantic-ui-react';
import './Home.css';
import { getProfile } from "./AuthService";
import { Grid, Image, Header, Icon } from 'semantic-ui-react';
import { LinkContainer } from 'react-router-bootstrap';


export class HomePage extends Component {
  render() {
    return (
      <div className="boxHome">
      <h3>Hello, <b>{getProfile()}</b></h3>
      <div className="spacingHome">
      <h4>What do you want to do?</h4>
      </div>
      <Grid divided='vertically'>
    <Grid.Row columns={2}>
    <LinkContainer to={'/BookTaking'} exact>
      <Grid.Column>
      <Header icon>
            <Icon name='cart plus' color='blue'/>
        Take a book
        </Header>
      </Grid.Column>
      </LinkContainer>
      <LinkContainer to={'/BookReturn'} exact>
      <Grid.Column>
      <Header icon>
            <Icon name='eye' color='blue'/>
        See your book list
        </Header>
      </Grid.Column>
      </LinkContainer>
    </Grid.Row>

    </Grid>
    <Grid divided='vertically'>
    <Grid.Row columns={2}>
    <LinkContainer to={'/Books'} exact>
      <Grid.Column>
      <Header icon>
            <Icon name='book' color='blue'/>
        See available books
        </Header>
      </Grid.Column>
      </LinkContainer>
      <LinkContainer to={'/ReturnBooks'} exact>
      <Grid.Column>
      <Header icon>
            <Icon name='minus' color='blue'/>
        Return a book
        </Header>
      </Grid.Column>
      </LinkContainer>
    </Grid.Row>
    </Grid>
      </div>
    )
  }
}
