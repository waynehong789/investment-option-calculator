export interface AuthenticateRequest {
    userName: string;
    password: string;
}

export interface AuthenticateResponse {
    id: string;
    firstName: string;
    lastName: string;
    username: string;
    token: string;
}

export interface ILoginState {
    loaded: boolean;
    data: {
        userName: string;
        token: string;
    };
}
