import React, {Component} from 'react';
import {Navbar} from "./Navbar";

export class Layout extends Component {
    static displayName = Layout.name;

    render() {
        return (
            <div className="dict-container">
                <Navbar/>
                {this.props.children}
            </div>
        );
    }
}
