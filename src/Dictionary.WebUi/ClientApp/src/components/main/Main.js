import React, { Component } from 'react';
import { Words } from './Words';

export class Main extends Component {

    state = {
        languageId: 2,
        word: {
            id: null,
            name: '',
            gender: null,
            transcription: '',
            translation: '',
        },
        words: []
    }

    constructor(props) {
        super(props);

        this.handleLanguageChange = this.handleLanguageChange.bind(this);
        this.handleNameChange = this.handleNameChange.bind(this);
        this.handleTranscriptionChange = this.handleTranscriptionChange.bind(this);
        this.handleTranslationChange = this.handleTranslationChange.bind(this);

        this.handleSelectWord = this.handleSelectWord.bind(this);

        this.handleSave = this.handleSave.bind(this);
        this.create = this.create.bind(this);
        this.update = this.update.bind(this);

        this.clean = this.clean.bind(this);
        this.escFunction = this.escFunction.bind(this);
    }

    escFunction() {
        this.clean('');
    }

    componentDidMount() {
        document.addEventListener("keydown", this.escFunction, false);

        this.fetchWords();
    }

    componentWillUnmount() {
        document.removeEventListener("keydown", this.escFunction, false);
    }

    render() {
        let saveDisabled =
            !(this.state.word.name.length > 0 && this.state.word.translation.length > 0);

        return (
            <div>
                <select id="language-select"
                    onChange={this.handleLanguageChange}>
                    <option value={2}>Français</option>
                    <option value={1}>English</option>
                    <option value={4}>Русский</option>
                </select>
                <input id="name"
                    value={this.state.word.name}
                    onChange={(this.handleNameChange)}
                    placeholder="Слово"></input>
                <input id="transcription"
                    value={this.state.word.transcription}
                    onChange={(this.handleTranscriptionChange)}
                    placeholder="Транскрипция"></input>
                <textarea id="translation"
                    value={this.state.word.translation}
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
        this.clean(e.target.value);
    }

    handleTranscriptionChange(e) {
        debugger;
        this.setState({
            word: {
                ...this.state.word,
                transcription: e.target.value
            }
        });
    }

    handleTranslationChange(e) {
        this.setState({
            word: {
                ...this.state.word,
                translation: e.target.value
            }
        });
    }

    handleSave() {
        this.state.word.id == null ?
            this.create() :
            this.update();
    }

    async create() {
        const response = await fetch('word/create', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                LanguageId: this.state.languageId,
                Name: this.state.word.name,
                Transcription: this.state.word.transcription,
                Translation: this.state.word.translation
            })
        });

        const data = await response.json();

        debugger;
    }

    async update() {
        const response = await fetch('word/update', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                WordId: this.state.word.id,
                LanguageId: this.state.languageId,
                Name: this.state.word.name,
                Transcription: this.state.word.transcription,
                Translation: this.state.word.translation
            })
        });

        const data = await response.json();

        debugger;
    }

    clean(val) {
        this.setState({
            word: {
                id: null,
                name: val,
                gender: null,
                transcription: '',
                translation: ''
            }
        }, () => {
            this.fetchWords();
        });
    }

    async fetchWords() {
        let url = `word/list?languageId=${this.state.languageId}&searchTerm=${this.state.word.name}`;

        const response = await fetch(url);
        const data = await response.json();

        this.setState({ words: data });
    }

    handleSelectWord(word) {
        debugger;
        this.setState({
            word: {
                id: word.wordId,
                name: word.name,
                gender: word.genderId,
                transcription: word.transcription,
                translation: word.translation
            },
            words: []
        });
    }
}