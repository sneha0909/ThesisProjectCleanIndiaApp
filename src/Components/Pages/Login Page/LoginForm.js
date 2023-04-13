import React, { useState } from 'react';
import '../Register Page/RegisterForm.css';
import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';
import AuthServices from '../../../Services/AuthServices';
import { useNavigate } from 'react-router-dom'

import Snackbar from '@mui/material/Snackbar';
import IconButton from '@mui/material/IconButton';
import CloseIcon from '@mui/icons-material/Close';

function LoginForm() {

    const authService = new AuthServices();
    const navigate = useNavigate();
    const initialValues = {
        email: '',
        password: '',
        Message: ''

    };

    const booleanInitialValues = {

        emailFlag: false,
        passwordFlag: false,
        open: false


    };

    const [values, setValues] = useState(initialValues);

    const [booleanValues, setBooleanValues] = useState(booleanInitialValues);

    const handleValues = (e) => {
        // const { name, value } = e.target
        setValues({
            ...values,
            [e.target.name]: e.target.value,
            // console.log('name', name, 'value', value),

        });
    };

    const CheckValidity = () => {
        console.log('Check Validity Calling...')
        setBooleanValues({
            emailFlag: false,
            passwordFlag: false,

        })


        if (values.email === '') {
            setBooleanValues({ emailFlag: true })
        }
        if (values.password === '') {
            setBooleanValues({ passwordFlag: true })
        }
    }

    const handleSubmit = (e) => {

        CheckValidity()
        if (
            values.email !== '' &&
            values.password !== ''
        ) {
            console.log('Acceptable')

            const data = {
                Email: values.email,
                Password: values.password
            }
            authService.login(data).then((data) => {
                console.log('data : ', data)
                if (data.data.email || data.data.password) //Problem here with && 
                {
                    navigate('/loggedin')
                }

                else {
                    // console.log('Something went wrong')
                    setBooleanValues({open: true, Message: data.data.title})
                }
            }).catch((error) => {
                console.log('Error : ', error)
            })

        } else {
            console.log('Not Acceptable')
            setBooleanValues({open: true, Message: 'Some fields are empty'})
        }
    }

    const handleRegister = (e) => {
        navigate("/register")
    }

    const handleClose = (event, reason) => {
        if (reason === 'clickaway') {
            return;
        }

        setBooleanValues({ open: false });
    };



    return (
        <>
            <div className='Register-Container'>
                <div className='Register-SubContainer'>
                    <div className='Header'> Login</div>
                    <div className='Body'>
                        <form className='form'>
                            <TextField
                                error={setBooleanValues.emailFlag}
                                className='TextField'
                                name='email'
                                label="Enter your registered email"
                                variant="outlined"
                                size='small'
                                onChange={handleValues}
                            />
                            <TextField
                                error={setBooleanValues.passwordFlag}
                                className='TextField'
                                name='password'
                                label="Enter your password"
                                variant="outlined"
                                size='small'
                                type='password'
                                onChange={handleValues}
                            />
                        </form>
                    </div>
                    <div className='buttons'>
                        <Button variant="text" onClick={handleRegister}>Register</Button>
                        <Button className='Btn' variant="contained" onClick={handleSubmit}>Login</Button>
                    </div>
                </div>
                <Snackbar
                    open={setBooleanValues.open}
                    autoHideDuration={6000}
                    onClose={handleClose}
                    message={values.Message}
                    action={
                        <React.Fragment>
                            <Button color='secondary' size='small' onClick={handleClose}>
                                UNDO
                            </Button>
                            <IconButton size="small" aria-label='close' color='inherit' onClick={handleClose}>
                                <CloseIcon fontSize='small' />
                            </IconButton>
                        </React.Fragment>
                    }
                />
            </div>
        </>
    )

}

export default LoginForm;