import React, { useState } from "react";
import axios from "axios";
import { Button, Form, Grid, Header, Message, Segment } from "semantic-ui-react";
import { Link, useNavigate } from 'react-router-dom';
import LoginNavbar from '../../../../Components/Pages/Login Page/LoginNavbar';
import RegisterFooter from "../../../../Components/Pages/Register Page/RegisterFooter";

const Login = () => {
  const navigate = useNavigate();
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [errorMessage, setErrorMessage] = useState("");

  const handleSubmit = (e) => {
    e.preventDefault();
    axios
      .post(`https://localhost:5001/api/Account/login`, { email, password })
      .then((response) => {
        console.log(response.data);
        localStorage.setItem("token", response.data.token);
        localStorage.setItem("username", response.data.username);
        navigate('/profile');
        // do something with the response, like redirect to another page
      })
      .catch((error) => {
        console.log(error.response.data);
        setErrorMessage("Invalid Email and Password");
      });
  };

  return (
    <>
      <LoginNavbar />
      <Grid
        textAlign="center"
        verticalAlign="middle"
        style={{ height: "75vh" }}
      >
        <Grid.Column style={{ maxWidth: 550 }}>
          <Header as="h2" color="teal" textAlign="center">
            Login to your account
          </Header>
          <Form size="large" onSubmit={handleSubmit}>
            <Segment stacked>
              <Form.Input
                fluid
                icon="mail"
                iconPosition="left"
                placeholder="E-mail address"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
              />
              <Form.Input
                fluid
                icon="lock"
                iconPosition="left"
                placeholder="Password"
                type="password"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
              />

              <Button color="teal" fluid size="large" type="submit">
                Login
              </Button>
            </Segment>
          </Form>
          {errorMessage && (
            <Message negative>
              <Message.Header>{errorMessage}</Message.Header>
            </Message>
          )}
          <Message>
            Don't have an account? <Link to="/register">Register</Link>
          </Message>
        </Grid.Column>
      </Grid>
      <RegisterFooter />
    </>
  );
};

export default Login;
