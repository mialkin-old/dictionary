import React, { Component } from 'react';
import { AutoComplete } from 'antd';

export class Searchbar extends Component {
    render() {
        return (
            <AutoComplete
                allowClear={true}
                dataSource={this.props.words}
                placeholder="Слово"
                onChange={this.props.onSearchbarChange}
                style={{ width: '100%', marginTop: 10 }} />);
    }
}