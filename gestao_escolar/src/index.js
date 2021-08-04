import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import Home from './pages/home/Home';
import Login from './pages/login/Login';
import reportWebVitals from './reportWebVitals';
import { Route, BrowserRouter as Router, Switch, Redirect } from 'react-router-dom';

const routing = (
  <Router>
    <div>
      <Switch>
        <Route path='/home' component={Home} />
        <Route exact path='/' component={Login} />
        <Redirect to='/' />
      </Switch>
    </div>
  </Router>
)

ReactDOM.render(
  routing,
  document.getElementById('root')
);


reportWebVitals();
