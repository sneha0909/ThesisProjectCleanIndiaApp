import React, { useState } from "react";
import { Form, Button, Card, Message, Input, Select, Image, Modal } from "semantic-ui-react";
import axios from "axios";
import DatePicker from "react-datepicker";
import moment from "moment";
import { ProgressBar, Step } from "react-step-progress-bar";
import "react-step-progress-bar/styles.css";
import "react-datepicker/dist/react-datepicker.css";
import FeedbackForm from "./FeedbackForm";


const ComplaintTracker = () => {
  const [trackOption, setTrackOption] = useState("id");
  const [complaintId, setComplaintId] = useState("");
  const [dateOfSubmission, setDateOfSubmission] = useState(null);
  const [complaintType, setComplaintType] = useState("");
  const [complaintSubtype, setComplaintSubtype] = useState("");
  const [complainantName, setComplainantName] = useState("");
  const [complaintDetails, setComplaintDetails] = useState(null);
  const [error, setError] = useState(null);
  const [buttonClicked, setButtonClicked] = useState(false);
  const [showStatusChange, setShowStatusChange] = useState(false);
  const [showFeedbackModal, setShowFeedbackModal] = useState(false);
  const [feedbackSubmitted, setFeedbackSubmitted] = useState(false);
  const [feedbackComplaintId, setFeedbackComplaintId] = useState("");

  const handleTrackOptionChange = (e, { value }) => {
    setTrackOption(value);
    setComplaintId("");
    setDateOfSubmission(null);
    setComplaintType("");
    setComplaintSubtype("");
    setComplainantName("");
    setComplaintDetails(null);
    setError(null);
  };

  const validateComplaintId = () => {
    const regex =
      /^[a-fA-F0-9]{8}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{12}$/;

    if (!complaintId.match(regex)) {
      setError("Invalid complaint ID format. Please enter a valid ID.");
      return false;
    }

    setError(null);
    return true;
  };

  const handleTrackStatus = async () => {
    if (trackOption === "id") {
      if (!validateComplaintId()) return;

      try {
        const response = await axios.get(
          `https://localhost:5001/api/Complaints/${complaintId}`
        );
        const fetchedComplaintDetails = response.data;
        setComplaintDetails(fetchedComplaintDetails);
        setError(null);
      } catch (error) {
        setError("Failed to fetch complaint details. Please try again.");
        setComplaintDetails(null);
      }
    } else {
      const formattedDate = dateOfSubmission
        ? dateOfSubmission.toISOString().split("T")[0]
        : "";

      try {
        const response = await axios.get(
          `https://localhost:5001/api/Complaints/${formattedDate}/${complaintType}/${complaintSubtype}/${complainantName}`
        );
        const fetchedComplaintDetails = response.data;
        setComplaintDetails(fetchedComplaintDetails);
        setError(null);
      } catch (error) {
        setError("Failed to fetch complaint details. Please try again.");
        setComplaintDetails(null);
      }
    }

    setButtonClicked(true);
    setShowStatusChange(true);
  };

  const complaintTypeOptions = [
    { text: "Waste Management", value: "WasteManagement" },
    { text: "Sanitation", value: "Sanitation" },
    { text: "Pest Control", value: "PestControl" },
    { text: "Water Supply", value: "WaterSupply" },
    { text: "Air Quality", value: "AirQuality" },
    { text: "Other", value: "Other" },
  ];

  const complaintSubtypeOptions = [
    { text: "Dustbin Overflow", value: "DustbinOverflow" },
    { text: "Garbage Collection", value: "GarbageCollection" },
    { text: "Sewer Blockage", value: "SewerBlockage" },
    { text: "Drainage Issue", value: "DrainageIssue" },
    { text: "Public Toilet Maintenance", value: "PublicToiletMaintenance" },
    { text: "Pest Infestation", value: "PestInfestation" },
    { text: "Water Contamination", value: "WaterContamination" },
    { text: "Water Shortage", value: "WaterShortage" },
    { text: "Indoor Air Pollution", value: "IndoorAirPollution" },
    { text: "Outdoor Air Pollution", value: "OutdoorAirPollution" },
    { text: "Other", value: "Other" },
  ];

  const complaintStatusText = {
    0: "Filed",
    1: "In Review",
    2: "Resolved",
    3: "Feedback",
  };

  const handleFeedbackSubmit = () => {
    setFeedbackComplaintId(complaintId); // Pass the complaint ID to the state variable
    setShowFeedbackModal(true);
  };
  

  return (
    <div>
      <h1>Complaint Tracker</h1>
      <Form style={{ marginLeft: "20px"}}>
        <Form.Group inline>
          <label>Track By:</label>
          <Form.Radio
            label="Complaint ID"
            value="id"
            checked={trackOption === "id"}
            onChange={handleTrackOptionChange}
          />
          <Form.Radio
            label="Complaint Details"
            value="details"
            checked={trackOption === "details"}
            onChange={handleTrackOptionChange}
          />
        </Form.Group>

        {trackOption === "id" && (
          <Form.Field>
            <label>Complaint ID</label>
            <Input
              placeholder="Enter Complaint ID"
              value={complaintId}
              onChange={(e) => setComplaintId(e.target.value)}
              error={error ? true : false}
            />
          </Form.Field>
        )}

        {trackOption === "details" && (
          <>
            <Form.Field>
              <label>Date of Complaint Submission</label>
              <DatePicker
                selected={dateOfSubmission}
                onChange={(date) => setDateOfSubmission(date)}
                placeholderText="Select Date of Submission"
                showTimeSelect={false}
                dateFormat="yyyy-MM-dd"
              />
            </Form.Field>
            <Form.Field>
              <label>Complaint Type</label>
              <Select
                placeholder="Select Complaint Type"
                options={complaintTypeOptions}
                value={complaintType}
                onChange={(e, { value }) => setComplaintType(value)}
              />
            </Form.Field>
            <Form.Field>
              <label>Complaint Subtype</label>
              <Select
                placeholder="Select Complaint Subtype"
                options={complaintSubtypeOptions}
                value={complaintSubtype}
                onChange={(e, { value }) => setComplaintSubtype(value)}
              />
            </Form.Field>

            <Form.Field>
              <label>Complainant Name</label>
              <Input
                placeholder="Enter Complainant Name"
                value={complainantName}
                onChange={(e) => setComplainantName(e.target.value)}
              />
            </Form.Field>
          </>
        )}

        <Button primary onClick={handleTrackStatus}>
          Track Status
        </Button>
      </Form>
      

      {complaintDetails && (
        <Card fluid style={{ height: '650px' }}>
          <Card.Content>
            <Card.Header>Complaint Details</Card.Header>
            <Card.Description>
              <p>ID: {complaintDetails.id}</p>
              <p>Date of Submission: {moment(complaintDetails.createdAt).format("MMMM D, YYYY [at] h:mm A")}</p>
              <p>Complaint Type: {complaintDetails.complaintType.replace(/([a-z])([A-Z])/g, '$1 $2')}</p>
              <p>Complaint Subtype: {complaintDetails.complaintSubType.replace(/([a-z])([A-Z])/g, '$1 $2')}</p>
              <p>Complaint Description: {complaintDetails.description}</p>
              <p>Complaint Location Area: {complaintDetails.complaintLocationArea}</p>
              <p>
                Complaint Location Ward No: {complaintDetails.complaintLocationWardNo}
              </p>
              <p>
                Complaint Location Pincode: {complaintDetails.complaintLocationPincode}
              </p>
              <p>Complainant Name: {complaintDetails.complainantName}</p>
              <p>Complainant House No: {complaintDetails.complainantHouseNo}</p>
              <p>Complainant Ward No: {complaintDetails.complainantWardNo}</p>
              <p>Complainant Area: {complaintDetails.complainantArea}</p>
              <p>Complainant Landmark: {complaintDetails.complainantLandmark}</p>
              <p>Phone Number: {complaintDetails.phoneNumber}</p>
              <p>Email: {complaintDetails.email}</p>
              <p>Photo:<Image src={complaintDetails.photoUrl} size="medium" wrapped /></p>
              <p>Complaint Status: {complaintStatusText[complaintDetails.complaintStatus]}</p>
            </Card.Description>
          </Card.Content>
          <Modal open={showFeedbackModal} onClose={() => setShowFeedbackModal(false)}>
        <Modal.Header>Submit Feedback</Modal.Header>
        <Modal.Content>
        <FeedbackForm
      feedbackComplaintId={feedbackComplaintId}
      onSubmit={() => {
        setFeedbackSubmitted(true);
        setShowFeedbackModal(false);
      }}
    />
        </Modal.Content>
      </Modal>
          {complaintDetails.complaintStatus === 3 && (
            <Card.Content extra>
              {!feedbackSubmitted && (
                <Button primary onClick={handleFeedbackSubmit}>
                  Submit Feedback
                </Button>
              )}
              {feedbackSubmitted && (
                <Message positive>
                  <Message.Header>Feedback Submitted</Message.Header>
                  <p>Thank you for submitting your feedback!</p>
                </Message>
              )}
            </Card.Content>
          )}
        </Card>
      )}

      {error && (
        <Message negative>
          <Message.Header>Error</Message.Header>
          <p>{error}</p>
        </Message>
      )}

      {buttonClicked && !complaintDetails && !error && (
        <Message info>
          <Message.Header>No details found</Message.Header>
          <p>No complaint details found for the provided ID or details.</p>
        </Message>
      )}

      
    </div>
  );
};

export default ComplaintTracker;
