import { useEffect, useState } from "react";
import { Link, useParams } from "react-router-dom";
import axios from 'axios';
import '../Admin2Temporary/ComplaintDetail.css';


const EmpDetail = () => {
    const { empid } = useParams();

    const [empdata, empdatachange] = useState({});


    useEffect(() => {
        axios.get(`http://localhost:5000/api/complaints/${empid}`)
            .then(response => {
                console.log(response);
                empdatachange(response.data);
            }).catch((err) => {
                console.log(err.message);
            })
    }, []);

    return (
        <div className="ComplaintDetails">
            <form>


                <div className="ComplaintD">
                    <h1>Complaint Details</h1>

                    {/* {empdata && */}
                    <div className='ComplaintInfoPart1'>
                    <h3>General Information</h3>
                        
                        <label htmlFor='' id='LabelId'>Complaint Type: {empdata.complaintType}</label>
                        <br></br>
                        <label htmlFor='' id='LabelId'>Complaint Subtype: {empdata.complaintSubtype}</label>
                        <br></br>
                        <label htmlFor='' id='LabelId'>Description of Complaint: {empdata.descriptionofComplaint}</label>
                        <br></br>
                    </div>
                    <div className='ComplaintInfoPart1'>
                    <h3>Details of Complaint</h3>

                        <label htmlFor='' id='LabelId'>House No: {empdata.complaintLocationHouseNo}</label>
                        <br></br>
                        <label htmlFor='' id='LabelId'>House Name: {empdata.complaintLocationHouseName}</label>
                        <br></br>
                        <label htmlFor='' id='LabelId'>Area In Address: {empdata.complaintLocationAreaInAddress}</label>
                        <br></br>
                        <label htmlFor='' id='LabelId'>Zone / Ward No. : {empdata.complaintLocationZoneWardNo}</label>
                        <br></br>
                        <label htmlFor='' id='LabelId'>Area 1 : {empdata.complaintLocationArea1}</label>
                        <br></br>
                        <label htmlFor='' id='LabelId'>Area 2 : {empdata.complaintLocationArea2}</label>
                        <br></br>
                        <label htmlFor='' id='LabelId'>City : {empdata.complaintLocationCity}</label>
                        <br></br>
                        <label htmlFor='' id='LabelId'>Pincode : {empdata.complaintLocationPincode}</label>
                        <br></br>

                    </div>
                    <div className='ComplaintInfoPart1'>
                    <h3>Details of Complainant</h3>
                    <label htmlFor='' id='LabelId'>Complainant Name: {empdata.complainantName}</label>
                        <br></br>
                        <label htmlFor='' id='LabelId'>Ward: {empdata.complainantAddressWard}</label>
                        <br></br>
                        <label htmlFor='' id='LabelId'>House N0. : {empdata.complainantAddressHouseNo}</label>
                        <br></br>
                        <label htmlFor='' id='LabelId'>House Name: {empdata.complainantAddressHouseName}</label>
                        <br></br>
                        <label htmlFor='' id='LabelId'>Area in Address : {empdata.complainantAddressAreaInAddress}</label>
                        <br></br>
                        <label htmlFor='' id='LabelId'>Zone / Ward No. : {empdata.complainantAddressZoneWardNo}</label>
                        <br></br>
                        <label htmlFor='' id='LabelId'>Area 1: {empdata.complainantAddressArea1}</label>
                        <br></br>
                        <label htmlFor='' id='LabelId'>Area 2: {empdata.complainantAddressArea2}</label>
                        <br></br>
                        <label htmlFor='' id='LabelId'>LandMark: {empdata.complainantAddressLandmark}</label>
                        <br></br>
                        <label htmlFor='' id='LabelId'>City: {empdata.complainantAddressCity}</label>
                        <br></br>
                        <label htmlFor='' id='LabelId'>State: {empdata.complainantAddressState}</label>
                        <br></br>
                        <label htmlFor='' id='LabelId'>Country: {empdata.complainantAddressCountry}</label>
                        <br></br>
                        <label htmlFor='' id='LabelId'>STD Code: {empdata.complainantAddressSTDCodeOfficeTelephone}</label>
                        <br></br>
                        <label htmlFor='' id='LabelId'>Telephone (Off.): {empdata.complainantAddressOfficeTelephone}</label>
                        <br></br>
                        <label htmlFor='' id='LabelId'>STD Code: {empdata.complainantAddressSTDCodeResidenceTelephone}</label>
                        <br></br>
                        <label htmlFor='' id='LabelId'>Telephone (Res.): {empdata.complainantAddressResidenceTelephone}</label>
                        <br></br>
                        <label htmlFor='' id='LabelId'>Mobile No. : {empdata.phoneNumber}</label>
                        <br></br>
                        <label htmlFor='' id='LabelId'>Email Address: {empdata.email}</label>
                        <br></br>
                        <label htmlFor='' id='LabelId'>Photo: <img src={empdata.photoUrl} width="200px" height="200px" /></label>

                    </div>


                    {/* } */}

                </div>
                <Link className="btn btn-danger" to="/admin">Back to Listing</Link>
            </form>
            
        </div >
    );
}

export default EmpDetail;