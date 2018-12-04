import React, { Component } from "react";
import axios from "axios";
import { BootstrapTable, TableHeaderColumn } from "react-bootstrap-table";
import { Modal } from "react-bootstrap";
// import { Button, Header, Image, Modal } from 'semantic-ui-react'

import { HttpRequestPath, bookListApi } from "./Constants";

export class BookList extends Component {
  constructor() {
    super();
    this.state = {
      books: [],
      loading: true
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
    this.setState({ showModal: true });
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
  };

  handleClose = () => {
    this.setState({
      showModal: false
    });
  };

  render() {
    const selectRow = {
      mode: "radio",
      clickToSelect: true,
      onSelect: this.onSelectBook
    };

    const backdropStyle = {
      ...modalStyle,
      zIndex: "auto",
      backgroundColor: "#000",
      opacity: 0.5
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
      this.state.books != null && (
        <div className="boxBooks">
          <h3>Books</h3>
          <p>Choose book for more information</p>
          <br />
          <BootstrapTable
            search={true}
            selectRow={selectRow}
            data={this.state.books}
            hover
          >
            <TableHeaderColumn dataField="Title" isKey={true}>
              Title
            </TableHeaderColumn>
            <TableHeaderColumn dataField="Author">Author</TableHeaderColumn>
          </BootstrapTable>

          

          <Modal
            aria-labelledby="modal-label"
            style={modalStyle}
            backdropStyle={backdropStyle}
            onHide={this.handleClose}
            show={this.state.showModal}
          >
            <div>
              <center>
                <Modal.Header closeButton>
                  <Modal.Title>Book information</Modal.Title>
                </Modal.Header>
                <b>Description:</b>
                <br/>
                <p>{this.state.description}</p>
                <br />
                <p>{this.state.pages} <b>pages</b></p>
                <br />
                <p><b>Ganre:</b> {this.state.ganre}</p>
                <br/>
              </center>
            </div>
          </Modal>
        </div>
      )
    );
  }
}
