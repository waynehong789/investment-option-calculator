import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import { Provider } from 'react-redux';
import './App.css';
import Login from './components/login/login';
import calculator from './components/calculator/calculator';
import { store } from './redux/store';

export default function App(): JSX.Element {
    return (
        <Router>
            <Provider store={store}>
                <div>
                    <header className="App-header">
                        <h1>Investment Option Calculator</h1>
                    </header>
                    <div className="App-body">
                        <Switch>
                            <Route exact path="/" component={Login} />
                            <Route exact path="/calculator" component={calculator} />
                        </Switch>
                    </div>
                    <footer className="App-footer">&copy; Copyright 2021 Wayne Hong</footer>
                </div>
            </Provider>
        </Router>
    );
}
