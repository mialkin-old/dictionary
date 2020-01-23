import React, { Component } from 'react';
import { Searchbar } from './Searchbar';
import { Words } from './Words';
import { LanguagePicker } from './LanguagePicker';

export class Main extends Component {

    state = {
        languageId: 2
    }

    constructor(props) {
        super(props);

        this.handleLanguageChange = this.handleLanguageChange.bind(this);
    }

    render() {
        return (
            <div>
                Добро пожаловать {this.state.languageId}!<br />
                <LanguagePicker
                    languageId={this.state.languageId}
                    onLanguageChange={this.handleLanguageChange} />
                <Searchbar />
                <Words languageId={this.state.languageId} />
            </div>);
    }

    handleLanguageChange(id) {
        this.setState({
            languageId: id
        });
    }
}