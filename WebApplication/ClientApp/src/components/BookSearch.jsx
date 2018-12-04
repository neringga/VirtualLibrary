import React, { Component } from "react";
import axios from "axios";
import { Table } from "react-bootstrap";

import { HttpRequestPath, bookListApi } from "./Constants";

export class BookSearch extends Component {
    constructor() {
        super();
        this.state = {
            books: [],
            loading: false,
            showResults: false,
            searchKeyword: ''
        };
    }

    enteredKeyword = (event) => {
        console.error('inout change');
    }

    search = () => {
        console.error('search');
        //this.setState({ books: [{ Author: 'aa', Title: 'bb' }] });
        //this.setState({ showResults: true });
      
        this.setState({ loading: true });
        const data = { keyword: 'aa' };
        axios
            .get(HttpRequestPath + "api/BookSearch", data)
            .then(response => {
                console.error(response.data);
                this.setState({
                    loading: false,
                    books: response.data,
                    showResults: true
                });
                this.render();
            })
            .catch(() => {
                this.setState({ loading: false });
                console.log("API error")
            }); //TODO error handling
    }

    render() {
        let $loadingIcon = null;
        let $table = null;
        if (this.state.loading) {
            $loadingIcon = (
                <div class='ui active centered inline loader' />
            );
        }
        if (this.state.showResults) {
            $table = (
                <Table responsive>
                    <tbody>
                        {this.state.books.map((book, i) => (
                            <tr key={i} >
                                {book.Title} {book.Author}
                            </tr>
                        ))}
                    </tbody>
                </Table>
            );
        }
        return (
            this.state.books != null && (
                <div className="boxQr">
                    <h3>Book Search</h3>
                    <br />

                    <label>
                        Enter search keyword:
                            <input name="keyword" onChange={this.enteredKeyword} />
                    </label>
                    <button value="Search" onClick={this.search}>Search</button>
                    {$loadingIcon}
                    {$table}
                </div>
            )
        );
    }
}
