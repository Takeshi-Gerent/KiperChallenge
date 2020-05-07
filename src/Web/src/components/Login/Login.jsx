import React, { useState, useContext } from 'react';
import { useHistory } from 'react-router-dom'
import StoreContext from 'components/Store/Context'
import axios from 'axios';

import './Login.css';

function initialState() {
    return { user: '', password: '' };
}

const login = async({ user, password }) => {    
    const data = { login: user, password: password };
    let result = await axios({
        method: 'post',
        headers: { 'Content-Type': 'application/json-patch+json' },
        url: process.env.REACT_APP_AUTH_URL,
        data: data
    });
    return result;
        
}

const UserLogin = () => {
    const [values, setValues] = useState(initialState);
    const [error, setError] = useState(null);
    const { setToken } = useContext(StoreContext);
    const history = useHistory();

    function onChange(event) {
        const { value, name } = event.target;

        setValues({
            ...values,
            [name]: value
        });
    }

    function onSubmit(event) {
        event.preventDefault();
        
        login(values)
            .then((response) => {
                setToken(response.data.token);
                return history.push('/');
            })
            .catch((error) => {
                console.log(error.response);
                setError(error.response.data.message);
                setValues(initialState);
            });        
    }

    return (
        <div className="user-login">            
            <h1 className="user-login__title">Controle de condomínio</h1>
            <form onSubmit={onSubmit}>
                <div className="user-login__form-control">
                    <label htmlFor="user">Usuário</label>
                    <input
                        id="user"
                        type="text"
                        name="user"
                        onChange={onChange}
                        value={values.user}
                    />
                </div>
                <div className="user-login__form-control">
                    <label htmlFor="password">Senha</label>
                    <input
                        id="password"
                        type="password"
                        name="password"
                        onChange={onChange}
                        value={values.password}
                    />
                </div>
                {error && (
                    <div className="user-login__error">{error}</div>
                )}
                <button type="submit" className="user-login__submit-button">Login</button>        
            </form>
        </div>
    );
};

export default UserLogin;