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
      <div>
        <form>
          <div className="form-group">
            <label for="exampleFormControlInput1">Email address</label>
            <input type="email" className="form-control" id="exampleFormControlInput1" placeholder="name@example.com" />
          </div>
          <div className="form-group">
            <label for="exampleFormControlSelect1">Example select</label>
            <select className="form-control" id="exampleFormControlSelect1">
              <option>1</option>
              <option>2</option>
              <option>3</option>
              <option>4</option>
              <option>5</option>
            </select>
          </div>
          <div className="form-group">
            <label for="exampleFormControlSelect2">Example multiple select</label>
            <select multiple className="form-control" id="exampleFormControlSelect2">
              <option>1</option>
              <option>2</option>
              <option>3</option>
              <option>4</option>
              <option>5</option>
            </select>
          </div>
          <div className="form-group">
            <label for="exampleFormControlTextarea1">Example textarea</label>
            <textarea className="form-control" id="exampleFormControlTextarea1" rows="3"></textarea>
          </div>
        </form>
        <table className='table table-striped' aria-labelledby="tabelLabel">
          <thead>
            <tr>
              <th>Name</th>
              <th>Transcription</th>
              <th>Translation</th>
            </tr>
          </thead>
          <tbody>
            {words.map(word =>
              <tr key={word.id}>
                <td>{word.name}</td>
                <td>{word.transcription}</td>
                <td>{word.translation}</td>
              </tr>
            )}
          </tbody>
        </table>
      </div>

    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : WordList.renderWordList(this.state.words);

    return (
      <div>
        <h1 id="tabelLabel" >Words</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }

  async fetchWords() {

    const response = await fetch('word/list?languageId=2');
    const data = await response.json();
    this.setState({ words: data, loading: false });
  }
}