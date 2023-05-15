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
import InfiniteScroll from 'react-infinite-scroll-component';



const makeStyle = (status) => {
  if (status === 'Approved') {
    return {
      background: 'rgb(145 254 159 / 47%)',
      color: 'green',
    }
  }
  else if (status === 'Pending') {
    return {
      background: '#ffadad8f',
      color: 'red',
    }
  }
  else {
    return {
      background: '#59bfff',
      color: 'white',
    }
  }

}

export default function BasicTable() {
  const [pageNumber, setPageNumber] = useState(0);
  const [complaints, setComplaints] = useState([]);
  const navigate = useNavigate();


  const LoadDetail = (id) => {
    navigate("/admin/detail/" + id);
  }
  const LoadEdit = (id) => {
    navigate("/admin/edit/" + id);
  }

  useEffect(() => {
    // axios.get('http://localhost:5000/api/complaints')
    axios.get(`http://localhost:5000/api/Complaints?PageNumber=${pageNumber}&PageSize=12`)
      .then(response => {
        console.log(response);
        setComplaints(prev => [...prev, ...response.data]);
      })
  }, [pageNumber]);

 const handleScroll = () => {
      console.log("Height:", document.documentElement.scrollHeight);
      console.log("Top:", document.documentElement.scrollTop);
      console.log("Window:", window.innerHeight);

      if (window.innerHeight + document.documentElement.scrollTop + 1 >= document
        .documentElement.scrollHeight)
        {
          setPageNumber((prev) => prev + 1);
        }
      
 };

  useEffect(() => {
   
    window.addEventListener("scroll", handleScroll);
    
  }, [])


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
              <TableCell align="left">Complaint City</TableCell>
              <TableCell align="left">Complaint Type</TableCell>
              <TableCell align="left">Complaint Status</TableCell>
              <TableCell align="left">Edit Complaint</TableCell>
              <TableCell align="left">Details</TableCell>

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
                <TableCell align="left">{complaint.complaintLocationCity}</TableCell>
                <TableCell align="left">{complaint.complaintType}</TableCell>
                <TableCell align="left">{complaint.complaintStatus}</TableCell>
                <TableCell align="left">

                  <button className="btn" onClick={() => { LoadEdit(complaint.id) }}>Edit Complaint</button>
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
