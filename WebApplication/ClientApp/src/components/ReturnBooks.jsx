import React, { Component } from "react";
import axios from "axios";
import { Table } from 'react-bootstrap';
import {BootstrapTable, TableHeaderColumn} from 'react-bootstrap-table';
import 'react-bootstrap-table/dist/react-bootstrap-table-all.min.css';
import './Home.css';
import Popup from 'reactjs-popup';

import { HttpRequestPath, bookListApi } from "./Constants";
import { func } from "prop-types";

export class ReturnBooks extends Component {
    constructor() {
        super();
        this.onRowSelect = this.onRowSelect.bind(this);
        this.state = {
            books: []
          };
      }

      componentDidMount() {
        axios
          .get(HttpRequestPath + "api/TakenBook")
          .then(response => {
              console.log(response.data)
            this.setState({
              books: response.data
            });
          })
          .catch(error => (console.log("API error")));  //TODO error handling
      }

      onRowSelect({ row }) {
        alert("a");
      }

      

  render() {
    const options = {
      onRowClick: function(row) {
      },
      onRowDoubleClick: function(row) {
        alert(`You double click row id: ${row.Author}`);
      },
     
    };
    return (
      <div className="center">
      <BootstrapTable data = {this.state.books} options={ options } hover >
          <TableHeaderColumn dataField='Author' isKey>Author</TableHeaderColumn>
          <TableHeaderColumn dataField='Title'>Title</TableHeaderColumn>
          <TableHeaderColumn dataField='HasToBeReturned'>Return until</TableHeaderColumn>
      </BootstrapTable>
      </div>
      // <div className="center">
      // <Table onClick={this.handleClick} responsive hover>
      //   <thead>
      //     <tr>
      //       <th></th>
      //       <th>Book</th>
      //       <th>Return until</th>
      //     </tr>
      //   </thead>
      //   <tbody>
      //       { this.state.books.map( book => (
      //           <tr>
      //       <td></td>
      //       <td>
      //         {book.Title} {book.Author} 
      //       </td>
      //       <td>
      //           {book.HasToBeReturned}
      //       </td></tr>
      //       ))}
            
      //   </tbody>
      // </Table>
      // </div>
    );
  }
}
