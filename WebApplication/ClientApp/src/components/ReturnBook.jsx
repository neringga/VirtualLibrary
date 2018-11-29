import React, { Component } from "react";    
import axios from "axios";
import { HttpRequestPath, bookListApi } from "./Constants";

// SHOULD BE DELETED

export class ReturnBook extends Component {
    constructor() {
        super();
        this.state = {
          books: [],
          code: null
        };
      }

      componentDidMount() {
        axios
          .get(HttpRequestPath + "api/TakenBook")
          .then(response => {
            this.setState({
              books: response.data
            });
          })
          .catch(error => console.log("API error")); //TODO error handling
      }

  render() {
    return (
      <div>
        <table class="ui selectable single line table">
          <thead className="">
            <tr className="">
              <th className="">Title</th>
              <th className="">Author</th>
              <th className="">Code</th>
            </tr>
          </thead>
          <tbody>
          {this.state.books.map(book => (
                <tr>
                  <td>
                    {book.Title}
                  </td>
                  <td>
                    {book.Author}
                  </td>
                  <td>
                    {book.Code}
                  </td>
                </tr>
              ))}
          </tbody>
        </table>
      </div>
    );
  }
}
