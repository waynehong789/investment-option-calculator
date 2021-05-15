import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { ICalculationResponse, ICalculatorState } from '../../interfaces';
import type { RootState } from '../../redux/store';

// Define the initial state using that type
const initialState: ICalculatorState = {
    isCalculated: false,
    data: {
        return: 0,
        fees: 0,
    },
};

export const calculatorSlice = createSlice({
    name: 'calculator',
    // `createSlice` will infer the state type from the `initialState` argument
    initialState,
    reducers: {
        // Use the PayloadAction type to declare the contents of `action.payload`
        setCalcultionResult: (state, action: PayloadAction<ICalculationResponse>) => {
            state.isCalculated = true;
            state.data.return = action.payload.return;
            state.data.fees = action.payload.fees;
        },
    },
});

export const { setCalcultionResult } = calculatorSlice.actions;

// Other code such as selectors can use the imported `RootState` type
export const selectCalcultionResult = (state: RootState): ICalculationResponse => state.calculator.data;

export default calculatorSlice.reducer;
