export interface IAuthenticateRequest {
    userName: string;
    password: string;
}

export interface IAuthenticateResponse {
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

export interface ICalculateAmounts {
    investmentAmount: number;
    availableAmount: number;
    usedAmount: number;
}

export interface IInvestmentOption {
    option: IOption;
    percentage: number;
}

export interface IOption {
    value: string;
    label: string;
}

export interface IInvestmentOptionsState {
    amounts: ICalculateAmounts;
    options: IInvestmentOption[];
}

export interface ICalculationRequest {
    investmentAmount: number;
    selectedOptions: IInvestmentOption[];
}

export interface ICalculationResponse {
    investmentReturn: number;
    fees: number;
}

export interface ICalculatorState {
    isCalculated: boolean;
    data: {
        investmentReturn: number;
        fees: number;
    };
}
