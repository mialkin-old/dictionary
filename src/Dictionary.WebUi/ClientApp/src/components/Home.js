import React, { Component } from 'react';
import { WordList } from './WordList';

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <div>
        <WordList />
      </div>
    );
  }
}
