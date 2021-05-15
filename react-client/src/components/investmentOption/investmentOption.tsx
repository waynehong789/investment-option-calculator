/* eslint-disable prefer-const */
import { useEffect, useState } from 'react';
import NumberFormat from 'react-number-format';
import { Card } from 'react-bootstrap';
import Select from 'react-select';
import { IconButton } from '@material-ui/core';
import AddBoxIcon from '@material-ui/icons/AddBox';
import DeleteForeverIcon from '@material-ui/icons/DeleteForever';
import { ICalculateAmounts, IInvestmentOption, IOption } from '../../interfaces';

import './investmentOption.css';
import { INVESTMENT_OPTIONS_TYPES } from '../../contants/investmentOptionContants';
import { store } from '../../redux/store';
import { setAmounts, setOptions } from './investmentOption.slice';

export default function InvestmentOption(): JSX.Element {
    useEffect(() => {
        store.dispatch(setAmounts(calculateAmounts));
        store.dispatch(setOptions(investmentOptions));
    });
    const initCalculateAmounts: ICalculateAmounts = {
        investmentAmount: 100000,
        availableAmount: 100000,
        usedAmount: 0,
    };
    const initNumrows = 5;
    const optionPlaceholder = '--select--';
    const [calculateAmounts, setCalculateAmounts] = useState<ICalculateAmounts>(initCalculateAmounts);
    const initInvestmentOptions: IInvestmentOption[] = [];
    for (let i = 0; i < initNumrows; i++) {
        let initInvestmentOption: IInvestmentOption = {
            option: INVESTMENT_OPTIONS_TYPES[0],
            percentage: 0,
        };

        initInvestmentOptions.push(initInvestmentOption);
    }

    const [investmentOptions, setInvestmentOptions] = useState<IInvestmentOption[]>(initInvestmentOptions);

    function onSelected(selectedOption: IOption | null, id: number) {
        if (selectedOption) {
            const targetItem = investmentOptions[id];
            let newInvestmentOption: IInvestmentOption = {
                option: INVESTMENT_OPTIONS_TYPES[0],
                percentage: targetItem.percentage,
            };
            const selected = INVESTMENT_OPTIONS_TYPES.find((t) => t.value === selectedOption.value);
            if (selected) {
                newInvestmentOption.option = selected;
                let newInvestmentOptions = [...investmentOptions];
                newInvestmentOptions[id] = newInvestmentOption;
                setInvestmentOptions(newInvestmentOptions);
            }
        }
        console.log('investmentOptions', investmentOptions);
    }

    function onPercentageUpdated(updateValue: number, id: number) {
        if (updateValue === 0 && investmentOptions[id].percentage === 0) {
            return;
        }
        let usedPercentage = 0;
        for (let i = 0; i < investmentOptions.length; i++) {
            if (i !== id) {
                usedPercentage += investmentOptions[i].percentage;
            }
        }
        let remain = 100 - (usedPercentage + updateValue);
        const targetItem = investmentOptions[id];
        let newInvestmentOptions = [...investmentOptions];
        let newInvestmentOption: IInvestmentOption = {
            option: targetItem.option,
            percentage: 0,
        };
        if (remain >= 0) {
            newInvestmentOption.percentage = updateValue;
            const available = Math.floor((calculateAmounts.investmentAmount * remain) / 100);
            setCalculateAmounts({
                ...calculateAmounts,
                usedAmount: calculateAmounts.investmentAmount - available,
                availableAmount: available,
            });
        } else {
            remain = 0;
            newInvestmentOption.percentage = 100 - usedPercentage;
            setCalculateAmounts({
                ...calculateAmounts,
                usedAmount: calculateAmounts.investmentAmount,
                availableAmount: 0,
            });
        }
        newInvestmentOptions[id] = newInvestmentOption;
        setInvestmentOptions(newInvestmentOptions);

        console.log('investmentOptions', investmentOptions);
    }

    function addNewOption() {
        let newInvestmentOptions = [...investmentOptions];
        let newInvestmentOption: IInvestmentOption = {
            option: INVESTMENT_OPTIONS_TYPES[0],
            percentage: 0,
        };
        newInvestmentOptions.push(newInvestmentOption);
        setInvestmentOptions(newInvestmentOptions);

        console.log('investmentOptions', investmentOptions);
    }

    function removeOption(id: number) {
        if (investmentOptions.length > 1) {
            let newInvestmentOptions = [...investmentOptions];
            let usedPercentage = 0;
            for (let i = 0; i < investmentOptions.length; i++) {
                if (i !== id) {
                    usedPercentage += investmentOptions[i].percentage;
                }
            }
            const used = Math.floor((calculateAmounts.investmentAmount * usedPercentage) / 100);
            setCalculateAmounts({
                ...calculateAmounts,
                usedAmount: used,
                availableAmount: calculateAmounts.investmentAmount - used,
            });

            newInvestmentOptions.splice(id, 1);
            const removed = [...newInvestmentOptions];
            setInvestmentOptions(removed);
            console.log('investmentOptions', investmentOptions);
        }
    }

    /* function getSelectedOption(id: number): IOption {
        const selectedOptionIndex = INVESTMENT_OPTIONS_TYPES.findIndex((t) => t.value === investmentOptions[id].option);
        const emptyOption: IOption = {
            label: '',
            value: '',
        };
        if (selectedOptionIndex >= 0) {
            return INVESTMENT_OPTIONS_TYPES[selectedOptionIndex];
        }

        return emptyOption;
    } */

    const optionList = investmentOptions.map((_op, id) => {
        return (
            <div key={id} className="mt-3 d-flex justify-content-start align-items-center">
                <span className="option-selector mr-3">
                    <Select
                        value={_op.option}
                        placeholder={optionPlaceholder}
                        onChange={(event) => onSelected(event, id)}
                        options={INVESTMENT_OPTIONS_TYPES}
                    />
                </span>
                <span>
                    <NumberFormat
                        value={_op.percentage}
                        thousandSeparator={false}
                        onValueChange={(values) => {
                            const { value } = values;
                            // formattedValue = $2,223
                            // value ie, 2223
                            onPercentageUpdated(Number(value), id);
                        }}
                        suffix="%"
                    />
                </span>
                <span>
                    <IconButton
                        color="primary"
                        aria-label="Add new investment option"
                        component="span"
                        onClick={() => removeOption(id)}
                    >
                        <DeleteForeverIcon />
                    </IconButton>
                </span>
            </div>
        );
    });

    return (
        <div>
            <div className="mt-5">
                <span className="tab-item-lable">Investment Amount</span>
                <span className="tab-item">
                    <NumberFormat
                        value={calculateAmounts.investmentAmount}
                        thousandSeparator={true}
                        prefix={'$'}
                        onValueChange={(values) => {
                            const { value } = values;
                            // formattedValue = $2,223
                            // value ie, 2223
                            setCalculateAmounts({
                                ...calculateAmounts,
                                investmentAmount: Number(value),
                                availableAmount: Number(value) - Number(calculateAmounts.usedAmount),
                            });
                        }}
                    />
                </span>
            </div>
            <div className="mt-3">
                <span className="tab-item-lable">Available Amount</span>
                <span className="tab-item-lable">
                    <NumberFormat
                        value={calculateAmounts.availableAmount}
                        displayType={'text'}
                        thousandSeparator={true}
                        prefix={'$'}
                    />
                </span>
            </div>
            <div className="mt-3">
                <Card className="mb-2 options-card">
                    <Card.Header>Investment Option</Card.Header>
                    <Card.Body>
                        <div>{optionList}</div>
                        <div>
                            <IconButton
                                color="primary"
                                aria-label="Add new investment option"
                                component="span"
                                onClick={addNewOption}
                            >
                                <AddBoxIcon />
                            </IconButton>
                        </div>
                    </Card.Body>
                </Card>
            </div>
        </div>
    );
}
