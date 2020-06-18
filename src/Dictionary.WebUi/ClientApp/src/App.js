import React, {Component} from 'react';
import {Route} from 'react-router';
import {Layout} from './components/Layout';
import 'antd/dist/antd.css';
import './css/common.css'
import {Main} from './components/Main';
import {Login} from './components/Login';

export default class App extends Component {
    
    static displayName = App.name;

    render() {  
        return (
            <Layout>
                <Route exact path='/' component={Main}/>
                <Route path='/login' component={Login}/>
            </Layout>
        );
    }
}
