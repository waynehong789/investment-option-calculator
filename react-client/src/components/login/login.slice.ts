import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { IAuthenticateResponse, ILoginState } from '../../interfaces';
import type { RootState } from '../../redux/store';

// Define the initial state using that type
const initialState: ILoginState = {
    loaded: false,
    data: {
        userName: '',
        token: '',
    },
};

export const loginSlice = createSlice({
    name: 'login',
    // `createSlice` will infer the state type from the `initialState` argument
    initialState,
    reducers: {
        // Use the PayloadAction type to declare the contents of `action.payload`
        setUser: (state, action: PayloadAction<IAuthenticateResponse>) => {
            state.loaded = true;
            state.data.userName = action.payload.username;
            state.data.token = action.payload.token;
        },
    },
});

export const { setUser } = loginSlice.actions;

// Other code such as selectors can use the imported `RootState` type
export const selectUserToken = (state: RootState): string => state.user.data.token;

export default loginSlice.reducer;
