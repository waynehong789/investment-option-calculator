import { Component } from 'react';
import { ILoginState } from '../../interfaces';
export class Calculator extends Component {
    constructor(props: ILoginState) {
        super(props);
        this.state = {
            user: null,
        };
    }

    render(): JSX.Element {
        return (
            <div>
                <h1>Hello from calculator</h1>
            </div>
        );
    }
}
