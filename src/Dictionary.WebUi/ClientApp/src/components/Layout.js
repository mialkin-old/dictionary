import React, { Component } from 'react';

export class Layout extends Component {
  static displayName = Layout.name;

  render() {
    return (
      <div className="dict-container">
        {/* <NavMenu /> */}
        {this.props.children}
      </div>
    );
  }
}
