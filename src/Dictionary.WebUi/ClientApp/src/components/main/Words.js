import React, { Component } from 'react';

export class Words extends Component {
    render() {
        return (
            <div>
                <div className="word-list">
                    {this.props.words.map(word => {
                        let transcription = '';
                        if (word.transcription != '') {
                            transcription = ` /${word.transcription}/`;
                        }

                        return <div key={word.wordId}
                            className="word-in-list">
                            <span
                                className='word'
                                onClick={() => { this.props.onWordSelect(word); }}
                            >{word.name}</span>{transcription} — {word.translation}
                        </div>
                    }
                    )}
                </div>
            </div>);
    }
}