import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';

import VehicleContainer from './container/VehicleContainer';
import { createStore, applyMiddleware } from 'redux';
import { Provider } from 'react-redux';
import thunk from 'redux-thunk';
import reducers from './reducers/Vehicle.js';

let store = createStore(reducers, applyMiddleware(thunk));

class App extends React.Component {
  render() {
    return <VehicleContainer></VehicleContainer>;
  }
}

ReactDOM.render(
  <Provider store={store}>
    <App />
  </Provider>,
  document.getElementById('root'),
);

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
