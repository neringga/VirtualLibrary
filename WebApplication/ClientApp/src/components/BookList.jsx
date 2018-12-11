import React, { Component } from "react";
import axios from "axios";
import { BootstrapTable, TableHeaderColumn } from "react-bootstrap-table";
import Modal from "react-responsive-modal";
import { Button, Comment, Form, Icon, Input } from "semantic-ui-react";
import "./Home.css";
import { HttpRequestPath } from "./Constants.jsx";
import { getProfile } from "./AuthService";

import LocalizedStrings from 'react-localization';
import { getLanguage } from "./LangService";

let strings = new LocalizedStrings({
    en: {
        chooseBook: "Choose book for more information",
        title: "Title",
        code: "Code",
        bookInfo: "Book information",
        description: "Description:",
        genre: "Genre:",
        review: "Reviews",
    },
    lt: {
        chooseBook: "Pasirinkite knygą, jei norite gauti daugiau informacijos",
        title: "Pavadinimas",
        code: "Kodas",
        bookInfo: "Informacija apie knygą",
        description: "Aprašymas:",
        genre: "Žanras:",
        review: "Atsiliepimai",
    },
});


export class BookList extends Component {
  constructor() {
    super();
    this.state = {
      books: [],
      loading: true,
      comments: []
    };
  }

  componentDidMount() {
    axios.get(HttpRequestPath + "api/Book").then(response => {
      this.setState({
        loading: false,
        books: response.data
      });
    });
  }

  onSelectBook = row => {
    const authorName = row.Author.split(" ");
    const auth = authorName.join("+");
    this.setState({
      showReview: true,
      showModal: true,
      Code: row.Code,
      Author: row.Author
    });
    axios
      .get(
        "https://www.googleapis.com/books/v1/volumes?q=" +
          auth +
          "+" +
          row.Title
      )
      .then(res => {
        this.setState({
          description: res.data.items[0].volumeInfo.description,
          pages: res.data.items[0].volumeInfo.pageCount,
          ganre: res.data.items[0].volumeInfo.categories
        });
      });

    axios.post(HttpRequestPath + "api/Review", row.Code).then(res => {
      this.setState({
        comments: res.data
      });
    });
  };

  handleClose = () => {
    this.setState({
      showModal: false
    });
  };

  onInputChange = event => {
    this.setState({
      newReview: event.target.value
    });
  };

  onReviewButtonClick = () => {
    const data = {
      BookCode: this.state.Code,
      User: getProfile(),
      Review: this.state.newReview
    };

    this.setState({
      newReview: null
    });

    axios.put(HttpRequestPath + "api/Review", data).then(res => {
      if (res) {
        var newComments = this.state.comments.slice();
        newComments.push(data);
        this.setState({
          comments: newComments
        });
        document.getElementById("myForm").reset();
      }
    });
  };

  handleReviewShowing = showReview => {
    if (showReview || showReview === 1) {
      return (
        <div className="comments">
          {this.state.comments.map(comment => (
            <div className="singleComment">
              <Icon name="comment" />
              <b>{comment.User}</b> {comment.Review}
            </div>
          ))}
          <form id="myForm">
            <div className="commentInput">
              <Input onChange={this.onInputChange} fluid placeholder="Review" />
            </div>
          </form>
          <Button
            primary
            onClick={this.onReviewButtonClick}
            floated="right"
            size="large"
            icon
            labelPosition="left"
          >
            <Icon name="add" />
            Add review
          </Button>
        </div>
      );
    } else {
      return null;
    }
        }

        _onSetLanguageTo(lang) {
            strings.setLanguage(lang);
        }

    render() {
    const lang = getLanguage();
    const selectRow = {
      mode: "radio",
      clickToSelect: true,
      onSelect: this.onSelectBook
    };

    const modalStyle = {
      position: "fixed",
      zIndex: 1040,
      top: 0,
      bottom: 0,
      left: 0,
      right: 0
    };

      return (
      this._onSetLanguageTo(lang),
      this.state.books != null && (
        <div className="boxBooks">
                  <h3>Books</h3>
                  <p>{strings.chooseBook}</p>
          <br />
          <BootstrapTable
            search={true}
            selectRow={selectRow}
            data={this.state.books}
            hover
          >
            <TableHeaderColumn dataField="Title" isKey={true}>
                          {strings.title}
            </TableHeaderColumn>
            <TableHeaderColumn dataField="Author">Author</TableHeaderColumn>
            <TableHeaderColumn dataField="Code" hidden="true">
                          {strings.code}
            </TableHeaderColumn>
          </BootstrapTable>

          <Modal
            open={this.state.showModal}
            onClose={this.handleClose}
            center
            styles={{ overlay: modalStyle }}
          >
            <div className="font">
                          <h3>{strings.bookInfo}</h3>
                          <p>
                              <b>{strings.description}</b> {this.state.description}
              </p>
              <br />
              <p>
                              <b>{strings.gendre}</b> {this.state.ganre}, <b>Pages:</b>{" "}
                {this.state.pages}
              </p>
            </div>
            <hr />
                      <h3>{strings.review}</h3>
            {this.handleReviewShowing(this.state.showReview)}
          </Modal>
        </div>
      )
    );
  }
}
