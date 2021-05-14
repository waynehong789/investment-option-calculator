import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import { Provider } from 'react-redux';
import './App.css';
import login from './components/login/login';
import { Calculator } from './components/calculator/calculator';
import { store } from './redux/store';

export default function App(): JSX.Element {
    return (
        <Router>
            <Provider store={store}>
                <div>
                    <header className="App-header">
                        <h1>Investment Option Calculator</h1>
                    </header>
                    <Switch>
                        <Route exact path="/" component={login} />
                        <Route exact path="/calculator" component={Calculator} />
                    </Switch>
                    <footer className="App-footer">&copy; Copyright 2021 Wayne Hong</footer>
                </div>
            </Provider>
        </Router>
    );
}
