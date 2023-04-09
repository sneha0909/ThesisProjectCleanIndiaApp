import React, { useEffect, useRef, useState } from 'react'
import axios from 'axios';
import PreviewImage from '../Complaints/PreviewImage';
import { useNavigate } from 'react-router-dom';
import '../Complaints/CreateComplaint.css';
import { useTranslation } from 'react-i18next';

function CreateComplaint() {

  // It is a hook imported from 'react-i18next'
  const { t } = useTranslation();
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
  const [complainantAddressState, setComplainantAddressState] = useState('Madhya Pradesh');
  const [complainantAddressCountry, setComplainantAddressCountry] = useState('India');
  const [complainantAddressSTDCodeOfficeTelephone, setComplainantAddressSTDCodeOfficeTelephone] = useState('');
  const [complainantAddressOfficeTelephone, setComplainantAddressOfficeTelephone] = useState('');
  const [complainantAddressSTDCodeResidenceTelephone, setComplainantAddressSTDCodeResidenceTelephone] = useState('');
  const [complainantAddressResidenceTelephone, setComplainantAddressResidenceTelephone] = useState('');
  const [phoneNumber, setPhoneNumber] = useState('');
  const [email, setEmail] = useState('');
  const [image, setImage] = useState(null);
  const navigate = useNavigate();
  const [showhide, setShowhide] = useState('');
  const [error, setError] = useState(false);
  const [complaintStatus, setcomplaintStatus] = useState("Complaint Filed");


  // Contains the value and text for the options
  const languages = [
    { value: '', text: "Options" },
    { value: 'en', text: "English" },
    { value: 'hi', text: "Hindi" },
    { value: 'bn', text: "Bengali" },
    { value: 'gu', text: "Gujarati" },
    { value: 'kn', text: "Kannada" },
    { value: 'ml', text: "Malayalam" },
    { value: 'mr', text: "Marathi" },
    { value: 'ne', text: "Nepali" },
    { value: 'or', text: "Oriya" },
    { value: 'pa', text: "Punjabi" },
    { value: 'ta', text: "Tamil" },
    { value: 'te', text: "Telugu" },

  ]

  const handleChangeLanguage = (e) => {
    setLanguage(e.target.value);
    let loc = "http://localhost:3000/createComplaint";
    window.location.replace(loc + "?lng=" + e.target.value);
  }

  const handleChange = (event) => {
    console.log(event.target.files)
    setImage(event.target.files[0])
  }

  const handleshowhide = (event) => {
    setCity(event.target.value);
    const getoption = event.target.value;
    setShowhide(getoption);

  }

  const handleSubmit = (event) => {
    event.preventDefault();
    if(complaintType.length==0)
    {
      setError(true);
    }
    const url = 'https://localhost:5001/api/Complaints';
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
    // formData.append('fileName', image.name);
    // const config = {
    //   headers: {
    //     'Content-type': 'Content-type',
    //   },
    // };
    axios.post(url, formData).then((response) => {
      console.log(response.data);
      navigate('/loggedin');
    })
      .catch(error => {
        console.log(error)
      });

  }

  return (
    <>

      <div className='ComplaintFormLayout'>
        <form>

          <h1>Application for Complaint / Grievance</h1>
          <div className='ComplaintFormPart1'>
            <h3>Please Select Language and City Below / अपनी भाषा और शहर चुनें</h3>
            <br></br>
            <span id='RequiredMark'>*</span>
            <label htmlFor='' id='LabelMargin'>Please Select Language / अपनी भाषा चुनें</label>
            <select value={language} onChange={handleChangeLanguage} id='ComplaintInput'>
              {languages.map(item => {
                return (<option key={item.value}
                  value={item.value}>{item.text}</option>);
              })}

              {/* <option value="" disabled>""</option>
              <option value="en">English</option>
              <option value="hi">Hindi</option>
              <option value="be">Bengali</option>
              <option value="gu">Gujarati</option>
              <option value="kn">Kannada</option>
              <option value="ml">Malayalam</option>
              <option value="mr">Marathi</option>
              <option value="ne">Nepali</option>
              <option value="or">Oriya</option>
              <option value="pa">Punjabi</option>
              <option value="ta">Tamil</option>
              <option value="te">Telugu</option> */}
            </select>
            <br></br>
            <span id='RequiredMark'>*</span>
            <label htmlFor='' id='LabelMargin'>Please Select City / अपना शहर चुनें</label>
            <select value={city} onChange={(e) => (handleshowhide(e))} id='ComplaintInput'>

              <option value="" disabled></option>
              <option value="AALOT NAGAR PARISHAD  / आलोट नगर परिषद">AALOT NAGAR PARISHAD / आलोट नगर परिषद</option>
              <option value="AGAR NAGAR PALIKA  / आगर नगर पालिका">AGAR NAGAR PALIKA / आगर नगर पालिका</option>
              <option value="BETUL BAZAR NAGAR PARISHAD / बेतुल बाजार नगर परिषद्">BETUL BAZAR NAGAR PARISHAD / बेतुल बाजार नगर परिषद्</option>
              <option value="BEGUMGANJ NAGAR PALIKA / बेगमगंज नगर पालिका">BEGUMGANJ NAGAR PALIKA / बेगमगंज नगर पालिका</option>
              <option value="CHANDERI NAGAR PALIKA / चंदेरी नगर पालिका">CHANDERI NAGAR PALIKA / चंदेरी नगर पालिका</option>
              <option value="CHICHOLI NAGAR PARISHAD / चिचोली नगर परिषद्">CHICHOLI NAGAR PARISHAD / चिचोली नगर परिषद्</option>
              <option value="DHAR NAGAR PALIKA / धार नगर पालिका">DHAR NAGAR PALIKA / धार नगर पालिका</option>
              <option value="DINDORI NAGAR PARISHAD / डिंडोरी नगर परिषद्">DINDORI NAGAR PARISHAD / डिंडोरी नगर परिषद्</option>

            </select>

          </div>

          {/* {
            showhide === "AALOT NAGAR PARISHAD"  && ( */}


               <br></br>
              <div className='HiddenComplaintForm'>
                <div className='ComplaintFormPart2'>
                  <h3>{t('Define Nature Of Your Complaint')}</h3>
                  <br></br>
                  <span id='RequiredMark'>*</span>
                  <label htmlFor='' id='LabelMargin'>{t('Select Your Complaint Type:')}</label>
                  <select value={complaintType} onChange={(e) => setCompliantType(e.target.value)} id='ComplaintInput' >

                    <option value="" disabled></option>
                    <option value="SEWAGE">{t('SEWAGE')}</option>
                    <option value="COMPOST WITH DRIED LEAVES">{t('COMPOST WITH DRIED LEAVES')}</option>
                    <option value="GARBAGE COLLECTION">{t('GARBAGE COLLECTION')}</option>


                  </select>
                  {
                    error&&complaintType.length<=0 ? <label id='ComplaintFieldEmptyError'>* Field required!</label>:"" 
                  }
                  
                  <br></br>
                  <span id='RequiredMark'>*</span>
                  <label htmlFor='' id='LabelMargin'>{t('Select complaint subtype:')} </label>
                  <select value={complaintSubtype} onChange={(e) => setComplaintSubtype(e.target.value)} id='ComplaintInput' >

                    <option value="" disabled></option>
                    <option value="REPAIRING">{t('REPAIRING')}</option>
                    <option value="ALL COMPLAINTS RELATED TO SEWAGEGUTTER">{t('ALL COMPLAINTS RELATED TO SEWAGEGUTTER')}</option>
                    <option value="COMPOST WITH DRIED LEAVES">{t('COMPOST WITH DRIED LEAVES')}</option>
                    <option value="OVERFLOW OF BINS">{t('OVERFLOW OF BINS')}</option>
                    <option value="DELAY IN GARBAGE COLLECTION">{t('DELAY IN GARBAGE COLLECTION')}</option>


                  </select>
                  {
                    error&&complaintSubtype.length<=0 ? <label id='ComplaintFieldEmptyError'>* Field required!</label>:"" 
                  }
                  <br></br>
                  <span id='RequiredMark'>*</span>
                  <label htmlFor="" id='LabelMargin'>{t('Description In Brief:')} </label>
                  <textarea value={description} onChange={(e) => setDescription(e.target.value)} cols='30' rows='10' required id='ComplaintInput'></textarea>
                  {
                    error&&description.length<=0 ? <label id='ComplaintFieldEmptyError'>* Field required!</label>:"" 
                  }

                </div>
                <br></br>
                <div className='ComplaintFormPart3'>
                  <h3>{t('Specify Location Of Your Complaint')}</h3>
                  <span id='RequiredMark'>*</span>
                  <label for="HouseNo" id='LabelMargin'>{t('House No.:')}</label>
                  
                  <input value={complaintLocationHouseNo} onChange={(e) => setComplaintLocationHouseNo(e.target.value)} type="text" id='ComplaintInput' name="HouseNo"></input>
                  {
                    error&&complaintLocationHouseNo.length<=0 ? <label id='ComplaintFieldEmptyError'>* Field required!</label>:"" 
                  }
                  <br></br>
                  <span id='RequiredMark'>*</span>
                  <label for="HouseName" id='LabelMargin'>{t('House Name')}</label>
                  <input value={complaintLocationHouseName} onChange={(e) => setComplaintLocationHouseName(e.target.value)} type="text" id='ComplaintInput' name="HouseName"></input>
                  {
                    error&&complaintLocationHouseName.length<=0 ? <label id='ComplaintFieldEmptyError'>* Field required!</label>:"" 
                  }
                  <br></br>
                  <span id='RequiredMark'>*</span>
                  <label for="AreaInAddress" id='LabelMargin'>{t('Area in Address')}</label>
                  <input value={complaintLocationAreaInAddress} onChange={(e) => setComplaintLocationAreaInAddress(e.target.value)} type="text" id='ComplaintInput' name="AreaInAddress"></input>
                  {
                    error&&complaintLocationAreaInAddress.length<=0 ? <label id='ComplaintFieldEmptyError'>* Field required!</label>:"" 
                  }
                  <br></br>
                  <span id='RequiredMark'>*</span>
                  <label for="ZoneWardNo" id='LabelMargin'>{t('ZoneNumWardNum')}</label>
                  <input value={complaintLocationZoneWardNo} onChange={(e) => setComplaintLocationZoneWardNo(e.target.value)} type="text" id='ComplaintInput' name="ZoneWardNo"></input>
                  {
                    error&&complaintLocationZoneWardNo.length<=0 ? <label id='ComplaintFieldEmptyError'>* Field required!</label>:"" 
                  }
                  <br></br>
                  <span id='RequiredMark'>*</span>
                  <label for="Area1" id='LabelMargin'>{t('Area 1')}</label>
                  <input value={complaintLocationArea1} onChange={(e) => setComplaintLocationArea1(e.target.value)} type="text" id='ComplaintInput' name="Area1"></input>
                  {
                    error&&complaintLocationArea1.length<=0 ? <label id='ComplaintFieldEmptyError'>* Field required!</label>:"" 
                  }
                  <br></br>
                  <span id='RequiredMark'>*</span>
                  <label for="Area2" id='LabelMargin'>{t('Area 2')}</label>
                  <input value={complaintLocationArea2} onChange={(e) => setComplaintLocationArea2(e.target.value)} type="text" id='ComplaintInput' name="Area2"></input>
                  {
                    error&&complaintLocationArea2.length<=0 ? <label id='ComplaintFieldEmptyError'>* Field required!</label>:"" 
                  }
                  <br></br>
                  <span id='RequiredMark'>*</span>
                  <label for="City" id='LabelMargin'>{t('City')}</label>
                  <input value={city} onChange={(e) => setCity(e.target.value)} id='ComplaintInput' name='CityName' readOnly></input>
                  {
                    error&&city.length<=0 ? <label id='ComplaintFieldEmptyError'>* Field required!</label>:"" 
                  }
                  <br></br>
                  <span id='RequiredMark'>*</span>
                  <label for="Pincode" id='LabelMargin'>{t('Pincode')}</label>
                  <input value={complaintLocationPincode} onChange={(e) => setComplaintLocationPincode(e.target.value)} type="text" id='ComplaintInput' name="Pincode"></input>
                  {
                    error&&complaintLocationPincode.length<=0 ? <label id='ComplaintFieldEmptyError'>* Field required!</label>:"" 
                  }
                  <br></br>

                </div>
                <br></br>
                <div className='ComplaintFormPart4'>
                  <h3>{t('Name of Complainant')}</h3>
                  <span id='RequiredMark'>*</span>
                  <label for="CName" id='LabelMargin'>{t('Complainant Name')}</label>
                  <input value={complainantName} onChange={(e) => setComplainantName(e.target.value)} type="text" id='ComplaintInput' name="CName" ></input>
                  {
                    error&&complainantName.length<=0 ? <label id='ComplaintFieldEmptyError'>* Field required!</label>:"" 
                  }
                  <br></br>
                </div>
                <br></br>
                <div className='ComplaintFormPart5'>
                  <h3>{t('Address of Complainant')}</h3>
                  <span id='RequiredMark'>*</span>
                  <label htmlFor='' id='LabelMargin'>{t('Select ward:')}</label>
                  <select value={complainantAddressWard} onChange={(e) => setComplainantAddressWard(e.target.value)} id='ComplaintInput'>

                    <option value="" disabled></option>
                    <option value="Ward1">WARD 1</option>
                    <option value="Ward2">WARD 2</option>
                    <option value="Ward3">WARD 3</option>
                    <option value="Ward4">WARD 4</option>
                    <option value="Ward5">WARD 5</option>
                    <option value="Ward6">WARD 6</option>


                  </select>
                  {
                    error&&complainantAddressWard.length<=0 ? <label id='ComplaintFieldEmptyError'>* Field required!</label>:"" 
                  }
                  <br></br>
                  <span id='RequiredMark'>*</span>
                  <label for="HouseNum" id='LabelMargin'>{t('House No.:')}</label>
                  
                  <input value={complainantAddressHouseNo} onChange={(e) => setComplainantAddressHouseNo(e.target.value)} type="text" id='ComplaintInput' name="HouseNum"></input>
                  {
                    error&&complainantAddressHouseNo.length<=0 ? <label id='ComplaintFieldEmptyError'>* Field required!</label>:"" 
                  }
                 
                  <br></br>
                  <span id='RequiredMark'>*</span>
                  <label for="HouseName" id='LabelMargin'>{t('House Name')}</label>
                  <input value={complainantAddressHouseName} onChange={(e) => setComplainantAddressHouseName(e.target.value)} type="text" id='ComplaintInput' name="HouseName"></input>
                  {
                    error&&complainantAddressHouseName.length<=0 ? <label id='ComplaintFieldEmptyError'>* Field required!</label>:"" 
                  }
                  <br></br>
                  <span id='RequiredMark'>*</span>
                  <label for="AreaInAdd" id='LabelMargin'>{t('Area in Address')}</label>
                  <input value={complainantAddressAreaInAddress} onChange={(e) => setComplainantAddressAreaInAddress(e.target.value)} type="text" id='ComplaintInput' name="AreaInAdd"></input>
                  {
                    error&&complainantAddressAreaInAddress.length<=0 ? <label id='ComplaintFieldEmptyError'>* Field required!</label>:"" 
                  }
                  <br></br>
                  <span id='RequiredMark'>*</span>
                  <label for="ZoneWardNum" id='LabelMargin'>{t('ZoneNumWardNum')}</label>
                  <input value={complainantAddressZoneWardNo} onChange={(e) => setComplainantAddressZoneWardNo(e.target.value)} type="text" id='ComplaintInput' name="ZoneWardNum"></input>
                  {
                    error&&complainantAddressZoneWardNo.length<=0 ? <label id='ComplaintFieldEmptyError'>* Field required!</label>:"" 
                  }
                  <br></br>
                  <span id='RequiredMark'>*</span>
                  <label for="Ar1" id='LabelMargin'>{t('Area 1')}</label>
                  <input value={complainantAddressArea1} onChange={(e) => setComplainantAddressArea1(e.target.value)} type="text" id='ComplaintInput' name="Ar1"></input>
                  {
                    error&&complainantAddressArea1.length<=0 ? <label id='ComplaintFieldEmptyError'>* Field required!</label>:"" 
                  }
                  <br></br>
                  <span id='RequiredMark'>*</span>
                  <label for="Ar2" id='LabelMargin'>{t('Area 2')}</label>
                  <input value={complainantAddressArea2} onChange={(e) => setComplainantAddressArea2(e.target.value)} type="text" id='ComplaintInput' name="Ar2"></input>
                  {
                    error&&complainantAddressArea2.length<=0 ? <label id='ComplaintFieldEmptyError'>* Field required!</label>:"" 
                  }
                  <br></br>
                  <span id='RequiredMark'>*</span>
                  <label for="LandMark" id='LabelMargin'>{t('LandMark')}</label>
                  <input value={complainantAddressLandmark} onChange={(e) => setComplainantAddressLandmark(e.target.value)} type="text" id='ComplaintInput' name="LandMark"></input>
                  {
                    error&&complainantAddressLandmark.length<=0 ? <label id='ComplaintFieldEmptyError'>* Field required!</label>:"" 
                  }
                  <br></br>
                  <span id='RequiredMark'>*</span>
                  <label for="City" id='LabelMargin'>{t('City')}</label>
                  <input value={city} onChange={(e) => setCity(e.target.value)} id='ComplaintInput' name='CityName' readOnly ></input>
                  {
                    error&&city.length<=0 ? <label id='ComplaintFieldEmptyError'>* Field required!</label>:"" 
                  }
                  <br></br>
                  <span id='RequiredMark'>*</span>
                  <label for="State" id='LabelMargin'>{t('State')}</label>
                  <input value={complainantAddressState} onChange={(e) => setComplainantAddressState(e.target.value)} type="text" id='ComplaintInput' name="State" readOnly></input>
                  {
                    error&&complainantAddressState.length<=0 ? <label id='ComplaintFieldEmptyError'>* Field required!</label>:"" 
                  }
                  <br></br>
                  <span id='RequiredMark'>*</span>
                  <label for="Country" id='LabelMargin'>{t('Country')}</label>
                  <input value={complainantAddressCountry} onChange={(e) => setComplainantAddressCountry(e.target.value)} type="text" id='ComplaintInput' name="Country" readOnly></input>
                  {
                    error&&complainantAddressCountry.length<=0 ? <label id='ComplaintFieldEmptyError'>* Field required!</label>:"" 
                  }
                  <br></br>
                  <span id='RequiredMark'>*</span>
                  <label for="STDCodeOffice" id='LabelMargin'>{t('(STD Code)')}</label>
                  <input value={complainantAddressSTDCodeOfficeTelephone} onChange={(e) => setComplainantAddressSTDCodeOfficeTelephone(e.target.value)} type="text" id='ComplaintInput' name="STDCodeOffice"></input>
                  {
                    error&&complainantAddressSTDCodeOfficeTelephone.length<=0 ? <label id='ComplaintFieldEmptyError'>* Field required!</label>:"" 
                  }
                  <br></br>
                  <span id='RequiredMark'>*</span>
                  <label for="TelephoneOffice" id='LabelMargin'>{t('Telephone (Off.)')}</label>
                  <input value={complainantAddressOfficeTelephone} onChange={(e) => setComplainantAddressOfficeTelephone(e.target.value)} type="text" id='ComplaintInput' name="TelephoneOffice"></input>
                  {
                    error&&complainantAddressOfficeTelephone.length<=0 ? <label id='ComplaintFieldEmptyError'>* Field required!</label>:"" 
                  }
                  <br></br>
                  <span id='RequiredMark'>*</span>
                  <label for="STDCodeResidence" id='LabelMargin'>{t('(STD Code)')}</label>
                  <input value={complainantAddressSTDCodeResidenceTelephone} onChange={(e) => setComplainantAddressSTDCodeResidenceTelephone(e.target.value)} type="text" id="STDCodeResidence" name="STDCodeResidence" id='ComplaintInput'></input>
                  {
                    error&&complainantAddressSTDCodeResidenceTelephone.length<=0 ? <label id='ComplaintFieldEmptyError'>* Field required!</label>:"" 
                  }
                  <br></br>
                  <span id='RequiredMark'>*</span>
                  <label for="TelephoneResidence" id='LabelMargin'>{t('Telephone (Res.)')}</label>
                  <input value={complainantAddressResidenceTelephone} onChange={(e) => setComplainantAddressResidenceTelephone(e.target.value)} type="text" id='ComplaintInput' name="TelephoneResidence"></input>
                  {
                    error&&complainantAddressResidenceTelephone.length<=0 ? <label id='ComplaintFieldEmptyError'>* Field required!</label>:"" 
                  }
                  <br></br>
                  <span id='RequiredMark'>*</span>
                  <label for="MobileNumber" id='LabelMargin'>{t('MobileNo')}</label>
                  <input value={phoneNumber} onChange={(e) => setPhoneNumber(e.target.value)} type="text" id='ComplaintInput' name="MobileNumber"></input>
                  {
                    error&&phoneNumber.length<=0 ? <label id='ComplaintFieldEmptyError'>* Field required!</label>:"" 
                  }
                  <br></br>
                  <span id='RequiredMark'>*</span>
                  <label for="EMailAddress" id='LabelMargin'>{t('E-Mail Address')}</label>
                  <input value={email} onChange={(e) => setEmail(e.target.value)} type="text" id='ComplaintInput' name="EMailAddress"></input>
                  {
                    error&&email.length<=0 ? <label id='ComplaintFieldEmptyError'>* Field required!</label>:"" 
                  }
                  <br></br>
                </div>
                <br></br>
                <div className='ComplaintFormPart6'>

                  <h3>{t('Upload Documents')}</h3>
                  <span id='RequiredMark'>*</span>
                  <label for="Photo">{t('Upload Photo')}</label>
                  <br></br>
                  <input type="file" onChange={handleChange} name="img" id='ComplaintInput' />
                  <br></br>
                  {image && <PreviewImage file={image} />}
                  <button id='ComplaintSubmitButton' onClick={handleSubmit}>Submit</button>


                </div>
              </div>
            {/* )
          } */}
        </form>

      </div>


    </>
  )
}
export default CreateComplaint;


