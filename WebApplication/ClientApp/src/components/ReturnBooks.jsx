import React, { Component } from "react";
import axios from "axios";
import { Table, Modal, Button } from "react-bootstrap";
import { BootstrapTable, TableHeaderColumn } from "react-bootstrap-table";
import "react-bootstrap-table/dist/react-bootstrap-table-all.min.css";
import "./Home.css";
import Popup from "reactjs-popup";

import { HttpRequestPath, bookListApi } from "./Constants";
import { func } from "prop-types";

export class ReturnBooks extends Component {
  constructor() {
    super();
    // this.onRowSelect = this.onRowSelect.bind(this);
    this.state = {
      books: [],
      showModal: false,
      code: null
    };
  }

  componentDidMount() {
    axios
      .get(HttpRequestPath + "api/TakenBook")
      .then(response => {
        console.log(response.data);
        this.setState({
          books: response.data
        });
      })
      .catch(error => console.log("API error")); //TODO error handling
  }

  onSelectBook = row => {
    this.setState({ showModal: true, code : row.Code});
  };

  close = row => {
    this.setState({ showModal: false });
  };

  returnBook = row => {
    axios.put(HttpRequestPath + 'api/ReturnBook', this.state.code).then(response => {
        if (response.data) {
          window.location.reload();
        }
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
      <div className="center">
        <BootstrapTable data={this.state.books} selectRow={selectRow} hover>
          <TableHeaderColumn dataField="Author" isKey>
            Author
          </TableHeaderColumn>
          <TableHeaderColumn dataField="Title">Title</TableHeaderColumn>
          <TableHeaderColumn dataField="Code" hidden="true">Code</TableHeaderColumn>
          <TableHeaderColumn dataField="HasToBeReturned">
            Return until
          </TableHeaderColumn>
        </BootstrapTable>

        <Modal
          aria-labelledby="modal-label"
          style={modalStyle}
          backdropStyle={backdropStyle}
          show={this.state.showModal}
          onHide={this.close}
        >
          <div>
            <h4 id="modal-label">Return book</h4>
            <p>Do you want to return this book?</p>
            <Button onClick={this.returnBook}>Yes</Button>
            <Button onClick={this.close}>No</Button>
          </div>
        </Modal>
      </div>
    );
  }
}
