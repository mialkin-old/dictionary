import React, {Component} from 'react';
import {Route, Switch} from 'react-router-dom';
import {Layout} from './components/Layout';
import 'antd/dist/antd.css';
import './css/common.css'
import {Main} from './components/Main';
import {Login} from './components/login/Login';
import {NotFound} from "./components/NotFound";

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
                    <Switch>
                        <Route path='/'
                               exact={true}
                               render={(props) => (
                                   <Main {...props} isLoggedIn={true}/>
                               )}/>
                        <Route path="*"
                               exact={true}
                               component={NotFound}/>
                    </Switch>
                </Layout>
            );
        }

        return (
            <Layout>
                <Switch>
                    <Route
                        path='/'
                        exact={true}
                        render={(props) => (
                            <Main {...props} isLoggedIn={false}/>
                        )}/>
                    <Route path='/login' component={Login}/>
                    <Route path="*"
                           exact={true}
                           component={NotFound}/>
                </Switch>
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
