import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import './App.css';
import login from './components/login';
import calculator from './components/calculator';

// eslint-disable-next-line @typescript-eslint/explicit-module-boundary-types
function App() {
    return (
        <Router>
            <div>
                <header className="App-header">
                    <h1>Investment Option Calculator</h1>
                </header>
                <Switch>
                    <Route exact path="/" component={login} />
                    <Route path="/calculator" component={calculator} />
                </Switch>
                <footer className="App-footer">&copy; Copyright 2021 Wayne Hong</footer>
            </div>
        </Router>
    );
}

export default App;
