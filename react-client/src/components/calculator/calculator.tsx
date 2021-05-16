import { Tab, Tabs } from 'react-bootstrap';
import './calculator.css';
import ROI from './ROI/ROI';
import InvestmentOption from './investmentOption/investmentOption';
import { useAppSelector } from '../../redux/hooks';
import { selectAmounts, selectOptions } from './investmentOption/investmentOption.slice';
import { useState } from 'react';
import { ICalculationRequest, ICalculationResponse } from '../../interfaces';
import axios from 'axios';
import { store } from '../../redux/store';
import { setCalcultionResult } from './calculator.slice';
import { selectUserToken } from '../login/login.slice';

export default function calculator(): JSX.Element {
    const amounts = useAppSelector(selectAmounts);
    const options = useAppSelector(selectOptions);
    const token = useAppSelector(selectUserToken);

    const [isCalculatorFailed, setIsCalculatorFailed] = useState<boolean>(false);
    async function handleSelect(key: string | null): Promise<void> {
        if (key === 'option') {
            setIsCalculatorFailed(false);
        }

        if (key === 'ROI') {
            console.log('amounts', amounts);
            console.log('options', options);
            // verify investment amount
            if (amounts.usedAmount <= 0 || amounts.investmentAmount <= 0) {
                setIsCalculatorFailed(true);
                return;
            }

            // verify investment options
            const vaildOptions = options.filter((op) => op.option.value !== 'Select' && op.percentage > 0);
            if (vaildOptions.length <= 0) {
                setIsCalculatorFailed(true);
                return;
            }

            setIsCalculatorFailed(false);

            const calculationRequest: ICalculationRequest = {
                investmentAmount: amounts.investmentAmount,
                selectedOptions: vaildOptions,
            };

            console.log(calculationRequest);
            const apiUrl = `/api/calculator`;
            const config = {
                headers: {
                    'Content-Type': 'application/json',
                    Authorization: `Bearer ${token}`,
                },
            };
            const response = await axios.post(apiUrl, calculationRequest, config);
            console.log(response);
            const calculationResponse: ICalculationResponse = response.data.payload;
            store.dispatch(setCalcultionResult(calculationResponse));
        }
    }

    const ErrorInfo = () => (
        <div id="errorInfo" className="error-info">
            Please provide all calculator information.
        </div>
    );

    return (
        <div className="calculator-tabs">
            <div>{isCalculatorFailed ? <ErrorInfo /> : null}</div>
            <Tabs defaultActiveKey="option" onSelect={handleSelect}>
                <Tab eventKey="option" title="Investment Option" className="calculator-tab">
                    <InvestmentOption />
                </Tab>
                <Tab eventKey="ROI" title="ROI" className="calculator-tab">
                    <ROI />
                </Tab>
            </Tabs>
        </div>
    );
}
