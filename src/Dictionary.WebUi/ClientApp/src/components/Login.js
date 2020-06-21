import React, {Component} from 'react';

export class Login extends Component {

    state = {
        password: ''
    };

    constructor(props) {
        super(props);

        this.handlePasswordChange = this.handlePasswordChange.bind(this);
        this.handleSignIn = this.handleSignIn.bind(this);
    }

    render() {
        return (
            <div>
                <input id="password"
                       type="password"
                       value={this.state.password}
                       onChange={this.handlePasswordChange}
                       placeholder="Пароль"/>
                <button onClick={this.handleSignIn}>Войти</button>
            </div>);
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
            body: `password=${this.state.password}`
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