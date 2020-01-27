import React, { Component } from 'react';
import { LanguagePicker } from './LanguagePicker';
import { Searchbar } from './Searchbar';
import { Input, Button } from 'antd';
const { TextArea } = Input;
import { Words } from './Words';

export class Main extends Component {

    state = {
        languageId: 2,
        searchTerm: '',
        saveButtonDisabled: true
    }

    constructor(props) {
        super(props);

        this.handleLanguageChange = this.handleLanguageChange.bind(this);
        this.handleSearchbarChange = this.handleSearchbarChange.bind(this);
    }

    render() {
        return (
            <div>
                <LanguagePicker
                    languageId={this.state.languageId}
                    onLanguageChange={this.handleLanguageChange} />
                <Searchbar onSearchbarChange={this.handleSearchbarChange}
                    onKeyDown={() => { debugger; }} />
                <Input style={{ marginTop: 10 }}
                    placeholder='Транскрипция' />
                <TextArea rows={5}
                    placeholder='Перевод'
                    style={{ marginTop: 10 }} />
                <Button style={{ marginTop: 10 }}
                    disabled={this.state.saveButtonDisabled}
                >Сохранить</Button>
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
        if (searchTerm === undefined)
            searchTerm = '';

        this.setState({
            searchTerm: searchTerm
        });
    }
}