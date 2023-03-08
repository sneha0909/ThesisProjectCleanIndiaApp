import React, { useEffect, useRef, useState } from 'react'
import GpsFixedIcon from '@mui/icons-material/GpsFixed';
import SearchIcon from '@mui/icons-material/Search';
import { Form, Segment } from 'semantic-ui-react';
import axios from 'axios';
import PreviewImage from './PreviewImage';

// const apiKey = import.meta.env.CLEAN_INDIA_GMAP_API_KEY;
const apiKey = "AIzaSyA6iTv5EZiD487CQwyq07hiZU64LGBLu7U";
const mapApiJs = 'https://maps.googleapis.com/maps/api/js';
const geocodeJson = 'https://maps.googleapis.com/maps/api/geocode/json';



//load google map api js
function loadAsyncScript(src) {
  return new Promise(resolve => {
    const script = document.createElement("script");
    Object.assign(script, {
      type: "text/javascript",
      async: true,
      src
    })
    script.addEventListener("load", () => resolve(script));
    document.head.appendChild(script);
  })
}

const extractAddress = (place) => {

  const address = {
    city: "",
    state: "",
    zip: "",
    country: "",
    plain() {
      const city = this.city ? this.city + ", " : "";
      const zip = this.zip ? this.zip + ", " : "";
      const state = this.state ? this.state + ", " : "";
      return city + zip + state + this.country;
    }
  }

  if (!Array.isArray(place?.address_components)) {
    return address;
  }

  place.address_components.forEach(component => {
    const types = component.types;
    const value = component.long_name;

    if (types.includes("locality")) {
      address.city = value;
    }

    if (types.includes("administrative_area_level_2")) {
      address.state = value;
    }

    if (types.includes("postal_code")) {
      address.zip = value;
    }

    if (types.includes("country")) {
      address.country = value;
    }

  });

  return address;
}





