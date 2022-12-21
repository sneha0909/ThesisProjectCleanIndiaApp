import './App.css';
import { Suspense } from 'react';
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import HomePage from './Components/Pages/HomePage';
import LoggedinPage from './Components/Pages/LoggedinPage';
import RegisterPage from './Components/Pages/RegisterPage';
import LoginPage from './Components/Pages/LoginPage';
import React from 'react';

function App() {
  return (
    <Suspense fallback={null}>
      <Router>
        {/* <Navbar1 />
       <Navbar2 />
       <ImageSlider images={images} />
       <Pledge1 />
       <Cards /> */}

        <Routes>

          <Route path="/" element={<HomePage />} />
          <Route path="/register" element={<RegisterPage />} />
          <Route path="/login" element={<LoginPage />} />
          <Route path="/loggedin" element={< LoggedinPage />} />
        </Routes>

        {/* <Footer /> */}
      </Router>

    </Suspense>


  );
}

export default App;
