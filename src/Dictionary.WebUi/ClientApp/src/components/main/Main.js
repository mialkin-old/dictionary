import React, { Component } from 'react';
import { Searchbar } from './Searchbar';
import { Words } from './Words';
import { LanguagePicker } from './LanguagePicker';

export class Main extends Component {

    state = {
        languageId: 2,
        searchTerm: ''
    }

    constructor(props) {
        super(props);

        this.handleLanguageChange = this.handleLanguageChange.bind(this);
        this.handleSearchbarChange = this.handleSearchbarChange.bind(this);
    }

    render() {
        return (
            <div>
                Добро пожаловать {this.state.languageId}!<br />
                <LanguagePicker
                    languageId={this.state.languageId}
                    onLanguageChange={this.handleLanguageChange} />
                <Searchbar onSearchbarChange={this.handleSearchbarChange} />
                <Words
                    languageId={this.state.languageId}
                    searchTerm={this.state.searchTerm} />
            </div>);
    }

    handleLanguageChange(id) {
        this.setState({
            languageId: id
        });
    }

    handleSearchbarChange(searchTerm) {
        this.setState({
            searchTerm: searchTerm
        });;
    }
}