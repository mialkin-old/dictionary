import React, { Component } from 'react';
import { WordList } from './WordList';
import { WordSearch } from './WordSearch';
import { Input, Select, Checkbox } from 'antd';

const { TextArea } = Input;
const { Option } = Select;


const CheckboxGroup = Checkbox.Group;

const plainOptions = ['Apple', 'Pear', 'Orange'];
const defaultCheckedList = ['Apple', 'Orange'];

function handleChange(value) {
  console.log(`selected ${value}`);
}


export class Home extends Component {
  static displayName = Home.name;

  state = {
    checkedList: defaultCheckedList,
    indeterminate: true,
    checkAll: false,
  };

  onChange = checkedList => {
    this.setState({
      checkedList,
      indeterminate: !!checkedList.length && checkedList.length < plainOptions.length,
      checkAll: checkedList.length === plainOptions.length,
    });
  };

  onCheckAllChange = e => {
    this.setState({
      checkedList: e.target.checked ? plainOptions : [],
      indeterminate: false,
      checkAll: e.target.checked,
    });
  };

  render() {
    return (
      <div>
        <Select defaultValue="fr" style={{ width: 120 }} onChange={handleChange}>
          <Option value="fr">Français</Option>
          <Option value="en">English</Option>
          <Option value="ru">Русский</Option>
        </Select>
        <WordSearch />
        <Input placeholder="Транскрипция" />
        <div>
          <div style={{ borderBottom: '1px solid #E9E9E9' }}>
            <Checkbox
              indeterminate={this.state.indeterminate}
              onChange={this.onCheckAllChange}
              checked={this.state.checkAll}
            >
              Check all
          </Checkbox>
          </div>
          <br />
          <CheckboxGroup
            options={plainOptions}
            value={this.state.checkedList}
            onChange={this.onChange}
          />
        </div>
        <TextArea placeholder="Перевод" rows={4} />
        <WordList />
      </div >
    );
  }
}
