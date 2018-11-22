import React, { Component } from "react";
import QrReader from "react-qr-reader";

export class qrReader extends Component {

    constructor(props){
        super(props)
        this.state = {
            delay: 100,
            result: 'No result',
            // error: false,
        }

        this.handleScan = this.handleScan.bind(this);
        this.handleError = this.handleError.bind(this);
    }
    handleScan(data){
        this.setState({
            result: data,
        })
    }
    handleError(err){
        // this.setState({
        //   error: true,
        // })
    }
    openImageDialog() {
        this.refs.qrReader.openImageDialog()
    }

    render(){
        const previewStyle = {
            height: 250,
            width: 450,
            marginTop: 20,
        }
        // let $imageSelector = null;     //TODO image upload fix
        // if (this.state.error) {
        //   $imageSelector = (
        //     <input type="button" value="Submit QR Code" onClick={this.openImageDialog.bind(this)} />
        //   );
        // }
        return(
            <div>
              <center>
                <div>
                <QrReader ref="qrReader"
                    delay={this.state.delay}
                    style={previewStyle}
                    onError={this.handleError}
                    onScan={this.handleScan}
                    // legacyMode={this.error}
                />
                </div>
                <br/>
                {/* <div className="belowCamera">{$imageSelector}</div> */}
                {/* <br/> */}
                <p className="belowCamera">{this.state.result}</p>
                </center>
            </div>
        )
    }
}