import React, {Component} from 'react';
import {Route, Switch} from 'react-router-dom';
import {Layout} from './components/Layout';
import './css/common.css'
import {Main} from './components/Main';
import {Login} from './components/login/Login';
import {NotFound} from "./components/NotFound";

export default class App extends Component {
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

    async componentDidMount() {
        await this.fetchUserInfo();
    }

    async fetchUserInfo() {
        const response = await fetch('api/v1/account/info');
        const data = await response.json();

        if (data.isLoggedIn === true) {
            this.setState({
                user: {
                    isLoggedIn: true
                }
            })
        }
    }
}
