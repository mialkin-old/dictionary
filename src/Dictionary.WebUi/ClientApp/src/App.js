import React, {Component} from 'react';
import {Route} from 'react-router';
import {Layout} from './components/Layout';
import 'antd/dist/antd.css';
import './common.css'
import {Main} from './components/Main';

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Layout>
                <Route path='/' component={Main}/>
            </Layout>
        );
    }
}
