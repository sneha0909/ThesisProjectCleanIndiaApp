import React, { useEffect, useState } from "react";


function ComplaintStatus() {

    const [selectCity, setCity] = useState("AALOT NAGAR PARISHAD");
    const [selectComplaintType, setCompliantType] = useState("SEWAGE");
    const [selectWard, setWard] = useState("");

    return (
        <>
            <div className="SearchByComplainNumber">
                <h1>Complaint Status</h1>
                <a>Fields Marked with * are Mandatory Fields</a>
                <a> To search, Please select either 'Search by Complaint No.' OR 'Search by Details'</a>
                <br></br>
                <input type="radio" value="SearchbyComplaintNo" name="searchComplaint" /> Search by Complaint No.
                <input type="text" id="ComplaintNo" name="ComplaintNo"></input>
                <br></br>
                <input type="radio" value="Female" name="SearchbyComplaintDetails" /> Search by Details

            </div>
            <br></br>
            <div className="SearchByComplaintDetails">
                <label htmlFor=''>Select Your City / अपना शहर चुनें</label>
                <select value={selectCity} onChange={(e) => setCity(e.target.value)}>

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
                <label htmlFor=''>Select Your Complaint Type:</label>
                <select value={selectComplaintType} onChange={(e) => setCompliantType(e.target.value)}>

                    <option value="SEWAGE">SEWAGE</option>
                    <option value="COMPOST WITH DRIED LEAVES">COMPOST WITH DRIED LEAVES</option>
                    <option value="GARBAGE COLLECTION">GARBAGE COLLECTION</option>


                </select>
                <br></br>
                <label htmlFor=''>Select ward:</label>
                <select value={selectWard} onChange={(e) => setWard(e.target.value)}>

                    <option value="Ward1">WARD 1</option>
                    <option value="Ward2">WARD 2</option>
                    <option value="Ward3">WARD 3</option>
                    <option value="Ward4">WARD 4</option>
                    <option value="Ward5">WARD 5</option>
                    <option value="Ward6">WARD 6</option>

                </select>
                <br></br>

                <label for="fName">Name of Complainant</label>
                <input type="text" id="fName" name="fName" placeholder="First Name"></input>
                 
                <input type="text" id="lName" name="lName"  placeholder="Last Name"></input>
                <br></br>
                <br></br>
                <label for="fName">Date of Complaint</label>
                <br></br>
                <label for="fDate">From:</label>
                <input type="text" id="fromDate" name="fromDate"></input>
                <br></br> 
                <label for="tDate">To:</label> 
                <input type="text" id="toDate" name="toDate"></input>
                <br></br>
                <label for="mobileComplainant">Complainant Mobile Number</label>
                <input type="text" id="coomplaintNo" name="coomplaintNo" ></input>
                <br></br>

                <input type="submit" id="Submit" name="Submit" value="Get Status"></input>

            </div>

        </>

    );
}

export default ComplaintStatus;