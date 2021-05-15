import { Tab, Tabs } from 'react-bootstrap';
import './calculator.css';
import ROI from '../ROI/ROI';
import InvestmentOption from '../investmentOption/investmentOption';
import { useAppSelector } from '../../redux/hooks';
import { selectAmounts, selectOptions } from '../investmentOption/investmentOption.slice';
import { useState } from 'react';
import { ICalculationRequest, ICalculationResponse } from '../../interfaces';
import axios from 'axios';
import { store } from '../../redux/store';
import { setCalcultionResult } from './calculator.slice';

export default function calculator(): JSX.Element {
    const amounts = useAppSelector(selectAmounts);
    const options = useAppSelector(selectOptions);

    const [isCalculatorFailed, setIsCalculatorFailed] = useState<boolean>(false);
    async function handleSelect(key: string | null): Promise<void> {
        if (key === 'ROI') {
            console.log('amounts', amounts);
            console.log('options', options);
            // verify investment amount
            if (amounts.usedAmount <= 0 || amounts.investmentAmount <= 0) {
                setIsCalculatorFailed(true);
                return;
            }

            // verify investment options
            const isVaildOptions = options.findIndex((op) => op.option.value !== 'Select' && op.percentage > 0) >= 0;

            if (!isVaildOptions) {
                setIsCalculatorFailed(true);
                return;
            }

            setIsCalculatorFailed(false);

            const calculationRequest: ICalculationRequest = {
                investmentAmount: amounts.investmentAmount,
                selectedOptions: options,
            };

            console.log(calculationRequest);
            const apiUrl = `/api/authenticate`;
            const config = {
                headers: {
                    'Content-Type': 'application/json',
                },
            };
            const response = await axios.post(apiUrl, calculationRequest, config);
            console.log(response);
            const calculationResponse: ICalculationResponse = response.data;
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
