import Button from '@material-ui/core/Button';
import FormControl from '@material-ui/core/FormControl';
import InputLabel from '@material-ui/core/InputLabel';
import Input from '@material-ui/core/Input';
// import React from 'react';
import { useHistory } from 'react-router-dom';
import { IAuthenticateRequest, IAuthenticateResponse } from '../../interfaces';
import './login.css';
// import { ILoginState } from '../../interfaces';
import axios from 'axios';
import { store } from '../../redux/store';
import { setUser } from './login.slice';

// function OnClickLogin() {
//     const apiUrl = 'api/login';
// }

export default function Login(): JSX.Element {
    const history = useHistory();
    // const handleClick = () => history.push('/calculator');
    // const initLoginState: ILoginState = {
    //     loaded: false,
    //     data: {
    //         userName: '',
    //         token: '',
    //     },
    // };
    // eslint-disable-next-line @typescript-eslint/no-unused-vars
    // const [loginState, loginStateSet] = React.useState<ILoginState>(initLoginState);

    let enteredUserName = '';
    let enteredPassword = '';

    store.subscribe(() => {
        console.log('Redux toolkit state: ' + store.getState());
    });

    async function submitHandler() {
        try {
            if (enteredUserName && enteredPassword) {
                const request: IAuthenticateRequest = {
                    userName: enteredUserName,
                    password: enteredPassword,
                };

                console.log(request);
                const apiUrl = `/api/authenticate`;
                const config = {
                    headers: {
                        'Content-Type': 'application/json',
                    },
                };
                const response = await axios.post(apiUrl, request, config);
                console.log(response);
                const authenticateResponse: IAuthenticateResponse = response.data;
                store.dispatch(setUser(authenticateResponse));
                const path = `calculator`;
                history.push(path);
            }
        } catch (err) {
            console.log(`User login failed with username: ${enteredUserName}`);
            throw new Error('Login Failed');
        }
    }

    return (
        <div className="login">
            <div className="welcome">Welcome to ABC Investment</div>
            <div className="login-input">
                <FormControl>
                    <InputLabel>UserName</InputLabel>
                    <Input
                        id="username"
                        onChange={(event) => {
                            enteredUserName = event.target.value;
                        }}
                    />
                </FormControl>
            </div>
            <div className="login-input">
                <FormControl>
                    <InputLabel>Password</InputLabel>
                    <Input
                        id="password"
                        onChange={(event) => {
                            enteredPassword = event.target.value;
                        }}
                    />
                </FormControl>
            </div>
            <div className="login-input">
                <Button variant="contained" color="primary" onClick={submitHandler}>
                    Login
                </Button>
            </div>
        </div>
    );
}
