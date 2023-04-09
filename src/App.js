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
import ComplaintAdmin from './Components/Pages/Complaints/Admin/ComplaintAdmin';
import Details from './Components/Pages/Complaints/Admin/Table/Details';
import Admin2 from './Components/Pages/Complaints/Admin/Admin2Temporary/Admin2';
import EmpListing from './Components/Pages/Complaints/Admin/Admin2Temporary/EmpListing';
import ComplaintDetail from './Components/Pages/Complaints/Admin/Admin2Temporary/ComplaintDetail';
import TrackingResults from './Components/Pages/Complaints/TrackingResults';
import ComplaintEdit from './Components/Pages/Complaints/Admin/Admin2Temporary/ComplaintEdit'


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
          <Route path="/admin" element={< ComplaintAdmin />} />
          <Route path="/details/:empid" element={< Details />} />
          <Route path='/admin2' element={<EmpListing />}></Route>

          <Route path='/admin/detail/:empid' element={<ComplaintDetail />}></Route>
          <Route path='/admin/edit/:empid' element={<ComplaintEdit />}></Route>
          <Route path='/trackingResults/:complaintType/:complainantName/:mobile' element={<TrackingResults />}  exact></Route>
          
          
        </Routes>

      </Router>

    </Suspense>


  );
}

export default App;
