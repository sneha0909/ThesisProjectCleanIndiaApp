import React, { useState } from 'react';
import { Button, Form, Grid, Header, Segment, Message } from 'semantic-ui-react';
import { Link } from 'react-router-dom';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import RegisterNavbar from '../../../../Components/Pages/Register Page/RegisterNavbar';
import RegisterFooter from '../../../../Components/Pages/Register Page/RegisterFooter';


const Register = () => {
  const navigate = useNavigate();
  const [username, setUsername] = useState('');
  const [displayName, setDisplayName] = useState('');
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');

  const handleSubmit = async () => {
    try {
      const response = await axios.post(`https://localhost:5001/api/Account/register`, {
        username,
        displayName,
        email,
        password,
      });
      if (response.status === 200) {
        navigate('/login');
      }
    } catch (error) {
      console.log(error);
    }
  };

  return (
    <>
    <RegisterNavbar />
    <Grid centered columns={2}>
      <Grid.Column>
        <Header as="h2" textAlign="center">
          Register
        </Header>
        <Segment>
          <Form size="large">
            <Form.Input
              style={{ width: '300px' }}
              fluid
              icon="user"
              iconPosition="left"
              placeholder="Username"
              value={username}
              onChange={(e) => setUsername(e.target.value)}
            />
            <Form.Input
              style={{ width: '300px' }}
              fluid
              icon="user circle"
              iconPosition="left"
              placeholder="Display Name"
              value={displayName}
              onChange={(e) => setDisplayName(e.target.value)}
            />
            <Form.Input
              style={{ width: '300px' }}
              fluid
              icon="mail"
              iconPosition="left"
              placeholder="Email"
              type="email"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
            />
            <Form.Input
              style={{ width: '300px' }}
              fluid
              icon="lock"
              iconPosition="left"
              placeholder="Password"
              type="password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
            />

            <Button color="teal" fluid size="large" onClick={handleSubmit}>
              Register
            </Button>
          </Form>
        </Segment>
        <Message>
          Already have an account? <Link to="/login">Login</Link>
        </Message>
      </Grid.Column>
    </Grid>
    <RegisterFooter />
    </>
  );
};

export default Register;
