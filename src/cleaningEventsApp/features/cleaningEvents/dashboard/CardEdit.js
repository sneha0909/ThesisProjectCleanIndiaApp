import React, { useState } from "react";
import { Form } from "semantic-ui-react";

const CardEdit = ({ event, onSubmit, onCancel }) => {
  const [title, setTitle] = useState(event.title);
  const [description, setDescription] = useState(event.description);
  const [category, setCategory] = useState(event.category);
  const [date, setDate] = useState(event.date);
  const [city, setCity] = useState(event.city);
  const [venue, setVenue] = useState(event.venue);

  const handleSubmit = (e) => {
    e.preventDefault();
    onSubmit({
      ...event,
      title,
      description,
      category,
      date,
      city,
      venue,
    });
  };

  return (
    <Form onSubmit={handleSubmit}>
      <Form.Input
        label="Title"
        value={title}
        onChange={(e) => setTitle(e.target.value)}
        
      />
      <Form.TextArea
        label="Description"
        value={description}
        onChange={(e) => setDescription(e.target.value)}
      />
      <Form.Input
        label="Category"
        value={category}
        onChange={(e) => setCategory(e.target.value)}
      />
      <Form.Input
        label="Date"
        value={date}
        onChange={(e) => setDate(e.target.value)}
      />
      <Form.Input
        label="City"
        value={city}
        onChange={(e) => setCity(e.target.value)}
      />
      <Form.Input
        label="Venue"
        value={venue}
        onChange={(e) => setVenue(e.target.value)}
      />
      {/* <div className="ui two buttons">
        <button className="ui basic red button" onClick={onCancel}>
          Cancel
        </button>
        <button className="ui basic green button" type="submit">
          Submit
        </button>
      </div> */}
    </Form>
  );
};

export default CardEdit;
