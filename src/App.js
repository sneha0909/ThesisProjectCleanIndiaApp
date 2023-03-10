import './App.css';
import { Suspense } from 'react';
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import HomePage from './Components/Pages/HomePage/HomePage';
import LoggedinPage from './Components/Pages/LoggedinPage';
import RegisterPage from './Components/Pages/RegisterPage';
import LoginPage from './Components/Pages/LoginPage';
import ManageComplaints from './Components/Pages/Complaints/ManageComplaints';
import ComplaintStatus from './Components/Pages/Complaints/ComplaintStatus';
import CreateComplaint from './Components/Pages/Complaints/CreateComplaint';

function App() {

  
  return (
    <Suspense fallback={null}>
       
      <Router>
     

        <Routes>

          <Route path="/" element={<HomePage />} />
          <Route path="/register" element={<RegisterPage />} />
          <Route path="/login" element={<LoginPage />} />
          <Route path="/loggedin" element={< LoggedinPage />} />
          <Route path="/createComplaint" element={< CreateComplaint />} />
          <Route path="/managecomplaints" element={< ManageComplaints />} />
          <Route path="/complaintStatus" element={< ComplaintStatus />} />
          
          
        </Routes>

      </Router>

    </Suspense>


  );
}

export default App;
