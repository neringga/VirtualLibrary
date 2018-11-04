import React, { Component } from "react";
import axios from "axios";

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
      .get(HttpRequestPath + bookListApi)
      .then(response => {
        this.setState({
          books: response.data
        });
      })
      .catch(error => (alert("API error")));
  }

  render() {
    return (
      this.state.books!=null &&
      <div className="containerBookList">
        <h3>New Books</h3>
        <br/>
        <ul className="list-group">
          { this.state.books.map( book => (
            <li className="list-group-item"> 
              {book.Title} {book.Author} 
            </li>
          ))}
        </ul>
      </div>
    );
  }
}
