import React, { useState } from 'react';
import { Form, TextArea, Button, Message, Rating } from 'semantic-ui-react';
import axios from 'axios';

const FeedbackForm = ({ feedbackComplaintId, onSubmit }) => {
  const [complaintId, setComplaintId] = useState('');
  const [feedback, setFeedback] = useState('');
  const [successMessage, setSuccessMessage] = useState('');

  const handleSubmit = () => {
    console.log('Feedback:', feedback);

    // Create an object with the feedback message
    const feedbackData = {
      message: feedback,
    };

    axios
      .post(`https://localhost:5001/api/complaints/${complaintId}/feedback`, feedbackData)
      .then((response) => {
        console.log('Response:', response.data);
        setSuccessMessage(response.data.message);
      })
      .catch((error) => {
        console.error('Error:', error);
      });
  };

  return (
    <div>
      <h1>Submit Feedback</h1>
      {successMessage && (
        <Message success header="Feedback Submitted" content={successMessage} />
      )}
      <Form onSubmit={handleSubmit}>
        <Form.Field>
          <label>Complaint ID</label>
          <input
            placeholder="Enter the ID of the complaint"
            value={feedbackComplaintId}
            onChange={(e) => setComplaintId(e.target.value)}
          />
        </Form.Field>
        <Form.Field>
          <label>Rating</label>
          <Rating icon="star" defaultRating={0} maxRating={5} />
        </Form.Field>
        <Form.Field>
          <label>Feedback</label>
          <TextArea
            placeholder="Enter your feedback here"
            value={feedback}
            onChange={(e) => setFeedback(e.target.value)}
          />
        </Form.Field>
        <Button primary type="submit">
          Submit Feedback
        </Button>
      </Form>
    </div>
  );
};

export default FeedbackForm;
