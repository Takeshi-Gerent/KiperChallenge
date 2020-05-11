import React, { useState, useContext } from 'react'
import { useHistory } from 'react-router-dom'
import { Button, FormGroup, FormControl, FormLabel } from "react-bootstrap"
import StoreContext from 'components/Store/Context'
import axios from 'axios'
import config from 'config'
import './Login.css'

const authenticate = async( user, password ) => {    
    const data = { login: user, password: password };
    let result = await axios({
        method: 'post',
        headers: { 'Content-Type': 'application/json-patch+json' },
        url: config.AUTH_API,
        data: data
    });

    return result;
        
}

const Login = () => {    
    function initialState() {
        return { user: '', password: '' };
    }

    const [user, setUser] = useState(initialState().user);
    const [password, setPassword] = useState(initialState().password);

    const [error, setError] = useState(null);
    const { setToken } = useContext(StoreContext);    
    const history = useHistory();


    function validateForm() {
        return user.length > 0 && password.length > 0;
    }

    function onSubmit(event) {
        event.preventDefault();
        
        authenticate(user,password)
            .then((response) => {
                
                setToken(response.data.token);
                
                return history.push('/');
            })
            .catch((error) => {
                console.log(error.response);
                setError(error.response?.data.message);
                setUser(initialState().user);
                setPassword(initialState().password);
            });        
    }

    return (
        <div className="Login">          
            <form onSubmit={onSubmit}>
                <FormGroup controlId="login">
                    <FormLabel>Usuário</FormLabel>
                    <FormControl type="text" value={user} onChange={e => setUser(e.target.value)} />
                </FormGroup>
                <FormGroup controlId="password">
                    <FormLabel>Senha</FormLabel>
                    <FormControl type="password" value={password} onChange={e => setPassword(e.target.value)} />
                </FormGroup>
                
                {error && (
                    <div className="user-login__error">{error}</div>
                )}

                <Button block disabled={!validateForm()} type="submit">Login</Button>
                   
            </form>
        </div>
    );
};

export default Login;