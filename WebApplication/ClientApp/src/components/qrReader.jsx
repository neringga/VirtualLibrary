import React, { Component } from "react";
import QrReader from "react-qr-reader";

import axios from "axios";
import { HttpRequestPath, bookActionsApi } from "./Constants.jsx";

export class qrReader extends Component {
  constructor(props) {
    super(props);
    this.state = {
      // result: 'No result',
    };

    this.handleScan = this.handleScan.bind(this);
    this.handleError = this.handleError.bind(this);
  }

  // componentDidMount() {
  //     MediaDevices.ondevicechange += this.handleCameraChange
  //     window.addEventListener('', this.handleCameraChange)
  // }

  // componentWillUnmount() {
  //     MediaDevices.ondevicechange += this.handleCameraChange
  //     window.removeEventListener('', this.handleCameraChange)
  // }

  // handleCameraChange = (event) => {
  //     console.log(event)
  // }

  handleScan(data) {
    if (data != null) {
      console.log(data);
      this.setState({
        loading: true
      });
      axios.post(HttpRequestPath + bookActionsApi, data).then(response => {
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
            value="Submit QR Code"
            onClick={this.openImageDialog.bind(this)}
          />
        </div>
      );
    }
  };

  handleLoading = isLoading => {
    if (isLoading) {
      return <div className="ui active centered inline loader" />;
    } else {
      return null;
    }
  };

  showBook = book => {
    if (book != null) {
      return (
        <div>
          <p> Do you really want to take {book.Title + "" + book.Author} ? </p>
        </div>
      );
    }
  };

  render() {
    const previewStyle = {
      height: 250,
      width: 450,
      marginTop: 20
    };

    const delay = 100;
    return (
      <div>
        <center>
          <div>
            <QrReader
              ref="qrReader"
              delay={delay}
              style={previewStyle}
              onError={this.handleError}
              onScan={this.handleScan}
              legacyMode={this.state.camError}
            />
          </div>
          <br />
          {this.fallbackInCaseOfError(this.state.camError)}
          <br />
          <p className="belowCamera">
            {this.handleLoading(this.state.isLoading)}
            {this.showBook(this.state.book)}
          </p>
        </center>
      </div>
    );
  }
}
