import React, {Component} from "react";
import { Link } from 'react-router-dom';

export class Navbar extends Component {
    render() {

        return (
            <div>
                <a href="/" >Main</a>
                <a href="/stats">Stats</a>.
                <Link to="/">Main</Link>
                <Link to="/stats">Items</Link>
            </div>
        );
    }
}