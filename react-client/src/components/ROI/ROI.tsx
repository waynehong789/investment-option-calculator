/* eslint-disable prefer-const */
import { Card } from 'react-bootstrap';
import FormControl from '@material-ui/core/FormControl';
// import Input from '@material-ui/core/Input';
import FilledInput from '@material-ui/core/FilledInput';
import InputAdornment from '@material-ui/core/InputAdornment';

export default function ROI(): JSX.Element {
    let projectedReturn = '0';
    return (
        <div className="mt-3">
            <Card className="mb-2 options-card">
                <Card.Header>ROI</Card.Header>
                <Card.Body>
                    <div className="d-flex justify-content-start align-items-center">
                        <div>
                            <div className="tab-item-lable">Projected Return in 1 Year</div>
                            <div className="tab-item">
                                <FormControl disabled variant="filled">
                                    <FilledInput
                                        id="projectedReturn"
                                        value={projectedReturn}
                                        endAdornment={<InputAdornment position="end">AUD</InputAdornment>}
                                    />
                                </FormControl>
                            </div>
                        </div>
                        <div>
                            <div className="tab-item-lable">Total Fees</div>
                            <div className="tab-item">
                                <FormControl disabled variant="filled">
                                    <FilledInput
                                        id="projectedReturn"
                                        value={projectedReturn}
                                        endAdornment={<InputAdornment position="end">USD</InputAdornment>}
                                    />
                                </FormControl>
                            </div>
                        </div>
                    </div>
                </Card.Body>
            </Card>
        </div>
    );
}
