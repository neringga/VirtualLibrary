import React, { Component } from "react";
import QrReader from "react-qr-reader";

import axios from "axios";
import { HttpRequestPath } from "./Constants.jsx";

export class BookTaking extends Component {
  constructor(props) {
    super(props);
    this.state = {
      delay: 500,
      showQrReader: true
    };

    this.handleScan = this.handleScan.bind(this);
    this.handleError = this.handleError.bind(this);
  }

  handleScan(data) {
    if (data != null) {
      this.setState({
        loading: true,
        showQrReader: false,
        camError: false
      });
      const isbn = {
        isbnCode: data
      };
      axios.put(HttpRequestPath + "api/BarcodeScanner", isbn).then(response => {
        this.setState({
          book: response.data,
          loading: false
        });
      });
    }
  }

  handleError(err) {
    this.setState({
      camError: true
    });
  }
  openImageDialog() {
    this.refs.qrReader.openImageDialog();
  }

  fallbackInCaseOfError = isError => {
    if (isError) {
      return (
        <div className="belowCamera">
          <input
            type="button"
            value="Upload QR Code"
            onClick={this.openImageDialog.bind(this)}
          />
        </div>
      );
    } else {
      return null;
    }
  };

  handleLoading = isLoading => {
    if (isLoading) {
      return <div className="ui active centered inline loader" />;
    } else {
      return null;
    }
  };

  handleBookTaking = event => {
    axios
      .put(HttpRequestPath + "api/TakenBook", this.state.book)
      .then(response => {
        this.setState({
          returnTime: response.data,
          showDate: true,
          book: null
        });
      });
  };

  showBook = book => {
    if (book != null) {
      return (
        <div className="boxQr">
          <h4>
            Do you really want to take <br />
            <b>{book.Author + " " + book.Title}</b> ?
          </h4>
          <br/>
          <div className="ui buttons">
            <button className="ui  big button" role="button" onClick={this.handleBookTaking}>
              Yes
            </button>
            <div className="or" />
            <button className="ui big positive button" role="button">
              No
            </button>
          </div>
        </div>
      );
    } else {
      return null;
    }
  };

  showReturnDate = date => {
    if (date != null) {
      return (
        <div className="boxQr">
          <h4>
            Return this book until 
            <br/>
            <b>{date}</b>
            <br />
            <br/>
            Enjoy reading!
          </h4>
        </div>
      );
    }
  };

  showQrReader = showReader => {
    if (showReader) {
      const previewStyle = {
        height: 230,
        width: 400,
        marginTop: 20
      };
      return (
        <div>
          <h3>Scan book QR code</h3>
          <QrReader
            ref="qrReader"
            delay={this.state.delay}
            style={previewStyle}
            onError={this.handleError}
            onScan={this.handleScan}
            legacyMode={this.state.camError}
          />
        </div>
      );
    } else {
      return null;
    }
  };

  render() {
    return (
      <div>
        <center>
          {this.showQrReader(this.state.showQrReader)}
          <br />
          {this.fallbackInCaseOfError(this.state.camError)}
          <br />
          {this.handleLoading(this.state.isLoading)}
          {this.showBook(this.state.book)}
          {this.showReturnDate(this.state.returnTime)}
        </center>
      </div>
    );
  }
}
