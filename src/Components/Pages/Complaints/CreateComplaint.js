import React, { useEffect, useRef, useState } from 'react'
import axios from 'axios';
import PreviewImage from '../Complaints/PreviewImage';
import { useNavigate } from 'react-router-dom';

function CreateComplaint() {

  const [language, setLanguage] = useState();
  const [city, setCity] = useState('');
  const [complaintType, setCompliantType] = useState('');
  const [complaintSubtype, setComplaintSubtype] = useState('');
  const [description, setDescription] = useState('');
  const [complaintLocationHouseNo, setComplaintLocationHouseNo] = useState('');
  const [complaintLocationHouseName, setComplaintLocationHouseName] = useState('');
  const [complaintLocationAreaInAddress, setComplaintLocationAreaInAddress] = useState('');
  const [complaintLocationZoneWardNo, setComplaintLocationZoneWardNo] = useState('');
  const [complaintLocationArea1, setComplaintLocationArea1] = useState('');
  const [complaintLocationArea2, setComplaintLocationArea2] = useState('');
  const [complaintLocationCity, setComplaintLocationCity] = useState('');
  const [complaintLocationPincode, setComplaintLocationPincode] = useState('');
  const [complainantName, setComplainantName] = useState('');
  const [complainantAddressWard, setComplainantAddressWard] = useState('');
  const [complainantAddressHouseNo, setComplainantAddressHouseNo] = useState('');
  const [complainantAddressHouseName, setComplainantAddressHouseName] = useState('');
  const [complainantAddressAreaInAddress, setComplainantAddressAreaInAddress] = useState('');
  const [complainantAddressZoneWardNo, setComplainantAddressZoneWardNo] = useState('');
  const [complainantAddressArea1, setComplainantAddressArea1] = useState('');
  const [complainantAddressArea2, setComplainantAddressArea2] = useState('');
  const [complainantAddressLandmark, setComplainantAddressLandmark] = useState('');
  const [complainantAddressCity, setComplainantAddressCity] = useState('');
  const [complainantAddressState, setComplainantAddressState] = useState('');
  const [complainantAddressCountry, setComplainantAddressCountry] = useState('');
  const [complainantAddressSTDCodeOfficeTelephone, setComplainantAddressSTDCodeOfficeTelephone] = useState('');
  const [complainantAddressOfficeTelephone, setComplainantAddressOfficeTelephone] = useState('');
  const [complainantAddressSTDCodeResidenceTelephone, setComplainantAddressSTDCodeResidenceTelephone] = useState('');
  const [complainantAddressResidenceTelephone, setComplainantAddressResidenceTelephone] = useState('');
  const [phoneNumber, setPhoneNumber] = useState('');
  const [email, setEmail] = useState('');
  const [image, setImage] = useState('');
  const navigate = useNavigate();


  const handleChange = (event) => {
    console.log(event.target.files)
    setImage(event.target.files[0])
  }

  const handleApi = (event) => {
    event.preventDefault()
    axios.post('https://localhost:5001/api/Complaints',{
      ComplaintType: complaintType,
      ComplaintSubtype: complaintSubtype,
      DescriptionofComplaint: description,
      ComplaintLocationHouseNo: complaintLocationHouseNo,
      ComplaintLocationHouseName: complaintLocationHouseName,
      ComplaintLocationAreaInAddress: complaintLocationAreaInAddress,
      ComplaintLocationZoneWardNo: complaintLocationZoneWardNo,
      ComplaintLocationArea1: complaintLocationArea1,
      ComplaintLocationArea2: complaintLocationArea2,
      ComplaintLocationCity: complaintLocationCity,
      ComplaintLocationPincode: complaintLocationPincode,
      ComplainantName: complainantName,
      ComplainantAddressWard: complainantAddressWard,
      ComplainantAddressHouseNo: complainantAddressHouseNo,
      ComplainantAddressHouseName: complainantAddressHouseName,
      ComplainantAddressAreaInAddress: complainantAddressAreaInAddress,
      ComplainantAddressZoneWardNo: complainantAddressZoneWardNo,
      ComplainantAddressArea1: complainantAddressArea1,
      ComplainantAddressArea2: complainantAddressArea2,
      ComplainantAddressLandmark: complainantAddressLandmark,
      ComplainantAddressCity: complainantAddressCity,
      ComplainantAddressState: complainantAddressState,
      ComplainantAddressCountry: complainantAddressCountry,
      ComplainantAddressSTDCodeOfficeTelephone: complainantAddressSTDCodeOfficeTelephone,
      ComplainantAddressOfficeTelephone: complainantAddressOfficeTelephone,
      ComplainantAddressSTDCodeResidenceTelephone: complainantAddressSTDCodeResidenceTelephone,
      ComplainantAddressResidenceTelephone: complainantAddressResidenceTelephone,
      PhoneNumber: phoneNumber,
      Email: email

    })
      .then(result=>{
        console.log(result)
        navigate('/loggedin');
      })
      .catch(error=>{
        console.log(error)
      })
    
  }

  const handleSubmit = (event) => {
    event.preventDefault()
    const url = 'https://localhost:5001/api/photos';
    const formData = new FormData();
    formData.append('file', image);
    formData.append('fileName', image.name);
    // const config = {
    //   headers: {
    //     'Content-type': 'Content-type',
    //   },
    // };
    axios.post(url, formData).then((response) => {
      console.log(response.data);
    });

  }

  return (
    <>
      <form>
        <div className='ComplaintFormLayout'>

          <h1>Application for Complaint / Grievance</h1>
          <div className='ComplaintFormPart1'>
            <h3>Please Select Language and City Below / अपनी भाषा और शहर चुनें</h3>
            <br></br>
            <label htmlFor=''>Please Select Language / अपनी भाषा चुनें</label>
            <select value={language} onChange={(e) => setLanguage(e.target.value)}>

              <option value="English">English / अंग्रेज़ी</option>
              <option value="Hindi">Hindi / हिंदी</option>

            </select>
            <br></br>
            <label htmlFor=''>Please Select City / अपना शहर चुनें</label>
            <select value={city} onChange={(e) => setCity(e.target.value)}>

              <option value="AALOT NAGAR PARISHAD">AALOT NAGAR PARISHAD / आलोट नगर परिषद</option>
              <option value="AGAR NAGAR PALIKA">AGAR NAGAR PALIKA / आगर नगर पालिका</option>
              <option value="BETUL BAZAR NAGAR PARISHAD">BETUL BAZAR NAGAR PARISHAD / बेतुल बाजार नगर परिषद्</option>
              <option value="BEGUMGANJ NAGAR PALIKA">BEGUMGANJ NAGAR PALIKA / बेगमगंज नगर पालिका</option>
              <option value="CHANDERI NAGAR PALIKA">CHANDERI NAGAR PALIKA / चंदेरी नगर पालिका</option>
              <option value="CHICHOLI NAGAR PARISHAD">CHICHOLI NAGAR PARISHAD / चिचोली नगर परिषद्</option>
              <option value="DHAR NAGAR PALIKA">DHAR NAGAR PALIKA / धार नगर पालिका</option>
              <option value="DINDORI NAGAR PARISHAD">DINDORI NAGAR PARISHAD / डिंडोरी नगर परिषद्</option>

            </select>

          </div>
          <br></br>
          <div className='ComplaintFormPart2'>
            <h3>Define Nature Of Your Complaint</h3>
            <br></br>
            <label htmlFor=''>Select Your Complaint Type:</label>
            <select value={complaintType} onChange={(e) => setCompliantType(e.target.value)}>

              <option value="SEWAGE">SEWAGE</option>
              <option value="COMPOST WITH DRIED LEAVES">COMPOST WITH DRIED LEAVES</option>
              <option value="GARBAGE COLLECTION">GARBAGE COLLECTION</option>


            </select>
            <br></br>
            <label htmlFor=''>Select complaint subtype: </label>
            <select value={complaintSubtype} onChange={(e) => setComplaintSubtype(e.target.value)}>

              <option value="REPAIRING">REPAIRING</option>
              <option value="ALL COMPLAINTS RELATED TO SEWAGEGUTTER">ALL COMPLAINTS RELATED TO SEWAGE / GUTTER</option>
              <option value="COMPOST WITH DRIED LEAVES">COMPOST WITH DRIED LEAVES</option>
              <option value="OVERFLOW OF BINS">OVERFLOW OF BINS</option>
              <option value="DELAY IN GARBAGE COLLECTION">DELAY IN GARBAGE COLLECTION</option>


            </select>
            <br></br>
            <label htmlFor="">Description In Brief: </label>
            <textarea value={description} onChange={(e) => setDescription(e.target.value)} cols='30' rows='10'></textarea>

          </div>
          <br></br>
          <div className='ComplaintFormPart3'>
            <h3>Specify Location Of Your Complaint</h3>
            <label for="HouseNo">House No.:</label>
            <input value={complaintLocationHouseNo} onChange={(e) => setComplaintLocationHouseNo(e.target.value)} type="text" id="HouseNo" name="HouseNo"></input>
            <br></br>
            <label for="HouseName">House Name:</label>
            <input value={complaintLocationHouseName} onChange={(e) => setComplaintLocationHouseName(e.target.value)} type="text" id="HouseName" name="HouseName"></input>
            <br></br>
            <label for="AreaInAddress">Area in Address:</label>
            <input value={complaintLocationAreaInAddress} onChange={(e) => setComplaintLocationAreaInAddress(e.target.value)} type="text" id="AreaInAddress" name="AreaInAddress"></input>
            <br></br>
            <label for="ZoneWardNo">Zone No./ Ward No.:</label>
            <input value={complaintLocationZoneWardNo} onChange={(e) => setComplaintLocationZoneWardNo(e.target.value)} type="text" id="ZoneWardNo" name="ZoneWardNo"></input>
            <br></br>
            <label for="Area1">Area 1:</label>
            <input value={complaintLocationArea1} onChange={(e) => setComplaintLocationArea1(e.target.value)} type="text" id="Area1" name="Area1"></input>
            <br></br>
            <label for="Area2">Area 2:</label>
            <input value={complaintLocationArea2} onChange={(e) => setComplaintLocationArea2(e.target.value)} type="text" id="Area2" name="Area2"></input>
            <br></br>
            <label for="City">City:</label>
            <input value={complaintLocationCity} onChange={(e) => setComplaintLocationCity(e.target.value)} type="text" id="City" name="City"></input>
            <br></br>
            <label for="Pincode">Pincode:</label>
            <input value={complaintLocationPincode} onChange={(e) => setComplaintLocationPincode(e.target.value)} type="text" id="Pincode" name="Pincode"></input>
            <br></br>

          </div>
          <br></br>
          <div className='ComplaintFormPart4'>
            <h3>Name of Complainant</h3>
            <label for="CName">Complainant Name:</label>
            <input value={complainantName} onChange={(e) => setComplainantName(e.target.value)} type="text" id="CName" name="CName"></input>
            <br></br>
          </div>
          <br></br>
          <div className='ComplaintFormPart5'>
            <h3>Address of Complainant</h3>
            <label htmlFor=''>Select ward:</label>
            <select value={complainantAddressWard} onChange={(e) => setComplainantAddressWard(e.target.value)}>

              <option value="Ward1">WARD 1</option>
              <option value="Ward2">WARD 2</option>
              <option value="Ward3">WARD 3</option>
              <option value="Ward4">WARD 4</option>
              <option value="Ward5">WARD 5</option>
              <option value="Ward6">WARD 6</option>


            </select>
            <br></br>
            <label for="HouseNum">House No.:</label>
            <input value={complainantAddressHouseNo} onChange={(e) => setComplainantAddressHouseNo(e.target.value)} type="text" id="HouseNum" name="HouseNum"></input>
            <br></br>
            <label for="HouseName">House Name:</label>
            <input value={complainantAddressHouseName} onChange={(e) => setComplainantAddressHouseName(e.target.value)} type="text" id="HouseName" name="HouseName"></input>
            <br></br>
            <label for="AreaInAdd">Area in Address:</label>
            <input value={complainantAddressAreaInAddress} onChange={(e) => setComplainantAddressAreaInAddress(e.target.value)} type="text" id="AreaInAdd" name="AreaInAdd"></input>
            <br></br>
            <label for="ZoneWardNum">Zone No./Ward No.:</label>
            <input value={complainantAddressZoneWardNo} onChange={(e) => setComplainantAddressZoneWardNo(e.target.value)} type="text" id="ZoneWardNum" name="ZoneWardNum"></input>
            <br></br>
            <label for="Ar1">Area 1:</label>
            <input value={complainantAddressArea1} onChange={(e) => setComplainantAddressArea1(e.target.value)} type="text" id="Ar1" name="Ar1"></input>
            <br></br>
            <label for="Ar2">Area 2:</label>
            <input value={complainantAddressArea2} onChange={(e) => setComplainantAddressArea2(e.target.value)} type="text" id="Ar2" name="Ar2"></input>
            <br></br>
            <label for="LandMark">LandMark:</label>
            <input value={complainantAddressLandmark} onChange={(e) => setComplainantAddressLandmark(e.target.value)} type="text" id="LandMark" name="LandMark"></input>
            <br></br>
            <label for="CityName">City:</label>
            <input value={complainantAddressCity} onChange={(e) => setComplainantAddressCity(e.target.value)} type="text" id="CityName" name="CityName"></input>
            <br></br>
            <label for="State">State:</label>
            <input value={complainantAddressState} onChange={(e) => setComplainantAddressState(e.target.value)} type="text" id="State" name="State"></input>
            <br></br>
            <label for="Country">Country:</label>
            <input value={complainantAddressCountry} onChange={(e) => setComplainantAddressCountry(e.target.value)} type="text" id="Country" name="Country"></input>
            <br></br>
            <label for="STDCodeOffice">(STD Code)</label>
            <input value={complainantAddressSTDCodeOfficeTelephone} onChange={(e) => setComplainantAddressSTDCodeOfficeTelephone(e.target.value)} type="text" id="STDCodeOffice" name="STDCodeOffice"></input>
            <br></br>
            <label for="TelephoneOffice">Telephone (Off.):</label>
            <input value={complainantAddressOfficeTelephone} onChange={(e) => setComplainantAddressOfficeTelephone(e.target.value)} type="text" id="TelephoneOffice" name="TelephoneOffice"></input>
            <br></br>
            <label for="STDCodeResidence">(STD Code)</label>
            <input value={complainantAddressSTDCodeResidenceTelephone} onChange={(e) => setComplainantAddressSTDCodeResidenceTelephone(e.target.value)} type="text" id="STDCodeResidence" name="STDCodeResidence"></input>
            <br></br>
            <label for="TelephoneResidence">Telephone (Res.):</label>
            <input value={complainantAddressResidenceTelephone} onChange={(e) => setComplainantAddressResidenceTelephone(e.target.value)} type="text" id="TelephoneResidence" name="TelephoneResidence"></input>
            <br></br>
            <label for="MobileNumber">Mobile No.</label>
            <input value={phoneNumber} onChange={(e) => setPhoneNumber(e.target.value)} type="text" id="MobileNumber" name="MobileNumber"></input>
            <br></br>
            <label for="EMailAddress">E-Mail Address:</label>
            <input value={email} onChange={(e) => setEmail(e.target.value)} type="text" id="EMailAddress" name="EMailAddress"></input>
            <br></br>
          </div>
          <br></br>
          <div className='ComplaintFormPart6'>
            
              <h3>Upload Documents: दस्तावेज़ अपलोड करें/</h3>
              <label for="Photo">Upload Photo:</label>
              <br></br>
              <input type="file" onChange={handleChange} name="img" />
              <br></br>
              {image && <PreviewImage file={image} />}
              
              <button onClick={handleSubmit}>Upload</button>
              <button onClick={handleApi}>Submit Complaint Form</button>
            

          </div>

        </div>
      </form>

    </>
  )
}
export default CreateComplaint;


