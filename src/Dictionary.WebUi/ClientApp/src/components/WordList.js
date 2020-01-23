import React, { Component } from 'react';

export class WordList extends Component {

  constructor(props) {
    super(props);
    this.state = { words: [], loading: true };
  }

  componentDidMount() {
    this.fetchWords();
  }

  static renderWordList(words) {
    return (
      <div className="word-list">
        {words.map(word =>
          <div key={word.wordId} className="word-in-list">
            <b>{word.name}</b> /{word.transcription}/ — {word.translation}
          </div>
        )}
      </div>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : WordList.renderWordList(this.state.words);

    return (
      <div>
        {contents}
      </div>
    );
  }

  async fetchWords() {

    const response = await fetch(`word/list?languageId=${this.props.languageId}`);
    const data = await response.json();
    this.setState({ words: data, loading: false });
  }
}