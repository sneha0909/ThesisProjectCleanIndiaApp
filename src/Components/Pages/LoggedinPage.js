import React, { useEffect, useState } from "react";
import ComplaintForm from '../Complaints/ComplaintForm';
import ManageComplaints from './ManageComplaints';
import axios from 'axios';

function LoggedinPage() {

    return (       
      <>
      <div className="Intro">
        <h1>You're Logged In!</h1>      
      </div>
      <ComplaintForm/>
      </>

    );
}

export default LoggedinPage;