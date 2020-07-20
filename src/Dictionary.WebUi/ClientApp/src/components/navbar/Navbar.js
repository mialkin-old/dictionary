import React, {Component} from "react";
import { Link } from 'react-router-dom';
import './navbar.css'

export class Navbar extends Component {
    render() {

        return (
            <div className={'navbar'}>
                <Link to="/">Main</Link>
                <Link to="/stats">Statistics</Link>
            </div>
        );
    }
}