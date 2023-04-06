import React, { useState } from "react";
import '../Complaints/ComplaintStatus.css';
import { createSearchParams, useNavigate } from 'react-router-dom';


function ComplaintStatus() {

    const [City, setCity] = useState("");
    const [ComplaintType, setCompliantType] = useState("");
    const [Ward, setWard] = useState("");
    const [ComplaintNo, setComplaintNo] = useState("");
    const [ComplainantName, setComplainantName] = useState("");
    const [Mobile, setMobile] = useState("");
    const [search, setSearch] = useState("searchbyComplaintNo");
    const navigate = useNavigate();



    const handleSearch=(e)=>{
       const getsearch = e.target.value;
       setSearch(getsearch);   
    }

    const handleSubmit = (event) => {
        event.preventDefault();
        if(search === "searchbyComplaintNo")
        {
            if(ComplaintNo.length === 0)
            {
                alert('Please enter a Complaint Number!!!');
                
            }
            else
            {
                navigate("/admin/detail/" + ComplaintNo);

            }
          
        }
        if(search === "SearchbyComplaintDetails")
        {
            if( ComplaintType.length === 0 || ComplainantName.length === 0 || Mobile.length === 0)
            {
                alert('Please fill all the mandatory fields to search complaint by details!!!');
                
            }   

            else
            {
                
                // navigate("/trackingResults/" + ComplainantName + Mobile);
                navigate("/trackingResults/" + ComplaintType + "/" + ComplainantName + "/" + Mobile);

            }
            
        }
        
    }

    

    return (
        <>
            <div className="SearchComplaint">
                <form>


                    <div className="SearchByComplainNumber">

                        <h1>Complaint Status</h1>
                        <span id="SubHeading"> To search, Please select either 'Search by Complaint No.' OR 'Search by Details'</span>
                        <span id="SubHeading2"> Fields Marked with * are Mandatory Fields.'</span>
                        <br></br>

                        
                        <input type="radio" name="Search" value="searchbyComplaintNo" checked={search === 'searchbyComplaintNo'}  id="ComplaintNum" onClick={handleSearch} readOnly /> Search by Complaint No

                        <input type="text" id="inputtext" name="ComplaintNo" value={ComplaintNo}  onChange={(e) => setComplaintNo(e.target.value)}  disabled={search === "SearchbyComplaintDetails"} ></input>
                    
                        <br></br>

                        <input type="radio" name="Search" value="SearchbyComplaintDetails" id="ComplaintSearch" onClick={handleSearch}  /> Search by Details
                        


                    </div>
                    <br></br>
                    <div className="SearchByComplaintDetails" >

                        <span id='Required1'>*</span>
                        <label htmlFor='' id='LabelId'>Select Your City / अपना शहर चुनें</label>
                        <select id="inputCity" value={City} onChange={(e) => setCity(e.target.value)} disabled={search === "searchbyComplaintNo"} className="ComplaintSearchInput">
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
                        
                        <br></br>
                        <span id='Required1'>*</span>
                        <label htmlFor='' id='LabelId'>Select Your Complaint Type:</label>
                        <select id="inputComplaintType" value={ComplaintType} onChange={(e) => setCompliantType(e.target.value)} disabled={search === "searchbyComplaintNo"} className="ComplaintSearchInput">
                            <option value="" disabled></option>

                            <option value="SEWAGE">SEWAGE</option>
                            <option value="COMPOST WITH DRIED LEAVES">COMPOST WITH DRIED LEAVES</option>
                            <option value="GARBAGE COLLECTION">GARBAGE COLLECTION</option>


                        </select>
                        
                        <br></br>
                        <span id='Required1'>*</span>
                        <label htmlFor='' id='LabelId'>Select ward:</label>
                        <select id="inputWard" value={Ward} onChange={(e) => setWard(e.target.value)} disabled={search === "searchbyComplaintNo"} className="ComplaintSearchInput">
                            <option value="" disabled></option>

                            <option value="Ward1">WARD 1</option>
                            <option value="Ward2">WARD 2</option>
                            <option value="Ward3">WARD 3</option>
                            <option value="Ward4">WARD 4</option>
                            <option value="Ward5">WARD 5</option>
                            <option value="Ward6">WARD 6</option>

                        </select>
                    
                        <br></br>

                        <span id='Required1'>*</span>
                        <label htmlFor="fName" id='LabelId'>Name of Complainant</label>
                        <input type="text" id="inputName" value={ComplainantName} onChange={(e) => setComplainantName(e.target.value)} disabled={search === "searchbyComplaintNo"} className="ComplaintSearchInput"></input>
                        
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
                        <label htmlFor="mobileComplainant" id='LabelId'>Complainant Mobile Number</label>
                        <input type="text" id="inputMobile" value={Mobile} onChange={(e) => setMobile(e.target.value)} disabled={search === "searchbyComplaintNo"} className="ComplaintSearchInput" ></input>
                        
                        <br></br>

                        <button id="SubmitButton" onClick={handleSubmit}>Get Status</button>


                    </div>
                </form>
            </div>

        </>

    );
}

export default ComplaintStatus;