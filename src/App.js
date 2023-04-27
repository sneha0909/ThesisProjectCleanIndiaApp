import './App.css';
import { Suspense } from 'react';
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import HomePage from './Components/Pages/HomePage/HomePage';
import LoggedinPage from './Components/Pages/LoggedIn Page/LoggedinPage';
import RegisterPage from './Components/Pages/Register Page/RegisterPage';
import LoginPage from './Components/Pages/Login Page/LoginPage';
import ComplaintStatus from './Components/Pages/Complaints/Complaint Status/ComplaintStatus';
import CreateComplaint from './Components/Pages/Complaints/Create Complaint/CreateComplaint';
import ComplaintAdmin from './Components/Pages/Complaints/Admin/ComplaintAdmin';
import Details from './Components/Pages/Complaints/Admin/Table/Details';
import ComplaintDetail from './Components/Pages/Complaints/Admin/ComplaintDetail';
import ComplaintSearchByDetailsResults from './Components/Pages/Complaints/Complaint Status/ComplaintSearchyDetailsResults';
import ComplaintEdit from './Components/Pages/Complaints/Admin/ComplaintEdit'
import ComplaintSubmissionPage from './Components/Pages/Complaints/Create Complaint/ComplaintSubmissionPage';
import ComplaintNumberSearchResults from './Components/Pages/Complaints/Complaint Status/ComplaintNumberSearchResults';
import Heatmap from './Components/Location/Heatmap';


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
          <Route path="/complaintStatus" element={< ComplaintStatus />} />
          <Route path="/admin" element={< ComplaintAdmin />} />
          <Route path="/details/:empid" element={< Details />} />
          <Route path='/admin/detail/:empid' element={<ComplaintDetail />}></Route>
          <Route path='/admin/edit/:empid' element={<ComplaintEdit />}></Route>
          <Route path='/SearchResultsByDetails/:complaintType/:complainantName/:mobile' element={<ComplaintSearchByDetailsResults />}  exact></Route>
          <Route path='/SearchResultsByComplaintNumber/:empid' element={<ComplaintNumberSearchResults />}></Route>
          <Route path='/complaintSubmit' element={<ComplaintSubmissionPage />}></Route>
          <Route path='/heatmap' element={<Heatmap />}></Route>

          
          
        </Routes>

      </Router>

    </Suspense>


  );
}

export default App;
