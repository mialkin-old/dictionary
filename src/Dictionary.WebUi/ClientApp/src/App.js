import React, {Component} from 'react';
import {Route} from 'react-router';
import {Layout} from './components/Layout';
import 'antd/dist/antd.css';
import './css/common.css'
import {Main} from './components/Main';
import {Login} from './components/Login';
import {Stats} from "./components/Stats";

export default class App extends Component {

    static displayName = App.name;

    state = {
        user: {
            isLoggedIn: undefined
        }
    }

    render() {

        if (this.state.user.isLoggedIn === true) {
            return (
                <Layout>
                    <Route
                        path='/'
                        render={(props) => (
                            <Main {...props} isLoggedIn={true}/>
                        )}/>
                    <Route path='/stats' component={Stats}/>
                </Layout>
            );
        }

        return (
            <Layout>
                <Route
                    path='/'
                    render={(props) => (
                        <Main {...props} isLoggedIn={false}/>
                    )}/>
                <Route path='/login' component={Login}/>
            </Layout>
        );
    }

    componentDidMount() {
        this.fetchUserInfo().then(() => {
        });
    }

    async fetchUserInfo() {
        let url = `api/account/info`;
        const response = await fetch(url);
        response.json().then(data => {
            if (data.isLoggedIn === true) {
                this.setState({
                    user: {
                        isLoggedIn: true
                    }
                })
            }
        });
    }
}
