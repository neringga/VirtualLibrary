import React, { Component } from 'react';
import axios from 'axios';
import {
    HttpRequestPath,
    bookActionsApi
} from './Constants.jsx';

export class BookTaking extends Component {

    constructor(props) {
        super(props);

        this.state = {
            file: null,
            imagePreviewUrl: null,
            recongnizedBook: null
        };
    }

    fileChangedHandler = (event) => {

        // this.state.file = file;
        const file = event.target.files[0]
        console.log(file);

        let reader = new FileReader();

        reader.onloadend = () => {
            this.setState({
                file: file,
                imagePreviewUrl: reader.result,
            });
        }
        reader.readAsDataURL(file);
    }


    uploadHandler = () => {
        console.log(this.currentImage);
        const url = HttpRequestPath + bookActionsApi + 'TakenBook';
        console.log(url);
        const data = this.state.file;
        //axios.put(url, data).then(response => {

        //});
        this.setState({ recongnizedBook: 'Some book title' });
        this.render();
    }

    takeBookHandler = () => {
        alert('The book has been taken successfully');
    }

    render() {
        let { imagePreviewUrl } = this.state;
        let $imagePreview = null;
        if (imagePreviewUrl) {
            $imagePreview = (<div className="imgPreview"><img src={imagePreviewUrl} height="200" width="200" /></div>);
        } else {
            $imagePreview = (<div className="previewText">Please select an Image for Preview</div>);
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
            $recognizedImage = (<div>Not recognized</div>);
        }

        return (

            <div className="container">
                <div className="box">
                    <h2>Take a book</h2>
                    <input type="file" onChange={this.fileChangedHandler} />
                    <div>
                        {$imagePreview}
                    </div>
                    <button className="button" onClick={this.uploadHandler}>
                        Upload
					</button>
                    <div>
                        {$recognizedImage}
                    </div>
                </div>
            </div>
        );
    }
}

