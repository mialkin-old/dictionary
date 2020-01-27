import React, { Component } from 'react';

export class Words extends Component {

    state = {
        words: []
    };

    constructor(props) {
        super(props);
        this.fetchWords = this.fetchWords.bind(this);
    }

    componentDidMount() {
        this.fetchWords();
    }

    componentDidUpdate(prevProps) {
        if (this.props.languageId !== prevProps.languageId) {
            this.fetchWords();
        }

        if (this.props.searchTerm !== prevProps.searchTerm) {
            this.fetchWords();
        }
    }

    render() {
        return (
            <div>
                Список из {this.state.words.length} слов.
                <div className="word-list">
                    {this.state.words.map(word =>
                        <div key={word.wordId} className="word-in-list">
                            <b>{word.name}</b> /{word.transcription}/ — {word.translation}
                        </div>
                    )}
                </div>
            </div>);
    }

    async fetchWords() {
        const response = await fetch(`word/list?languageId=${this.props.languageId}&SearchTerm=${this.props.searchTerm}`);
        const data = await response.json();
        this.setState({ words: data });
    }
}