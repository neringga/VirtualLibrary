import React, { Component } from "react";
import axios from "axios";
import { Table } from 'react-bootstrap';

import { HttpRequestPath, bookListApi } from "./Constants";

export class BookList extends Component {
  constructor() {
    super();
    this.state = {
        books: []
      };
  }

  componentDidMount() {
    axios
      .get(HttpRequestPath + 'api/Book')
      .then(response => {
        this.setState({
          books: response.data
        });
      })
      .catch(error => (console.log("API error")));  //TODO error handling
  }

  render() {
    return (
      this.state.books!=null &&
      <center>
      <div className="box">
        <h3>Not taken books</h3>
        <br/>
        <Table responsive>
        <thead>
          <tr>
            <th></th>
            <th></th>
          </tr>
        </thead>
        <tbody>
            { this.state.books.map( book => (
                <tr>
            <td></td>
            <td>
              {book.Title} {book.Author} 
            </td>
            </tr>
            ))}
            
        </tbody>
      </Table>
      </div>
      </center>
    );
  }
}
