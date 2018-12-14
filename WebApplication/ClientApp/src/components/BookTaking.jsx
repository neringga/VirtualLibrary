import React, { Component } from "react";
import QrReader from "react-qr-reader";

import axios from "axios";
import { HttpRequestPath } from "./Constants.jsx";
import { getProfile } from "./AuthService";
import { Input, Icon, Button } from "semantic-ui-react";
import { LinkContainer } from "react-router-bootstrap";
import LocalizedStrings from "react-localization";
import { getLanguage } from "./LangService";
import { string } from "prop-types";

let strings = new LocalizedStrings({
  en: {
    notExist: "This book does not exist!",
    return: "Return this book until",
    enjoy: "Enjoy reading!",
    returned: "Book returned!",
    like: "Did you like this book? ",
    leave: "Leave a comment",
    continue: "and help others decide if this book is worth reading!",
    review: "Add review",
    scan: "Scan book QR code",
  },
  lt: {
    notExist: "Ši knyga neegzistuoja",
    return: "Grąžinti knygą",
    enjoy: "Gero skaitymo!",
    returned: "Knyga grąžinta!",
    like: "Ar jums patiko ši knyga?",
    leave: "Palikite atsiliepimą",
    continue: "Padėkite kitiems nuspręsti ar ši knyga yra verta skaityti!",
    review: "Pridėti atsiliepimą",
    scan: "Nuskanuokite knygos QR kodą",
  }
});

export class BookTaking extends Component {
  constructor(props) {
    super(props);
    this.state = {
      delay: 500,
      showQrReader: true,
      returnError: false
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
      const book_data = {
        isbnCode: data,
        user: getProfile()
      };
      this.setState({
        book: data,
      });
      this.handleTakeOrReturn(book_data);
    }
  }

  handleTakeOrReturn(data) {
    axios.post(HttpRequestPath + "api/ReturnBook", data.isbnCode).then(response => {
      if (response.data) {
        axios.put(HttpRequestPath + "api/ReturnBook", data).then(response => {
          if (response.data) {
            this.setState({
              returned: true
            });
          } else {
            this.setState({
              returnError: true
            });
          }
        });
      } else {
        axios.put(HttpRequestPath + "api/TakenBook", data).then(response => {
          if (response.data) {
            this.setState({
              returnTime: response.data,
              showDate: true
            });
          } else {
            this.setState({
              returnError: true
            });
          }
        });
      }
    });
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

  handleNotReturning = err => {
    if (err) {
      return (
        <div className="boxQr">
          <h4>{strings.notExist}</h4>
          </div>
      );
    }
  };

  onInputChange = event => {
    this.setState({
      newReview: event.target.value
    });
  };

  showReturnDate = date => {
    if (date != null) {
      return (
        <div className="boxQr">
          <h4>
            {strings.return}
            <br />
            <b>{date}</b>
            <br />
            <br />
            {strings.enjoy}
          </h4>
        </div>
      );
    }
  };

  onReviewButtonClick = () => {
    const data = {
      BookCode: this.state.book,
      User: getProfile(),
      Review: this.state.newReview
    };

    this.setState({
      newReview: null
    });

    axios.put(HttpRequestPath + "api/Review", data).then(res => {
      if (res) {
        window.location = './books'
      }
    });
  };

  handleReturn = returnedBook => {
    if (returnedBook) {
      return (
        <div className="boxQr">
          <h4 className="lettrSpacing">{strings.returned}</h4>
          <h5 className="pMargin">
            {strings.like}<b>{strings.leave}</b> {strings.continue}
          </h5>
          <form id="myForm">
            <div className="commentInput">
              <Input onChange={this.onInputChange} fluid placeholder="Review" />
            </div>
          </form>
          <Button
            primary
            onClick={this.onReviewButtonClick}
            floated="right"
            size="large"
            icon
            labelPosition="left"
          >
            <Icon name="add" />
            {strings.review}
          </Button>
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
          <h3>{strings.scan}</h3>
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

  _onSetLanguageTo(lang) {
    strings.setLanguage(lang);
  }
  render() {
    const lang = getLanguage();
    return (
      this._onSetLanguageTo(lang),
      (
      <div>
        <center>
          {this.showQrReader(this.state.showQrReader)}
          {this.fallbackInCaseOfError(this.state.camError)}
          {this.showReturnDate(this.state.returnTime)}
          {this.handleReturn(this.state.returned)}
          {this.handleNotReturning(this.state.returnError)}
        </center>
      </div>)
    );
  }
}
