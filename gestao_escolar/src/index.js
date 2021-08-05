import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import Home from './pages/home/Home';
import Login from './pages/login/Login';
import Classroom from './pages/classroom/Classroom';
import Equipment from './pages/equipment/Equipment';
import reportWebVitals from './reportWebVitals';
import { Route, BrowserRouter as Router, Switch, Redirect } from 'react-router-dom';

const routing = (
  <Router>
    <div>
      <Switch>
        <Route exact path='/' component={Login} />
        <Route path='/home' component={Home} />
        <Route path='/classroom' component={Classroom}/>
        <Route path='/equipment' component={Equipment}/>
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
