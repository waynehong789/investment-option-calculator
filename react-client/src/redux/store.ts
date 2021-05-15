import { configureStore } from '@reduxjs/toolkit';
import usersReducer from '../components/login/login.slice';
import investmentReducer from '../components/investmentOption/investmentOption.slice';
import calculatorReducer from '../components/calculator/calculator.slice';

export const store = configureStore({
    reducer: {
        user: usersReducer,
        investment: investmentReducer,
        calculator: calculatorReducer,
    },
});

// Infer the `RootState` and `AppDispatch` types from the store itself
export type RootState = ReturnType<typeof store.getState>;
// Inferred type: {posts: PostsState, comments: CommentsState, users: UsersState}
export type AppDispatch = typeof store.dispatch;
