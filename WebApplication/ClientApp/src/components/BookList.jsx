import React, { Component } from "react";
import axios from "axios";
import { Table } from "react-bootstrap";
import { BootstrapTable, TableHeaderColumn } from "react-bootstrap-table";


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
    axios
      .get(HttpRequestPath + "api/Book")
      .then(response => {
        this.setState({
          loading: false,
          books: response.data
        });
      })
      .catch(console.log("API error")); //TODO error handling
  }

  render() {
    let $loadingIcon = null;
    if (this.state.loading) {
      $loadingIcon = (
        <div class='ui active centered inline loader' />
      );
    }
    return (
      this.state.books != null && (
        <div className="boxBooks">
          <h3>Books</h3>
          <br />
          <BootstrapTable search={ true } 
          data={ this.state.books } >
          <TableHeaderColumn  dataField='Title' isKey={ true }>Title</TableHeaderColumn>
          <TableHeaderColumn  dataField='Author'>Author</TableHeaderColumn>
      </BootstrapTable>
          {/* { $loadingIcon } */}
          {/* <Table responsive>
            <thead>
              <tr>
                <th />
                <th />
              </tr>
            </thead>
            <tbody>
              {this.state.books.map(book => (
                <tr>
                  <td />
                  <td>
                    {book.Title} {book.Author}
                  </td>
                </tr>
              ))}
            </tbody>
          </Table> */}
        </div>
      )
    );
  }
}
