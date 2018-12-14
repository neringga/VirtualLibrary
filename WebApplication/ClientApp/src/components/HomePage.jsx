import React, { Component } from "react";
import { ReturnBooks } from "./ReturnBooks";
import './Home.css';
import { getProfile } from "./AuthService";
import { Grid, Image, Header, Icon } from 'semantic-ui-react';
import { LinkContainer } from 'react-router-bootstrap';


import LocalizedStrings from 'react-localization';
import { getLanguage } from "./LangService";

let strings = new LocalizedStrings({
    en: {
        hello: "Hello,",
        toDo: "What do you want to do?",
        takeBook: "Take a book",
        seeList: "See your book list",
        seeBooks: "See available books",
        returnBooks: "Return a book",

    },
    lt: {
        hello: "Sveiki,",
        toDo: "Kokį veiksmą norėtumėte atlikti?",
        takeBook: "Pasiimti knygą",
        seeList: "Pamatyti savo knygų sąrašą",
        seeBooks: "Pamatyti galimas knygas",
        returnBooks: "Grąžinti knygą",
       
    },

});

export class HomePage extends Component {
    _onSetLanguageTo(lang) {
        strings.setLanguage(lang);
    }
    render() {
        const lang = getLanguage();
        return (
            this._onSetLanguageTo(lang),
      <div className="boxHome">
                <h3>{strings.hello} <b>{getProfile()}</b></h3>
      <div className="spacingHome">
                    <h4>{strings.toDo}</h4>
      </div>
      <Grid divided='vertically'>
    <Grid.Row columns={2}>
    <LinkContainer to={'/BookTaking'} exact>
      <Grid.Column>
      <Header icon>
                                    <Icon name='cart plus' color='blue' />
                                    {strings.takeBook}
        </Header>
      </Grid.Column>
      </LinkContainer>
      <LinkContainer to={'/ReturnBooks'} exact>
      <Grid.Column>
      <Header icon>
                                    <Icon name='eye' color='blue' />
                                    {strings.seeList}
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
                                    <Icon name='book' color='blue' />
                                    {strings.seeBooks}
        </Header>
      </Grid.Column>
      </LinkContainer>
      <LinkContainer to={'/BookTaking'} exact>
      <Grid.Column>
      <Header icon>
                                    <Icon name='minus' color='blue' />
                                    {strings.returnBooks}
        </Header>
      </Grid.Column>
      </LinkContainer>
    </Grid.Row>
    </Grid>
      </div>
    )
  }
}
