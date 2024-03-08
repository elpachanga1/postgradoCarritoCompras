import React from 'react';
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import { MainPageComponent } from './Components/MainPage';

const App = () => (
  <Router>
    <main className="container mt-5">
      <div className="jumbotron">
        <Routes>
          <Route path="/" element={ <MainPageComponent/> } />
        </Routes>
      </div>
    </main>
  </Router>
);

export default App;
