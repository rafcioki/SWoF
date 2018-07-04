import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import './Containers/RotaContainer'
import RotaContainer from './Containers/RotaContainer';

class App extends Component {
  render() {
    return (
      <div className="App">
        <header className="App-header">
          <img src="https://upload.wikimedia.org/wikipedia/commons/7/76/Wheel_of_Fortune_template.svg" className="App-logo" alt="logo" />
          <h1 className="App-title">Support Wheel Of Fate</h1>
        </header>
        <div>
          <RotaContainer />
        </div>
      </div>
    );
  }
}

export default App;
