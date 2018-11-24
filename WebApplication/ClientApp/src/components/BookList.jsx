import React, { Component } from "react";
import axios from "axios";
import { Table } from "react-bootstrap";

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
      .catch(error => console.log("API error")); //TODO error handling
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
        <div className="box">
          <h3>Books</h3>
          <br />
          { $loadingIcon }
          <Table responsive>
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
          </Table>
        </div>
      )
    );
  }
}
