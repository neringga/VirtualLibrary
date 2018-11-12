import React, { Component } from "react";
import axios from "axios";
import {
  HttpRequestPath,
  bookActionsApi,
  BookTakingApi
} from "./Constants.jsx";
import "./Home.css";

export class BookTaking extends Component {
  constructor(props) {
    super(props);

    this.state = {
      file: null,
      imagePreviewUrl: null,
      recongnizedBook: null,
      returnTime: null,
      book: null
    };
  }

  fileChangedHandler = event => {
    // this.state.file = file;
    const file = event.target.files[0];
    console.log(file);

    let reader = new FileReader();

    reader.onloadend = () => {
      this.setState({
        file: file,
        imagePreviewUrl: reader.result
      });
    };
    reader.readAsDataURL(file);
  };

  uploadHandler = () => {
    const data = new FormData();
    data.append("image", this.state.file, this.state.file.name);
    const url = HttpRequestPath + bookActionsApi;
    axios.post(url, data).then(response => {
      console.log(response.data);
      this.setState({
        recongnizedBook: response.data.Author + " " + response.data.Title,
        book: response.data
      });
      this.render();
    });
  };

  takeBookHandler = () => {
    const data = this.state.book;
    console.log(data);
    axios.put(HttpRequestPath + BookTakingApi, data).then(response => {
      console.log(response.data);
      this.setState({ returnTime: response.data });
      this.render();
    });
  };

  render() {
    let { imagePreviewUrl } = this.state;
    let $imagePreview = null;
    if (imagePreviewUrl) {
      $imagePreview = (
        <div className="imgPreview">
          <img src={imagePreviewUrl} height="200" width="200" />
        </div>
      );
    } else {
      $imagePreview = (
        <div className="previewText">Please select an Image for Preview</div>
      );
    }

    let $recognizedImage = null;
    if (this.state.recongnizedBook !== null) {
      $recognizedImage = (
        <div>
          <div>Recognized book: {this.state.recongnizedBook}</div>
          <button className="button" onClick={this.takeBookHandler}>
            Take this book
          </button>
        </div>
      );
    } else {
      $recognizedImage = <div>Not recognized</div>;
    }

    let $returnTime = null;
    if (this.state.returnTime !== null) {
      $returnTime = (
        <div>
          <div>Return this book until : {this.state.returnTime}</div>
        </div>
      );
    } else {
      $returnTime = <div>Cannot return this book</div>;
    }

    return (
      <div className="box">
      <center>
        <h2>Take a book</h2>
        <input type="file" onChange={this.fileChangedHandler} />
        <div>{$imagePreview}</div>
        <button className="button" onClick={this.uploadHandler}>
          Upload
        </button>
        <div>{$recognizedImage}</div>
        <div>{$returnTime}</div>
        </center>
      </div>
    );
  }
}
