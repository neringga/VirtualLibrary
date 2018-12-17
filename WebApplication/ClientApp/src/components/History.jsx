import React, { Component } from "react";
import axios from "axios";
import { HttpRequestPath, BookHistoryApi } from "./Constants.jsx";
import { getProfile } from "./AuthService.jsx";
import "./Home.css";
import { BootstrapTable, TableHeaderColumn } from "react-bootstrap-table";
import LocalizedStrings from "react-localization";
import { getLanguage } from "./LangService";
import { Statistic } from "semantic-ui-react";

let strings = new LocalizedStrings({
  en: {
    history: "Your read books",
    title: "Title",
    author: "Author"
  },
  lt: {
    chooseBook: "Mano skaitytos knygos",
    title: "Pavadinimas",
    author: "Autorius"
  }
});

export class History extends Component {
  constructor(props) {
    super(props);
    this.state = {
      books: []
    };
  }

  componentDidMount() {
    axios.put(HttpRequestPath + BookHistoryApi, getProfile()).then(response => {
      if (response.data) {
        // console.log(Object.keys(response.data).length);
        this.setState({
          books: response.data
        });
      }
    });
  }

  render() {
    return (
      <div className="boxSearch">
        <h3 textColor="blue" className="spacingHome">
          {strings.history}
        </h3>

        <BootstrapTable search={true} data={this.state.books} hover>
          <TableHeaderColumn dataField="Title" isKey={true}>
            {strings.title}
          </TableHeaderColumn>
          <TableHeaderColumn dataField="Author">
            {strings.author}
          </TableHeaderColumn>
        </BootstrapTable>
        {/* <Statistic size="tiny">
          <Statistic.Value>
            {Object.keys(this.state.books).length}
          </Statistic.Value>
          <Statistic.Label>Book</Statistic.Label>
        </Statistic> */}
      </div>
    );
  }
}
