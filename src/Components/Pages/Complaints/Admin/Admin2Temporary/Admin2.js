import React, { useEffect, useState } from "react";
import axios from 'axios';
import { Header, List } from 'semantic-ui-react';

function Admin2() {
  const [complaints, setComplaints] = useState([]);

  useEffect(() => {
    axios.get('http://localhost:5000/api/complaints')
      .then(response => {
        console.log(response);
        setComplaints(response.data);
      })
  }, []);

    return (       
      <>
      <div className="Complaints">
        <Header as='h2' icon='user' content='List of Complaints'/>
        <List>
          {complaints.map(complaint => (
            <List.Item key={complaint.id}>
              {complaint.complainantName}
              {complaint.email}
              {complaint.complaintType}
            </List.Item>
          ))}
        </List>

      </div>
      
      </>

    );
}

export default Admin2;