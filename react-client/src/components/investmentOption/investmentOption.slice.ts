import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { ICalculateAmounts, IInvestmentOption, IInvestmentOptionsState } from '../../interfaces';
import type { RootState } from '../../redux/store';

// Define the initial state using that type
const initialState: IInvestmentOptionsState = {
    amounts: {
        investmentAmount: 0,
        usedAmount: 0,
        availableAmount: 0,
    },
    options: [],
};

export const investmentOptionSlice = createSlice({
    name: 'investmentOption',
    // `createSlice` will infer the state type from the `initialState` argument
    initialState,
    reducers: {
        // Use the PayloadAction type to declare the contents of `action.payload`
        setAmounts: (state, action: PayloadAction<ICalculateAmounts>) => {
            state.amounts = action.payload;
        },
        setOptions: (state, action: PayloadAction<IInvestmentOption[]>) => {
            state.options = action.payload;
        },
    },
});

export const { setAmounts, setOptions } = investmentOptionSlice.actions;

// Other code such as selectors can use the imported `RootState` type
export const selectAmounts = (state: RootState): ICalculateAmounts => state.investment.amounts;
export const selectOptions = (state: RootState): IInvestmentOption[] => state.investment.options;

export default investmentOptionSlice.reducer;
