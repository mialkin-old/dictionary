import React, { Component } from 'react';
import { Words } from './Words';

export class Main extends Component {

    state = {
        languageId: 2,
        word: '',
        saveButtonDisabled: true
    }

    constructor(props) {
        super(props);

        this.handleLanguageChange = this.handleLanguageChange.bind(this);
        this.handleSearchbarChange = this.handleSearchbarChange.bind(this);
        this.handleSearchbarKeyDown = this.handleSearchbarKeyDown.bind(this);
    }

    render() {
        return (
            <div>
                <select id="language-select"
                    onChange={this.handleLanguageChange}>
                    <option value={2}>Français</option>
                    <option value={1}>English</option>
                    <option value={4}>Русский</option>
                </select>
                <input id="word"
                    value={this.state.word}
                    onChange={this.handleSearchbarChange}
                    onKeyDown={this.handleSearchbarKeyDown}
                    placeholder="Слово"></input>
                <input id="transcription"
                    placeholder="Транскрипция"></input>
                <textarea id="translation"
                    placeholder="Перевод"
                    rows="5"></textarea>
                <button id="save-btn"
                    disabled={this.state.saveButtonDisabled}>Сохранить</button>
                <Words
                    languageId={this.state.languageId}
                    searchTerm={this.state.word} />
            </div>);
    }

    handleLanguageChange(e) {
        this.setState({
            languageId: e.target.value
        });
    }

    handleSearchbarChange(e) {
        this.setState({
            word: e.target.value
        });
    }

    handleSearchbarKeyDown(e) {
        if (e.keyCode === 27) {
            this.setState({
                word: ''
            });
        }
    }
}