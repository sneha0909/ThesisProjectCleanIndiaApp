import React, { useEffect, useState } from "react";
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import { Button } from "@mui/material";
import InfiniteScroll from "react-infinite-scroll-component";


function ListofComplaints() {

    const [pageNumber, setPageNumber] = useState(0);
    const [complaints, setComplaints] = useState([]);
    const navigate = useNavigate();


    const LoadDetail = (id) => {
        navigate("/admin/detail/" + id);
    }
    const LoadEdit = (id) => {
        navigate("/admin/edit/" + id);
    }

    const fetchData = () => {
        // axios.get('http://localhost:5000/api/complaints')
        axios.get(`http://localhost:5000/api/Complaints?PageNumber=${pageNumber}&PageSize=15`)
            .then(response => {
                console.log(response);
                setComplaints(prev => [...prev, ...response.data]);
                setPageNumber(pageNumber => pageNumber + 1);
            })

    }

    useEffect(() => {
        fetchData();
    }, []);


    return (
        <>

            <div className='Table'>
                <h3>Recent Complaints</h3>


                <InfiniteScroll
                dataLength={complaints.length}
                next={fetchData}
                hasMore={true} // Replace with a condition based on your data source
                loader={<p>Loading...</p>}
                endMessage={<p>No more data to load.</p>}
                
                >

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
                </InfiniteScroll>


            </div>
        </>
    );
}

export default ListofComplaints;