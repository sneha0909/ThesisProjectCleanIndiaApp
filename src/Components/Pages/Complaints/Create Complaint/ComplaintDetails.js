import React, { useState, useEffect } from "react";
import { Modal, Image, Header, Button, Icon } from "semantic-ui-react";
import moment from "moment";
import axios from "axios";

const ComplaintDetails = ({ complaint, onClose }) => {
  const [stateName, setStateName] = useState("");
  const [cityName, setCityName] = useState("");

  useEffect(() => {
    const fetchStateName = async () => {
      try {
        const response = await axios.get(
          `https://localhost:5001/api/States/${complaint.stateId}`
        );
        const state = response.data;
        setStateName(state.stateName);
        console.log(response.data);
      } catch (error) {
        console.log(error);
      }
    };

    const fetchCityName = async () => {
      try {
        const response = await axios.get(
          `https://localhost:5001/api/Cities/${complaint.cityId}`
        );
        const city = response.data;
        setCityName(city.cityName);
        console.log(response.data);
      } catch (error) {
        console.log(error);
      }
    };

    fetchStateName();
    fetchCityName();
  }, [complaint]);
  
  const complaintStatusText = {
    0: "Filed",
    1: "In Review",
    2: "Resolved",
  };

const formattedComplaintType = complaint.complaintType.replace(/([a-z])([A-Z])/g, '$1 $2');
const formattedComplaintSubType = complaint.complaintSubType.replace(/([a-z])([A-Z])/g, '$1 $2');


  const statusText = complaintStatusText[complaint.complaintStatus];
  const statusWithDateTime = `${statusText} (Last Updated: ${moment(complaint.createdAt).format("MMMM D, YYYY [at] h:mm A")})`;

  return (
    <Modal open onClose={onClose}>
      <Modal.Header style={{ textAlign: "center" }}>Complaint Details</Modal.Header>
      <Modal.Description style={{ marginLeft: "20px" }}>
        <p><Icon name="hashtag" />ID: {complaint.id}</p>
        <p><Icon name="calendar" /> Date and Time of Submission: {moment(complaint.createdAt).format("MMMM D, YYYY [at] h:mm A")}</p>
        <p><Icon name="info circle" color="blue" /> Type: {formattedComplaintType}</p>
        <p><Icon name="tags" color="green" /> Subtype: {formattedComplaintSubType}</p>
        <p><Icon name="file alternate outline" color="grey" /> Description: {complaint.description}</p>
        <p><Icon name="map marker alternate" color="teal" /> Complaint Location Area: {complaint.complaintLocationArea}</p>
        <p><Icon name="map marker alternate" color="teal" />Complaint Location Ward No: {complaint.complaintLocationWardNo}</p>
        <p><Icon name="map marker alternate" color="teal" />Complaint Location Pincode: {complaint.complaintLocationPincode}</p>
        <p><Icon name="user" />Complainant Name: {complaint.complainantName}</p>
        <p><Icon name="home" />Complainant House No: {complaint.complainantHouseNo}</p>
        <p><Icon name="map marker alternate" color="teal" />Complainant Ward No: {complaint.complainantWardNo}</p>
        <p><Icon name="map marker alternate" color="teal" />Complainant Area: {complaint.complainantArea}</p>
        <p><Icon name="map pin" />Complainant Landmark: {complaint.complainantLandmark}</p>
        <p><Icon name="phone" />Phone Number: {complaint.phoneNumber}</p>
        <p><Icon name="envelope" />Email: {complaint.email}</p>
        <p><Icon name="map pin" color="orange" />State: {stateName}</p>
        <p><Icon name="building" color="purple" />City: {cityName}</p>
        <p><Icon name="camera" color="red" /> Photo:{" "}
          <Image src={complaint.photoUrl} size="medium" wrapped />
        </p>
        <p><Icon name="clock" color="violet" />Complaint Status: {statusWithDateTime}</p>
      </Modal.Description>

      <Modal.Actions>
        <Button onClick={onClose}>Close</Button>
      </Modal.Actions>
    </Modal>
  );
};

export default ComplaintDetails;
