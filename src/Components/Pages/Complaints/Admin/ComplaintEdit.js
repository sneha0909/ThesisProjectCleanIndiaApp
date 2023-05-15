import { useEffect, useState } from "react";
import { useParams, useNavigate, Link } from "react-router-dom";
import axios from 'axios';
import '../Admin/ComplaintEdit.css';
import { Button } from 'semantic-ui-react';

const ComplaintEdit = () => {

    
    const { empid } = useParams();

    const navigate = useNavigate();

    const [city, setCity] = useState("");
    const [complaintType, setCompliantType] = useState("");
    const [complaintSubtype, setComplaintSubtype] = useState("");
    const [description, setDescription] = useState("");
    const [complaintLocationHouseNo, setComplaintLocationHouseNo] = useState("");
    const [complaintLocationHouseName, setComplaintLocationHouseName] = useState("");
    const [complaintLocationAreaInAddress, setComplaintLocationAreaInAddress] = useState("");
    const [complaintLocationZoneWardNo, setComplaintLocationZoneWardNo] = useState("");
    const [complaintLocationArea1, setComplaintLocationArea1] = useState("");
    const [complaintLocationArea2, setComplaintLocationArea2] = useState("");
    const [complaintLocationPincode, setComplaintLocationPincode] = useState("");
    const [complainantName, setComplainantName] = useState("");
    const [complainantAddressWard, setComplainantAddressWard] = useState("");
    const [complainantAddressHouseNo, setComplainantAddressHouseNo] = useState("");
    const [complainantAddressHouseName, setComplainantAddressHouseName] = useState("");
    const [complainantAddressAreaInAddress, setComplainantAddressAreaInAddress] = useState("");
    const [complainantAddressZoneWardNo, setComplainantAddressZoneWardNo] = useState("");
    const [complainantAddressArea1, setComplainantAddressArea1] = useState("");
    const [complainantAddressArea2, setComplainantAddressArea2] = useState("");
    const [complainantAddressLandmark, setComplainantAddressLandmark] = useState("");
    const [complainantAddressState, setComplainantAddressState] = useState("");
    const [complainantAddressCountry, setComplainantAddressCountry] = useState("");
    const [complainantAddressSTDCodeOfficeTelephone, setComplainantAddressSTDCodeOfficeTelephone] = useState("");
    const [complainantAddressOfficeTelephone, setComplainantAddressOfficeTelephone] = useState("");
    const [complainantAddressSTDCodeResidenceTelephone, setComplainantAddressSTDCodeResidenceTelephone] = useState("");
    const [complainantAddressResidenceTelephone, setComplainantAddressResidenceTelephone] = useState("");
    const [phoneNumber, setPhoneNumber] = useState("");
    const [email, setEmail] = useState("");
    const [image, setImage] = useState("");
    const [complaintStatus, setcomplaintStatus] = useState("");


    useEffect(() => {
         axios.get(`http://localhost:5000/api/complaints/${empid}`)
            .then(response => {
                console.log(response);
                setCompliantType(response.data.complaintType);
                setComplaintSubtype(response.data.complaintSubType);
                setDescription(response.data.descriptionofComplaint);
                setComplaintLocationHouseNo(response.data.complaintLocationHouseNo);
                setComplaintLocationHouseName(response.data.complaintLocationHouseName);
                setComplaintLocationAreaInAddress(response.data.complaintLocationAreaInAddress);
                setComplaintLocationZoneWardNo(response.data.complaintLocationZoneWardNo);
                setComplaintLocationArea1(response.data.complaintLocationArea1);
                setComplaintLocationArea2(response.data.complaintLocationArea2);
                setComplaintLocationPincode(response.data.complaintLocationPincode);
                setComplainantName(response.data.complainantName);
                setComplainantAddressWard(response.data.complainantAddressWard);
                setComplainantAddressHouseNo(response.data.complainantAddressHouseNo);
                setComplainantAddressHouseName(response.data.complainantAddressHouseName);
                setComplainantAddressAreaInAddress(response.data.complainantAddressAreaInAddress);
                setComplainantAddressZoneWardNo(response.data.complainantAddressZoneWardNo);
                setComplainantAddressArea1(response.data.complainantAddressArea1);
                setComplainantAddressArea2(response.data.complainantAddressArea2);
                setComplainantAddressLandmark(response.data.complainantAddressLandmark);
                setComplainantAddressState(response.data.complainantAddressState);
                setComplainantAddressCountry(response.data.complainantAddressCountry);
                setComplainantAddressSTDCodeOfficeTelephone(response.data.complainantAddressSTDCodeOfficeTelephone);
                setComplainantAddressOfficeTelephone(response.data.complainantAddressOfficeTelephone);
                setComplainantAddressSTDCodeResidenceTelephone(response.data.complainantAddressSTDCodeResidenceTelephone);
                setComplainantAddressResidenceTelephone(response.data.complainantAddressResidenceTelephone);
                setPhoneNumber(response.data.phoneNumber);
                setEmail(response.data.email);
                setImage(response.data.photoUrl);
                setcomplaintStatus(response.data.complaintStatus);
            }).catch((err) => {
                console.log(err.message);
            })
    }, []);


    const handleSubmit = (event) => {
        event.preventDefault();

        const formData = new FormData();
        formData.append('complaintType', complaintType);
        formData.append('complaintSubtype', complaintSubtype);
        formData.append('descriptionofComplaint', description);
        formData.append('complaintLocationHouseNo', complaintLocationHouseNo);
        formData.append('complaintLocationHouseName', complaintLocationHouseName);
        formData.append('complaintLocationAreaInAddress', complaintLocationAreaInAddress);
        formData.append('complaintLocationZoneWardNo', complaintLocationZoneWardNo);
        formData.append('complaintLocationArea1', complaintLocationArea1);
        formData.append('complaintLocationArea2', complaintLocationArea2);
        formData.append('complaintLocationCity', city);
        formData.append('complaintLocationPincode', complaintLocationPincode);
        formData.append('complainantName', complainantName);
        formData.append('complainantAddressWard', complainantAddressWard);
        formData.append('complainantAddressHouseNo', complainantAddressHouseNo);
        formData.append('complainantAddressHouseName', complainantAddressHouseName);
        formData.append('complainantAddressAreaInAddress', complainantAddressAreaInAddress);
        formData.append('complainantAddressZoneWardNo', complainantAddressZoneWardNo);
        formData.append('complainantAddressArea1', complainantAddressArea1);
        formData.append('complainantAddressArea2', complainantAddressArea2);
        formData.append('complainantAddressLandmark', complainantAddressLandmark);
        formData.append('complainantAddressCity', city);
        formData.append('complainantAddressState', complainantAddressState);
        formData.append('complainantAddressCountry', complainantAddressCountry);
        formData.append('complainantAddressSTDCodeOfficeTelephone', complainantAddressSTDCodeOfficeTelephone);
        formData.append('complainantAddressOfficeTelephone', complainantAddressOfficeTelephone);
        formData.append('complainantAddressSTDCodeResidenceTelephone', complainantAddressSTDCodeResidenceTelephone);
        formData.append('complainantAddressResidenceTelephone', complainantAddressResidenceTelephone);
        formData.append('phoneNumber', phoneNumber);
        formData.append('email', email);
        formData.append('pictureUrl', image);
        formData.append('complaintStatus', complaintStatus);

        axios.put(`http://localhost:5000/api/complaints/${empid}`, formData).then((response) => {
            console.log(response.data);
            alert('Changed the Complaint Status successfully')
        })
            .catch(error => {
                console.log(error)
            });

    }

    

    return (
        <div className="Status">
            <form id="EditComplaint">



                <div className="ComplaintStatus">
                    <label htmlFor='' id='LabelId'>Current Complaint Status: <a>{complaintStatus}</a> </label>

                </div>

                <div className="ComplaintStatus">
                    <label htmlFor='' id="ChangeStatus">Change Status:</label>
                    <select value={complaintStatus} onChange={(e) => setcomplaintStatus(e.target.value)}>

                        <option value="" disabled></option>
                        <option value="In Review">In Review</option>
                        <option value="Action Taken">Action Taken</option>
                        <option value="Complaint Resolved">Complaint Resolved</option>
                        <option value="Feedback">Feedback</option>


                    </select>

                </div>
                <div className="ComplaintStatus">
                    <button id='ComplaintSubmitButton' onClick={handleSubmit}>Submit</button>

                </div>

                <div className="ComplaintStatus">

                    <Link to="/admin">
                        <Button>
                            <p>Go Back to Dashboard!</p>
                        </Button>
                    </Link>

                </div>


            </form>



        </div>


    );
}

export default ComplaintEdit;
