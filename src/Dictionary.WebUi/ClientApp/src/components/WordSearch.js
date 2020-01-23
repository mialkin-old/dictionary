import { AutoComplete } from 'antd';
import React, { Component } from 'react';

export class WordSearch extends Component {

    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div>
                <AutoComplete
                    allowClear={true}
                    dataSource={this.state.dataSource}
                    placeholder="Слово" />
            </div>
        );
    }
}