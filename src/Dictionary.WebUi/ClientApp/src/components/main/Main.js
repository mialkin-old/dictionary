import React, { Component } from 'react';
import { Words } from './Words';

export class Main extends Component {

    state = {
        languageId: 2,
        word: {
            id: null,
            name: '',
            transcription: '',
            translation: '',
        },
        words: []
    }

    constructor(props) {
        super(props);

        this.handleLanguageChange = this.handleLanguageChange.bind(this);
        this.handleNameChange = this.handleNameChange.bind(this);
        this.handleNameInputKeyDown = this.handleNameInputKeyDown.bind(this);
        this.handleTranscriptionChange = this.handleTranscriptionChange.bind(this);
        this.handleTranslationChange = this.handleTranslationChange.bind(this);

        this.handleSelectWord = this.handleSelectWord.bind(this);

        this.handleSave = this.handleSave.bind(this);
    }

    componentDidMount() {
        this.fetchWords();
    }

    render() {
        let saveDisabled =
            !(this.state.name.length > 0 && this.state.translation.length > 0);

        return (
            <div>
                <select id="language-select"
                    onChange={this.handleLanguageChange}>
                    <option value={2}>Français</option>
                    <option value={1}>English</option>
                    <option value={4}>Русский</option>
                </select>
                <input id="name"
                    onChange={(this.handleNameChange)}
                    onKeyDown={this.handleNameInputKeyDown}
                    placeholder="Слово"></input>
                <input id="transcription"
                    onChange={(this.handleTranscriptionChange)}
                    placeholder="Транскрипция"></input>
                <textarea id="translation"
                    placeholder="Перевод"
                    onChange={(this.handleTranslationChange)}
                    rows="5"></textarea>
                <button id="save-btn"
                    disabled={saveDisabled}
                    onClick={this.handleSave}>Сохранить</button>
                <Words words={this.state.words}
                    onWordSelect={this.handleSelectWord} />
            </div>);
    }

    handleLanguageChange(e) {
        this.setState({
            languageId: e.target.value
        }, () => {
            this.fetchWords();
        });
    }

    handleNameChange(e) {
        this.setState({
            name: e.target.value
        });
    }

    handleNameInputKeyDown(e) {
        if (e.keyCode === 27) {
            this.setState({
                name: ''
            });
        }
    }

    handleTranscriptionChange(e) {
        this.setState({
            word: {
                ...this.state.word,
                transcription: e.target.value
            }
        });
    }

    handleTranslationChange(e) {
        this.setState({
            translation: e.target.value
        });
    }

    handleSave() {
        fetch('word/create', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                LanguageId: this.state.languageId,
                Name: this.state.name,
                Transcription: this.state.transcription,
                Translation: this.state.translation
            })
        })
    }

    async fetchWords() {
        let url = `word/list?languageId=${this.state.languageId}&searchTerm=${this.state.name}`;

        const response = await fetch(url);
        const data = await response.json();

        this.setState({ words: data });
    }

    handleSelectWord(word) {
        debugger;
    }
}