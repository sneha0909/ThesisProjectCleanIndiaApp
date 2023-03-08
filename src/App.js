import './App.css';
import { Suspense } from 'react';
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import HomePage from './Components/Pages/HomePage';
import LoggedinPage from './Components/Pages/LoggedinPage';
import RegisterPage from './Components/Pages/RegisterPage';
import LoginPage from './Components/Pages/LoginPage';
import {useEffect, useState} from 'react';
import { Container, createTheme, CssBaseline, ThemeProvider } from "@mui/material";
import ManageComplaints from './Components/Pages/ManageComplaints';
import ComplaintStatus from './Components/Pages/ComplaintStatus';

function App() {

  
  return (
    <Suspense fallback={null}>
       
      <Router>
     

        <Routes>

          <Route path="/" element={<HomePage />} />
          <Route path="/register" element={<RegisterPage />} />
          <Route path="/login" element={<LoginPage />} />
          <Route path="/loggedin" element={< LoggedinPage />} />
          <Route path="/managecomplaints" element={< ManageComplaints />} />
          <Route path="/complaintStatus" element={< ComplaintStatus />} />
          
        </Routes>

      </Router>

    </Suspense>


  );
}

export default App;
