import React, { Component } from "react";
import axios from "axios";
import { BootstrapTable, TableHeaderColumn } from "react-bootstrap-table";
import "react-bootstrap-table/dist/react-bootstrap-table-all.min.css";
import "./Home.css";
import { HttpRequestPath } from "./Constants";
import { getProfile, getToken } from "./AuthService";
import { Button } from "semantic-ui-react";
import Modal from "react-responsive-modal";

export class ReturnBooks extends Component {
  constructor() {
    super();
    this.state = {
      books: [],
      showModal: false,
      code: null
    };
  }

  componentDidMount() {
    const user = getProfile();
    const token = getToken();
    axios
      .post(HttpRequestPath + "api/TakenBook", user
      )
      .then(response => {
        this.setState({
          books: response.data
        });
      })
  }

  onSelectBook = row => {
    this.setState({ showModal: true, code: row.Code });
  };

  handleClose = row => {
    this.setState({ showModal: false });
  };

  returnBook = row => {
    const data = {
      isbnCode: this.state.code,
      user: getProfile()
    };
    axios.put(HttpRequestPath + "api/ReturnBook", data).then(response => {
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

    const modalStyle = {
      position: "fixed",
      zIndex: 1040,
      top: 0,
      bottom: 0,
      left: 0,
      right: 0
    };

    return (
      <div>
        <div className="boxBooks">
        <h3>Select a book to return</h3>
        <br/>
        <BootstrapTable responsive data={this.state.books} selectRow={selectRow} hover>
          <TableHeaderColumn dataField="Author" isKey>
            Author
          </TableHeaderColumn>
          <TableHeaderColumn dataField="Title">Title</TableHeaderColumn>
          <TableHeaderColumn dataField="Code" hidden="true">
            Code
          </TableHeaderColumn>
          <TableHeaderColumn dataField="HasToBeReturned">
            Return until
          </TableHeaderColumn>
        </BootstrapTable>
        </div>
        <Modal
            open={this.state.showModal}
            onClose={this.handleClose}
            center
            styles={{ overlay: modalStyle }}
          >
            <div className="font">
            <h4 id="modal-label">Return book</h4>
            <br/>
            <p>Do you really want to return this book?</p>
            <br/>
            <Button size="large" onClick={this.returnBook}>Yes</Button>
            <Button size="large" onClick={this.close}>No</Button>
            </div>
          </Modal>
        
      </div>
    );
  }
}
