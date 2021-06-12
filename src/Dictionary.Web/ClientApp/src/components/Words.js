import React, {Component} from 'react';

export class Words extends Component {
    render() {
        return (
            <div>
                <div className="word-list">
                    {this.props.words.map(word => {
                            let transcription = '';

                            if (word.transcription !== null) {
                                transcription = <div className="transcription-container">/<span
                                    className="transcription">{word.transcription}</span>/</div>
                            }

                            let gender = '';
                            if (word.genderId > 0) {
                                if (word.genderId === 1) {
                                    gender = <span className="gender">m</span>;
                                } else if (word.genderId === 2) {
                                    gender = <span className="gender">f</span>;
                                }
                            }

                            return <div key={word.wordId}
                                        className="word-in-list">
                            <span
                                className='word'
                                onClick={() => {
                                    this.props.onWordSelect(word);
                                }}
                            >{word.name}</span> {transcription} — {gender}{word.translation}<sub className='created'
                                                                                                 title='Год добавления слова в словарь'>{word.created}</sub>
                            </div>
                        }
                    )}
                </div>
            </div>);
    }
}