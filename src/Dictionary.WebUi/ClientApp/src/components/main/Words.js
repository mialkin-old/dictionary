import React, { Component } from 'react';

export class Words extends Component {
    render() {
        return (
            <div>
                <div className="word-list">
                    {this.props.words.map(word =>
                        <div key={word.wordId} className="word-in-list">
                            <span className='word'>{word.name}</span> /{word.transcription}/ — {word.translation}
                        </div>
                    )}
                </div>
            </div>);
    }
}