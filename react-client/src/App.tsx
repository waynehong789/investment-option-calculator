import logo from './logo.svg';
import './App.css';
import login from './components/login';
import { BrowserRouter as Router, Route } from 'react-router-dom';

// eslint-disable-next-line @typescript-eslint/explicit-module-boundary-types
function App() {
    return (
        <Router>
            <Route path="/" component={login} />
            <div className="App">
                <header className="App-header">
                    <img src={logo} className="App-logo" alt="logo" />
                    <p>
                        Edit <code>src/App.tsx</code> and save to reload.
                    </p>
                    <a className="App-link" href="https://reactjs.org" target="_blank" rel="noopener noreferrer">
                        Learn React
                    </a>
                </header>
            </div>
        </Router>
    );
}

export default App;
