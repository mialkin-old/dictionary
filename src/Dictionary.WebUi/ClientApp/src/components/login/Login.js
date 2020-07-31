import React, {Component} from 'react';
import './login.css'

export class Login extends Component {

    state = {
        username: '',
        password: ''
    };

    constructor(props) {
        super(props);

        this.handlePasswordChange = this.handlePasswordChange.bind(this);
        this.handleUsernameChange = this.handleUsernameChange.bind(this);
        this.handleSignIn = this.handleSignIn.bind(this);
    }

    render() {
        return (
            <div>
                <div className='login-wrapper'>
                    <input id="username"
                           type="text"
                           value={this.state.username}
                           onChange={this.handleUsernameChange}
                           placeholder="Username"/>
                </div>
                <div className='password-wrapper'>
                    <input id="password"
                           type="password"
                           value={this.state.password}
                           onChange={this.handlePasswordChange}
                           placeholder="Password"/>
                </div>
                <button onClick={this.handleSignIn}>Sign in</button>
            </div>);
    }

    handleUsernameChange(e) {
        this.setState({
            username: e.target.value
        });
    }

    handlePasswordChange(e) {
        this.setState({
            password: e.target.value
        });
    }

    async handleSignIn() {
        const response = await fetch('api/account/logIn', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded'
            },
            body: `password=${this.state.password}&username=${this.state.username}`
        }).then(response => response.json())
            .then(data => {
                if (data.success === true) {
                    window.location.replace("/");
                } else {
                    alert(data.errorMessage)
                }
            })
    }
}