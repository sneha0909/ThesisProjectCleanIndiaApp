import React, { useEffect, useState } from "react";
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import axios from 'axios';
import '../Table/Table.css';
import { useNavigate } from 'react-router-dom';



const makeStyle=(status)=>{
    if(status === 'Approved')
  {
    return {
      background: 'rgb(145 254 159 / 47%)',
      color: 'green',
    }
  }
  else if(status === 'Pending')
  {
    return{
      background: '#ffadad8f',
      color: 'red',
    }
  }
  else{
    return{
      background: '#59bfff',
      color: 'white',
    }
  }

}

export default function BasicTable() {
    const [complaints, setComplaints] = useState([]);
    const navigate = useNavigate();

    
    const LoadDetail = (id) => {
      navigate("/admin/detail/" + id);
  }

    useEffect(() => {
        axios.get('http://localhost:5000/api/complaints')
          .then(response => {
            console.log(response);
            setComplaints(response.data);
          })
      }, []);
  return (
    <div className='Table'>
        <h3>Recent Complaints</h3>

    

    <TableContainer component={Paper}
    // component={Paper}
    style={{ boxShadow: "0px 13px 20px 0px #80808029" }}
    
    
    >
      <Table sx={{ minWidth: 650 }} aria-label="simple table">
        <TableHead>
          <TableRow>
            <TableCell>Complainant Name</TableCell>
            <TableCell align="left">Complaint Id</TableCell>
            <TableCell align="left">Email</TableCell>
            <TableCell align="left">Complaint Type</TableCell>
            <TableCell align="left">Complaint Status</TableCell>
            <TableCell align="left">Action</TableCell>
            
          </TableRow>
        </TableHead>
        <TableBody>
        {complaints.map(complaint => (
            <TableRow
              
            sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
          >
            <TableCell component="th" scope="row">
            {complaint.complainantName}
            </TableCell>
            <TableCell align="left">{complaint.id}</TableCell>
            <TableCell align="left">{complaint.email}</TableCell>
            <TableCell align="left">{complaint.complaintType}</TableCell>
            <TableCell align="left">
                <span className="status" style={makeStyle()}>In Process</span>
            </TableCell>
            <TableCell align="left">
                <button className="btn" onClick={() => { LoadDetail(complaint.id) }}>Details</button>
            </TableCell>
            
          </TableRow>
          ))}
            
         
            
         
        </TableBody>
      </Table>
    </TableContainer>
    </div>
  );
}
