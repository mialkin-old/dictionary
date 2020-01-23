import React, { Component } from 'react';
import { Select } from 'antd';

const { Option } = Select;

export class LanguagePicker extends Component {

    constructor(props){
        super(props);

        this.handleLanguageChange = this.handleLanguageChange.bind(this);
    }

    render() {
        return (
            <div>
                <Select defaultValue={this.props.languageId}
                    style={{ width: '100%' }}
                    onChange={this.handleLanguageChange}>
                    <Option value={2}>Français</Option>
                    <Option value={1}>English</Option>
                    <Option value={4}>Русский</Option>
                </Select>
            </div>);
    }

    handleLanguageChange(id) {
        this.props.onLanguageChange(id);
    }
}