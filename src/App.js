import './App.css';
import { Suspense } from 'react';
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import HomePage from './Components/Pages/HomePage/HomePage';
import LoggedinPage from './Components/Pages/LoggedIn Page/LoggedinPage';
import CreateComplaint from './Components/Pages/Complaints/Create Complaint/CreateComplaint';
import Heatmap from './Components/Location/Heatmap';
import CardList from '../src/cleaningEventsApp/features/cleaningEvents/dashboard/CardList';
import CardView from '../src/cleaningEventsApp/features/cleaningEvents/dashboard/CardView';
import CardEdit from './cleaningEventsApp/features/cleaningEvents/dashboard/CardEdit';
import Login from './cleaningEventsApp/features/cleaningEvents/dashboard/Login';
import Register from './cleaningEventsApp/features/cleaningEvents/dashboard/Register';
import Profile from './cleaningEventsApp/features/cleaningEvents/dashboard/Profile';
import CreateEventForm from './cleaningEventsApp/features/cleaningEvents/dashboard/CreateEventForm';
import Map from './cleaningEventsApp/Map';
import EventLocation from './cleaningEventsApp/features/cleaningEvents/dashboard/EventLocation';
import Create from './Components/Pages/Complaints/Create Complaint/Create';
import FinalAdmin from './Components/Pages/Complaints/Create Complaint/FinalAdmin';
import TrackComplaint from './Components/Pages/Complaints/Create Complaint/TrackComplaint';

function App() {

  
  return (
    <Suspense fallback={null}>
       
      <Router>
     

        <Routes>

          <Route path="/" element={<HomePage />} />
          <Route path="/loggedin" element={< LoggedinPage />} />
          <Route path="/createComplaint" element={< CreateComplaint />} />
          <Route path='/heatmap' element={<Heatmap />}></Route>
         
          
          <Route path="/cards" element={<CardList/>}></Route>
          <Route path="/card/:id" element={<CardView  />} />
          <Route path="/card/:id/edit" element={<CardEdit/>}></Route>
          <Route exact path='/create-event' element={<CreateEventForm />}></Route>

          <Route path="/login" element={<Login/>}></Route> 
          <Route path="/register" element={<Register/>}></Route>
          <Route path="/profile" element={<Profile/>}></Route>
          <Route path="/complaintsHeatmap" element={<Map/>}></Route>
          <Route path="/eventlocation" element={<EventLocation/>}></Route>

          <Route path="/create" element={<Create/>}></Route>
          <Route path="/finaladmin" element={<FinalAdmin/>}></Route>
          <Route path="/trackComplaint" element={<TrackComplaint/>}></Route>







          
          
        </Routes>

      </Router>

    </Suspense>


  );
}

export default App;
