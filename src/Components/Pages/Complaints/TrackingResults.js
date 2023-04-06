import React from 'react'
import axios from 'axios';
import { useParams, useSearchParams } from "react-router-dom";
import { useEffect, useState } from "react";

const TrackingResults = () => {

    const {complaintType, complainantName, mobile } = useParams();
    const [empdata, datachange] = useState({});

    useEffect(() => {
        
        axios.get(`http://localhost:5000/api/complaints/${complaintType}/${complainantName}/${mobile}`)
            .then(response => {
                console.log(response);
                datachange(response.data);
            }).catch((err) => {
                console.log(err.message);
            })
    }, []);
  return (
    <div>
      <h1> TrackingResults {empdata.complaintSubType}</h1>
      <h2>{empdata.complaintType}</h2>
      <h3>{empdata.email}</h3>
      <h1>{empdata.ward}</h1>

    </div>
    
    
    
  )
}

export default TrackingResults;