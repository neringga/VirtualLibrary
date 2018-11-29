import React, { Component } from "react";
import axios from "axios";
import { BootstrapTable, TableHeaderColumn } from "react-bootstrap-table";
import "react-bootstrap-table/dist/react-bootstrap-table-all.min.css";
import "./Home.css";
import { Button, Header, Icon, Modal } from "semantic-ui-react";
import { HttpRequestPath } from "./Constants";

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
    this.setState({ showModal: true, code: row.Code });
  };

  close = row => {
    this.setState({ showModal: false });
  };

  returnBook = row => {
    const isbn = {
      isbnCode: this.state.code
    };
    axios.put(HttpRequestPath + "api/ReturnBook", isbn).then(response => {
      if (response.data) {
        window.location.reload();
      }
    });
  };

  handleRowSelect = showPopup => {
    if (showPopup) {
      return (
        <Modal trigger={<Button>Show Modal</Button>} closeIcon>
        <Header icon='archive' content='Archive Old Messages' />
        <Modal.Content>
          <p>
            Your inbox is getting full, would you like us to enable automatic archiving of old messages?
          </p>
        </Modal.Content>
        <Modal.Actions>
          <Button color='red'>
            <Icon name='remove' /> No
          </Button>
          <Button color='green'>
            <Icon name='checkmark' /> Yes
          </Button>
        </Modal.Actions>
      </Modal>);
    } else return null;
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
      <div>
        <BootstrapTable data={this.state.books} selectRow={selectRow} hover>
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

        {this.handleRowSelect(this.state.showModal)}
      </div>
    );
  }
}
