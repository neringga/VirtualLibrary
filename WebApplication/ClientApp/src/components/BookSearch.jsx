import React, { Component } from "react";
import axios from "axios";
import { Table } from "react-bootstrap";

import { HttpRequestPath, bookListApi } from "./Constants";
import Select from 'react-select';

export class BookSearch extends Component {
    constructor() {
        super();
        this.state = {
            books: [],
            loading: false,
            showResults: false,
            searchKeyword: '',
            hashtags: [
                { value: 'chocolate', label: 'Chocolate' },
                { value: 'strawberry', label: 'Strawberry' },
                { value: 'vanilla', label: 'Vanilla' }
            ],
            genres: [
                { value: 'aaa', label: 'aaa' },
                { value: 'bbb', label: 'bbb' }
            ],
            selectedHashtags: [],
            selectedGenre: ''
        };
    }

    getHashtags = () => { };
    getGenres = () => { };

    enteredKeyword = (event) => {
        console.error('inout change', event);

    }

    search = () => {
        console.error('search');
        //this.setState({ books: [{ Author: 'aa', Title: 'bb' }] });
        //this.setState({ showResults: true });

        this.setState({ loading: true });
        const data = {
            Keyword: this.state.searchKeyword,
            Hashtags: this.state.selectedHashtags.map(h => h.value),
            Genre: this.state.selectedGenre.value
        };
        console.error(data);
        //axios
        //    .post(HttpRequestPath + "api/BookSearch", data)
        //    .then(response => {
        //        console.error(response.data);
        //        this.setState({
        //            loading: false,
        //            books: response.data,
        //            showResults: true
        //        });
        //        this.render();
        //    })
        //    .catch(() => {
        //        this.setState({ loading: false });
        //        console.log("API error")
        //    }); //TODO error handling
    }

    handleSelectedHashtag = (event) => {
        this.setState({ selectedHashtags: event });
    };

    handleSelectedGenre = (event) => {
        this.setState({ selectedGenre: event });
    };

    handleKeywordChange = (event) => {
        this.setState({ searchKeyword: event.target.value });
    };

    render() {
        let $loadingIcon = null;
        let $table = null;
        let $genreSelection = null;
        let $hashtagSelection = null;

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

        if (this.state.genres.length !== 0) {
            $genreSelection = (
                <Select
                    options={this.state.genres}
                    onChange={this.handleSelectedGenre}
                    placeholder={'Select genre...'}
                />
            )
        }

        if (this.state.hashtags.length !== 0) {
            $hashtagSelection = (
                <Select
                    options={this.state.hashtags}
                    onChange={this.handleSelectedHashtag}
                    isMulti={true}
                    placeholder={'Select hashtags...'}
                />
            )
        }

        return (
            this.state.books != null && (
                <div className="boxQr">
                    <h3>Book Search</h3>
                    <br />
                    <div className="form-group">
                        <input
                            type="searchKeyword"
                            name="searchKeyword"
                            className="form-control"
                            placeholder="Enter search keyword..."
                            onChange={this.handleKeywordChange}
                        />
                    </div>
                    {$genreSelection}
                    {$hashtagSelection}
                    <button value="Search" onClick={this.search}>Search</button>
                    {$loadingIcon}
                    {$table}
                </div>
            )
        );
    }
}
