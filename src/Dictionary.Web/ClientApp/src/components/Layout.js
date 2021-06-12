import React, {Component} from 'react';

export class Layout extends Component {
    static displayName = Layout.name;

    render() {
        return (
            <div className="dict-container">
                {this.props.children}
            </div>
        );
    }
}