function ComplaintForm() {

  const searchInput = useRef(null);
  const [address, setAddress] = useState({});
  const [selectLanguage, setLanguage] = useState("English");
  const [selectCity, setCity] = useState("AALOT NAGAR PARISHAD");
  const [selectComplaintType, setCompliantType] = useState("SEWAGE");
  const [selectComplaintSubtype, setComplaintSubtype] = useState("AALOT NAGAR PARISHAD");
  const [selectWard, setWard] = useState("");
  const [image, setImage] = useState('');


  const handleChange = (event) => {
    console.log(event.target.files)
    setImage(event.target.files[0])
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

  //init gmap script 
  const initMapScript = () => {
    // if script already loaded
    if (window.google) {
      return Promise.resolve();
    }
    const src = `${mapApiJs}?key=${apiKey}&libraries=places&v=weekly`;
    return loadAsyncScript(src);
  }

  //do something on address change

  const onchangeAddress = (autocomplete) => {
    const place = autocomplete.getPlace();
    //console.log(extractAddress(place));

    setAddress(extractAddress(place));
  }

  // init autocomplete 
  const initAutocomplete = () => {
    if (!searchInput.current) return;

    const autocomplete = new window.google.maps.places.Autocomplete(searchInput.current);
    autocomplete.setFields(["address_component", "geometry"]);
    autocomplete.addListener("place_changed", () => onchangeAddress(autocomplete));


  }

  const reverseGeocode = ({ latitude: lat, longitude: lng }) => {
    //console.log(lat, lng);
    const url = `${geocodeJson}?key=${apiKey}&latlng=${lat},${lng}`;
    searchInput.current.value = "Getting your location...";
    fetch(url)
      .then(response => response.json())
      .then(location => {
        const place = location.results[0];
        //console.log(extractAddress(place));
        const _address = extractAddress(place);
        setAddress(_address);
        searchInput.current.value = _address.plain();
      })

  }

  const findMyLocation = () => {
    //alert("find my location");

    if (navigator.geolocation) {
      navigator.geolocation.getCurrentPosition(position => {
        reverseGeocode(position.coords)

      })
    }
  }

  //load map script after outed
  useEffect(() => {
    initMapScript().then(() => initAutocomplete())
  }, []);

  return (
    <>
      {/* <div className='ComplaintForm'>
        <div className='search'>
          <span><SearchIcon /></span>
          <input ref={searchInput} type="text" placeholder='Search location...' />
          <button onClick={findMyLocation}><GpsFixedIcon /></button>

        </div>

        <div className='address'>
          <p>City: <span>{address.city}</span></p>
          <p>State: <span>{address.state}</span></p>
          <p>Zip: <span>{address.zip}</span></p>
          <p>Country: <span>{address.country}</span></p>
          
        </div>


      </div> */}
      <form>
        <div className='ComplaintFormLayout'>

          <h1>Application for Complaint / Grievance</h1>
          <div className='ComplaintFormPart1'>
            <h3>Please Select Language and City Below / अपनी भाषा और शहर चुनें</h3>
            <br></br>
            <label htmlFor=''>Please Select Language / अपनी भाषा चुनें</label>
            <select value={selectLanguage} onChange={(e) => setLanguage(e.target.value)}>

              <option value="English">English / अंग्रेज़ी</option>
              <option value="Hindi">Hindi / हिंदी</option>

            </select>
            <br></br>
            <label htmlFor=''>Please Select City / अपना शहर चुनें</label>
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

          </div>
          <br></br>
          <div className='ComplaintFormPart2'>
            <h3>Define Nature Of Your Complaint</h3>
            <br></br>
            <label htmlFor=''>Select Your Complaint Type:</label>
            <select value={selectComplaintType} onChange={(e) => setCompliantType(e.target.value)}>

              <option value="SEWAGE">SEWAGE</option>
              <option value="COMPOST WITH DRIED LEAVES">COMPOST WITH DRIED LEAVES</option>
              <option value="GARBAGE COLLECTION">GARBAGE COLLECTION</option>


            </select>
            <br></br>
            <label htmlFor=''>Select complaint subtype: </label>
            <select value={selectComplaintSubtype} onChange={(e) => setComplaintSubtype(e.target.value)}>

              <option value="REPAIRING">REPAIRING</option>
              <option value="ALL COMPLAINTS RELATED TO SEWAGEGUTTER">ALL COMPLAINTS RELATED TO SEWAGE / GUTTER</option>
              <option value="COMPOST WITH DRIED LEAVES">COMPOST WITH DRIED LEAVES</option>
              <option value="OVERFLOW OF BINS">OVERFLOW OF BINS</option>
              <option value="DELAY IN GARBAGE COLLECTION">DELAY IN GARBAGE COLLECTION</option>


            </select>
            <br></br>
            <label htmlFor="">Description In Brief: </label>
            <textarea cols='30' rows='10'></textarea>

          </div>
          <br></br>
          <div className='ComplaintFormPart3'>
            <h3>Specify Location Of Your Complaint</h3>
            <label for="HouseNo">House No.:</label>
            <input type="text" id="HouseNo" name="HouseNo"></input>
            <br></br>
            <label for="HouseName">House Name:</label>
            <input type="text" id="HouseName" name="HouseName"></input>
            <br></br>
            <label for="AreaInAddress">Area in Address:</label>
            <input type="text" id="AreaInAddress" name="AreaInAddress"></input>
            <br></br>
            <label for="ZoneWardNo">Zone No./ Ward No.:</label>
            <input type="text" id="ZoneWardNo" name="ZoneWardNo"></input>
            <br></br>
            <label for="Area1">Area 1:</label>
            <input type="text" id="Area1" name="Area1"></input>
            <br></br>
            <label for="Area2">Area 2:</label>
            <input type="text" id="Area2" name="Area2"></input>
            <br></br>
            <label for="City">City:</label>
            <input type="text" id="City" name="City"></input>
            <br></br>
            <label for="Pincode">Pincode:</label>
            <input type="text" id="Pincode" name="Pincode"></input>
            <br></br>

          </div>
          <br></br>
          <div className='ComplaintFormPart4'>
            <h3>Name of Complainant</h3>
            <label for="fName">First Name:</label>
            <input type="text" id="fName" name="fName"></input>
            <br></br>
            <label for="mName">Middle Name:</label>
            <input type="text" id="mName" name="mName"></input>
            <br></br>
            <label for="lName">Last Name:</label>
            <input type="text" id="lName" name="lName"></input>
            <br></br>
          </div>
          <br></br>
          <div className='ComplaintFormPart5'>
            <h3>Address of Complainant</h3>
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
            <label for="HouseNum">House No.:</label>
            <input type="text" id="HouseNum" name="HouseNum"></input>
            <br></br>
            <label for="HouseName">House Name:</label>
            <input type="text" id="HouseName" name="HouseName"></input>
            <br></br>
            <label for="AreaInAdd">Area in Address:</label>
            <input type="text" id="AreaInAdd" name="AreaInAdd"></input>
            <br></br>
            <label for="ZoneWardNum">Zone No./Ward No.:</label>
            <input type="text" id="ZoneWardNum" name="ZoneWardNum"></input>
            <br></br>
            <label for="Ar1">Area 1:</label>
            <input type="text" id="Ar1" name="Ar1"></input>
            <br></br>
            <label for="Ar2">Area 2:</label>
            <input type="text" id="Ar2" name="Ar2"></input>
            <br></br>
            <label for="LandMark">LandMark:</label>
            <input type="text" id="LandMark" name="LandMark"></input>
            <br></br>
            <label for="CityName">City:</label>
            <input type="text" id="CityName" name="CityName"></input>
            <br></br>
            <label for="State">State:</label>
            <input type="text" id="State" name="State"></input>
            <br></br>
            <label for="Country">Country:</label>
            <input type="text" id="Country" name="Country"></input>
            <br></br>
            <label for="STDCodeOffice">(STD Code)</label>
            <input type="text" id="STDCodeOffice" name="STDCodeOffice"></input>
            <br></br>
            <label for="TelephoneOffice">Telephone (Off.):</label>
            <input type="text" id="TelephoneOffice" name="TelephoneOffice"></input>
            <br></br>
            <label for="STDCodeResidence">(STD Code)</label>
            <input type="text" id="STDCodeResidence" name="STDCodeResidence"></input>
            <br></br>
            <label for="TelephoneResidence">Telephone (Res.):</label>
            <input type="text" id="TelephoneResidence" name="TelephoneResidence"></input>
            <br></br>
            <label for="MobileNumber">Mobile No.</label>
            <input type="text" id="MobileNumber" name="MobileNumber"></input>
            <br></br>
            <label for="EMailAddress">E-Mail Address:</label>
            <input type="text" id="EMailAddress" name="EMailAddress"></input>
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
              <input type="submit" id="Submit" name="Submit" value="Submit"></input>
            

          </div>

        </div>
      </form>

    </>
  )
}
export default ComplaintForm;


