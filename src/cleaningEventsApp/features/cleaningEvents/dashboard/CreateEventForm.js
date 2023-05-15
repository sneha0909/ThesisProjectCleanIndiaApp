import { useState } from 'react';
import { Form, Input, TextArea, Button } from 'semantic-ui-react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import Navbar2 from '../../../../Components/Navbar2/Navbar2';
import RegisterFooter from '../../../../Components/Pages/Register Page/RegisterFooter';

const CreateEventForm = () => {
    const navigate = useNavigate();
  const [event, setEvent] = useState({
    title: '',
    description: '',
    category: '',
    date: '',
    city: '',
    venue: '',
  });

  const handleChange = (event) => {
    const { name, value } = event.target;
    setEvent((prevState) => ({
      ...prevState,
      [name]: value,
    }));
  };

  const token = localStorage.getItem("token");

  const handleSubmit = (e) => {
    e.preventDefault();
    axios
      .post('http://localhost:5000/api/CleaningEvents', event, {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      })
      .then((response) => {
        console.log(response.data);
        navigate('/cards');
      })
      .catch((error) => console.error(error));
  };

  return (
    <>
    <Navbar2 />
    <Form onSubmit={handleSubmit}>
      <Form.Field
        control={Input}
        label="Title"
        placeholder="Title"
        name="title"
        onChange={handleChange}
        required
      />
      <Form.Field
        control={TextArea}
        label="Description"
        placeholder="Description"
        name="description"
        onChange={handleChange}
        required
      />
      <Form.Field
        control={Input}
        label="Category"
        placeholder="Category"
        name="category"
        onChange={handleChange}
        required
      />
      <Form.Field
        control={Input}
        type="date"
        label="Date"
        placeholder="Date"
        name="date"
        onChange={handleChange}
        required
      />
      <Form.Field
        control={Input}
        label="City"
        placeholder="City"
        name="city"
        onChange={handleChange}
        required
      />
      <Form.Field
        control={Input}
        label="Venue"
        placeholder="Venue"
        name="venue"
        onChange={handleChange}
        required
      />
      <Button type="submit">Submit</Button>
    </Form>
    <RegisterFooter />
    </>
  );
};

export default CreateEventForm;
