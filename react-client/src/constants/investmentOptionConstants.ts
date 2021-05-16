import { IOption } from '../interfaces';

export const INVESTMENT_OPTIONS_TYPES: IOption[] = [
    { value: 'Select', label: '--select--' },
    { value: 'Cash_Investments', label: 'Cash Investments' },
    { value: 'Fixed_Interest', label: 'Fixed Interest' },
    { value: 'Shares', label: 'Shares' },
    { value: 'Managed_Funds', label: 'Managed Funds' },
    { value: 'Exchange_Traded_Funds(ETFs)', label: 'Exchange Traded Funds(ETFs)' },
    { value: 'Investment_Bonds', label: 'Investment Bonds' },
    { value: 'Annuities', label: 'Annuities' },
    { value: 'Listed_Investment_Companies(LICs)', label: 'Listed Investment Companies(LICs)' },
    { value: 'Real_Estate_Investment_Trusts(REITs)', label: 'Real Estate Investment Trusts(REITs)' },
];
