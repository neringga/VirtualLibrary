import React, { Component } from "react";
import axios from "axios";
import { Table } from "react-bootstrap";

import { HttpRequestPath, bookListApi } from "./Constants";
import Select from 'react-select';

import LocalizedStrings from 'react-localization';
import { getLanguage } from "./AuthService";

let strings = new LocalizedStrings({
    en: {
        genreLooking: "Looking for a particular genre?",
        selectGenre: "'Select genre...'",
        bookSearch: "Book Search",
        hashtags: "Specify hashtags to match your interests",
        enteredKeyword: "Enter search keyword",
        searchKeyword: "{Search keyword", 
        search: "Search",
    },
    lt: {
        
    },

});

export class BookSearch extends Component {
    constructor() {
        super();
        this.state = {
            books: [],
            loading: false,
            showResults: false,
            searchKeyword: '',
            hashtags: [],
            genres: [],
            selectedHashtags: [],
            selectedGenre: ''
        };
        this.getHashtags();
    }

    getHashtags = () => {
        axios
            .get(HttpRequestPath + "api/Hashtag")
            .then(response => {
                console.error(response.data);
                const hstg = response.data.map(h => { return { value: h, label: h }; });
                this.setState({
                    hashtags: hstg,
                    loading: false
                });
                this.getGenres();
            });
    };

    getGenres = () => {
        axios
            .get(HttpRequestPath + "api/Genre")
            .then(response => {
                console.error(response.data);
                const gnr = response.data.map(g => { return { value: g, label: g }; });
                this.setState({
                    genres: gnr,
                    loading: false
                });
                this.render();
            });
    };

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
        axios
            .post(HttpRequestPath + "api/BookSearch", data)
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
            });
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

    _onSetLanguageTo(lang) {
        strings.setLanguage(lang);
    }

    render() {
        const lang = getLanguage();
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
                <div>
                    <div className="ui horizontal divider">{strings.genreLooking}</div>
                    <Select
                        options={this.state.genres}
                        onChange={this.handleSelectedGenre}
                        placeholder={strings.selectGenre}
                    />
                </div>
            )
        }

        if (this.state.hashtags.length !== 0) {
            $hashtagSelection = (
                <div>
                    <div className="ui horizontal divider">{strings.hashtags}</div>
                    <Select
                        options={this.state.hashtags}
                        onChange={this.handleSelectedHashtag}
                        isMulti={true}
                        placeholder={strings.selectGenre}
                    />
                </div>
            )
        }

        var topMargin = {
           'margin-top': '20px'
        };

        return (
            this._onSetLanguageTo(lang),
            this.state.books != null && (
                <div className="boxQr">
                    <h3>{strings.bookSearch}</h3>
                    <br />
                    <div className="ui horizontal divider">{strings.enteredKeyword}</div>
                    <div className="form-group">
                        <input
                            type={strings.searchKeyword}
                            name={strings.searchKeyword}
                        className="form-control"
                            placeholder={strings.enteredKeyword}
                            onChange={this.handleKeywordChange}
                        />
                    </div>
                    {$genreSelection}
                    {$hashtagSelection}
                    <button style={topMargin} className="ui fluid secondary large button" value="Search" onClick={this.search}>{strings.search}</button>
                    {$loadingIcon}
                    {$table}
                </div>
            )
        );
    }
}
