import React, {Component} from 'react';

export class Auth extends Component {

    state = {
        login: '',
        password: ''
    };
    
    constructor(props) {
        super(props);

        this.handleLoginChange = this.handleLoginChange.bind(this);
        this.handlePasswordChange = this.handlePasswordChange.bind(this);
        this.handleLogin = this.handleLogin.bind(this);
    }

    render() {
        return (
            <div>
                <input id="login"
                       value={this.state.login}
                       onChange={this.handleLoginChange}
                       placeholder="Логин"/>
                <br/>
                <input id="password"
                       value={this.state.password}
                       onChange={this.handlePasswordChange}
                       placeholder="Пароль"/>
                <br/>
                <button onClick={this.handleLogin}>Войти</button>
            </div>);
    }

    handleLoginChange(e) {
        this.setState({
            password: this.state.password,
            login: e.target.value
        });
    }

    handlePasswordChange(e) {
        this.setState({
            login: this.state.login,
            password: e.target.value
        });
    }

    handleLogin() {
        alert("Login: " + this.state.login + "; Password: " + this.state.password)
    }
}