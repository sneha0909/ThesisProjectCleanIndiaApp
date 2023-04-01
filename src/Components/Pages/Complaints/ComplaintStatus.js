import React, { useEffect, useState } from "react";
import Datepickertofrom from "./Datepickertofrom";
import axios from 'axios';
import '../Complaints/ComplaintStatus.css';


function ComplaintStatus() {

    const [City, setCity] = useState("");
    const [ComplaintType, setCompliantType] = useState("");
    const [Ward, setWard] = useState("");
    const [ComplaintNo, setComplaintNo] = useState("");
    const [ComplainantName, setComplainantName] = useState("");
    const [Mobile, setMobile] = useState("");
    const [results, setResults] = useState([]);
    const [error, setError] = useState(false);
    const [detailsError, setdetailsError] = useState(false);


    const keys = ["complainantName", "complaintLocationCity", "complaintType", "complainantAddressWard", "phoneNumber"]



    //  const fetchData = (value) => {
    //     fetch("https://localhost:5001/api/Complaints")
    //         .then((response) => response.json())
    //         .then(json => {
    //             //console.log(json);
    //             const results = json.filter((data) => {
    //                 return (keys.some(key=>data[key].toLowerCase().includes(value)))

    //             });
    //             console.log(results);
    //         });

    // }


    const fetchData = (value) => {
        fetch("https://localhost:5001/api/Complaints")
            .then((response) => response.json())
            .then(json => {
                //console.log(json);
                const results = json.filter((data) => {
                    return (
                        value &&
                        data &&
                        data.id &&
                        data.id)
                        .toUpperCase().includes(value)

                });
                console.log(results);
                setResults(results)
            });

    }

    const handleChange = (value) => {
        setComplaintNo(value)
        fetchData(value)
    }



    const findSelected = (opt) => {

        if (opt == "Search by Complaint No") {
            document.getElementById("inputtext").disabled = false;
            document.getElementById("inputCity").disabled = true;
            document.getElementById("inputComplaintType").disabled = true;
            document.getElementById("inputWard").disabled = true;
            document.getElementById("inputName").disabled = true;
            // document.getElementById("inputToDate").disabled = true;
            // document.getElementById("inputFromDate").disabled = true;   
            document.getElementById("inputMobile").disabled = true;
        }
        else {
            document.getElementById("inputtext").disabled = true;
            document.getElementById("inputCity").disabled = false;
            document.getElementById("inputComplaintType").disabled = false;
            document.getElementById("inputWard").disabled = false;
            document.getElementById("inputName").disabled = false;
            // document.getElementById("inputToDate").disabled = false;
            // document.getElementById("inputFromDate").disabled = false;    
            document.getElementById("inputMobile").disabled = false;
        }
    }

    const handleSubmit = (event) => {
        event.preventDefault();
        if(City.length == 0)
        {
            setError(true);

        }
            
    }

    return (
        <>
            <div className="SearchComplaint">
                <form>


                    <div className="SearchByComplainNumber">

                        <h1>Complaint Status</h1>
                        <span id="SubHeading"> To search, Please select either 'Search by Complaint No.' OR 'Search by Details'</span>
                        <br></br>

                        <input type="radio" value="SearchbyComplaintNo" name="Search" onChange={(e) => findSelected("Search by Complaint No", e)} /> Search by Complaint No
                        <input type="text" id="inputtext" name="ComplaintNo" value={ComplaintNo} onChange={(e) => handleChange(e.target.value)} disabled="disabled" ></input>
                        {
                            error && ComplaintNo.length <= 0 ? <label id='FieldEmptyError'>* Field required!</label> : ""
                        }
                        <br></br>
                        <input type="radio" value="SearchbyComplaintDetails" name="Search" onChange={(e) => findSelected("Search by Details", e)} /> Search by Details
                        


                    </div>
                    <br></br>
                    <div className="SearchByComplaintDetails" >

                        <span id='Required1'>*</span>
                        <label htmlFor='' id='LabelId'>Select Your City / अपना शहर चुनें</label>
                        <select id="inputCity" value={City} onChange={(e) => setCity(e.target.value)} disabled="disabled" className="ComplaintSearchInput">
                            <option value="" disabled></option>

                            <option value="AALOT NAGAR PARISHAD">AALOT NAGAR PARISHAD / आलोट नगर परिषद</option>
                            <option value="AGAR NAGAR PALIKA">AGAR NAGAR PALIKA / आगर नगर पालिका</option>
                            <option value="BETUL BAZAR NAGAR PARISHAD">BETUL BAZAR NAGAR PARISHAD / बेतुल बाजार नगर परिषद्</option>
                            <option value="BEGUMGANJ NAGAR PALIKA">BEGUMGANJ NAGAR PALIKA / बेगमगंज नगर पालिका</option>
                            <option value="CHANDERI NAGAR PALIKA">CHANDERI NAGAR PALIKA / चंदेरी नगर पालिका</option>
                            <option value="CHICHOLI NAGAR PARISHAD">CHICHOLI NAGAR PARISHAD / चिचोली नगर परिषद्</option>
                            <option value="DHAR NAGAR PALIKA">DHAR NAGAR PALIKA / धार नगर पालिका</option>
                            <option value="DINDORI NAGAR PARISHAD">DINDORI NAGAR PARISHAD / डिंडोरी नगर परिषद्</option>

                        </select>
                        {
                            error && City.length <= 0 ? <label id='FieldEmptyError'>* Field required!</label> : ""
                        }
                        <br></br>
                        <span id='Required1'>*</span>
                        <label htmlFor='' id='LabelId'>Select Your Complaint Type:</label>
                        <select id="inputComplaintType" value={ComplaintType} onChange={(e) => setCompliantType(e.target.value)} disabled="disabled" className="ComplaintSearchInput">
                            <option value="" disabled></option>

                            <option value="SEWAGE">SEWAGE</option>
                            <option value="COMPOST WITH DRIED LEAVES">COMPOST WITH DRIED LEAVES</option>
                            <option value="GARBAGE COLLECTION">GARBAGE COLLECTION</option>


                        </select>
                        {
                            error && ComplaintType.length <= 0 ? <label id='FieldEmptyError'>* Field required!</label> : ""
                        }
                        <br></br>
                        <span id='Required1'>*</span>
                        <label htmlFor='' id='LabelId'>Select ward:</label>
                        <select id="inputWard" value={Ward} onChange={(e) => setWard(e.target.value)} disabled="disabled" className="ComplaintSearchInput">
                            <option value="" disabled></option>

                            <option value="Ward1">WARD 1</option>
                            <option value="Ward2">WARD 2</option>
                            <option value="Ward3">WARD 3</option>
                            <option value="Ward4">WARD 4</option>
                            <option value="Ward5">WARD 5</option>
                            <option value="Ward6">WARD 6</option>

                        </select>
                        {
                            error && Ward.length <= 0 ? <label id='FieldEmptyError'>* Field required!</label> : ""
                        }
                        <br></br>

                        <span id='Required1'>*</span>
                        <label for="fName" id='LabelId'>Name of Complainant</label>
                        <input type="text" id="inputName" value={ComplainantName} onChange={(e) => setComplainantName(e.target.value)} disabled="disabled" className="ComplaintSearchInput"></input>
                        {
                            error && ComplainantName.length <= 0 ? <label id='ComplaintFieldEmptyError'>* Field required!</label> : ""
                        }
                        <br></br>
                        {/* <label for="fName">Date of Complaint</label>
                <br></br>
                <label for="fDate">From:</label>
                <input type="text" id="inputToDate" disabled="disabled"></input>
                <Datepickertofrom />
                <br></br>
                <label for="tDate">To:</label>
                <input type="text" id="inputFromDate" disabled="disabled"></input>
                <br></br> */}
                        <span id='Required1'>*</span>
                        <label for="mobileComplainant" id='LabelId'>Complainant Mobile Number</label>
                        <input type="text" id="inputMobile" value={Mobile} onChange={(e) => setMobile(e.target.value)} disabled="disabled" className="ComplaintSearchInput" ></input>
                        {
                            error && Mobile.length <= 0 ? <label id='ComplaintFieldEmptyError'>* Field required!</label> : ""
                        }
                        <br></br>

                        <button id="SubmitButton" onClick={handleSubmit}>Get Status</button>


                    </div>
                </form>
            </div>

        </>

    );
}

export default ComplaintStatus;