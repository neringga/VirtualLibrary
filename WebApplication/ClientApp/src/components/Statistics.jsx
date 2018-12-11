import React, { Component } from 'react';
import './Home.css';

import LocalizedStrings from 'react-localization';
import { setLanguage } from "./AuthService";

let strings = new LocalizedStrings({
    en: {
        statistics: "Your statistics",
    },
    lt: {
        statistics: "Jūsų statistika"
    }
});

export class Statistics extends Component {
    _onSetLanguageTo(lang) {
        strings.setLanguage(lang);
    }
    render() {
        const lang = getLanguage();
        return (
            this._onSetLanguageTo(lang),
            <div>
                <h3>Your statistics</h3>
            </div>
        );
    }
}