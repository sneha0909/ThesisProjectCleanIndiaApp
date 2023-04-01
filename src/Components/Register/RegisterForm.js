import React, { useState } from 'react'
import '../Register/RegisterForm.css';
import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';
import AuthServices from '../../Services/AuthServices';
import { useNavigate } from 'react-router-dom';
import Snackbar from '@mui/material/Snackbar';
import IconButton from '@mui/material/IconButton';
import CloseIcon from '@mui/icons-material/Close';



function RegisterForm() {

    const authService = new AuthServices();
    const navigate = useNavigate();
    const initialValues = {
        complainantName: '',
        username: '',
        password: '',
        email: '',
        Message: ''
               
    };

    const booleanInitialValues = {
        
        complainantNameFlag: false,
        passwordFlag: false,
        usernameFlag: false,
        emailFlag: false,
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
            complainantNameFlag: false,
            usernameFlag: false,
            passwordFlag: false,
            emailFlag: false         
           
        })


        if (values.complainantName === '') {
            setBooleanValues({ complainantNameFlag: true })
        }
        if (values.username === '') {
            setBooleanValues({ usernameFlag: true })
        }
        if (values.password === '') {
            setBooleanValues({ passwordFlag: true })
        }     
        if (values.email === '') {
            setBooleanValues({ emailFlag: true })
        }
            
    }

    const handleSubmit = (e) => {

        CheckValidity()
        if (
            values.complainantName !== '' &&
            values.username !== '' &&
            values.password !== '' &&
            values.email !== ''
            
        ) {
            console.log('Acceptable')

            const data = {
                ComplainantName: values.complainantName,
                Username: values.username,
                Password: values.password,
                Email: values.email
            }
            authService.register(data).then((data) => {
                console.log('data : ', data)
                if (data.data.complainantName && data.data.username && 
                    data.data.email)
                {
                    navigate('/login')
                } else {
                    console.log('Something went wrong')
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

    const handleLogin = () => {
        navigate("/login")
    }

    const handleClose = (event, reason) => {
        if (reason === 'clickaway') {
          return;
        }
    
        setBooleanValues({open:false});
      };

    console.log('State : ', values)
    return (
        <>
            <div className='Register-Container'>
                <div className='Register-SubContainer'>
                    <div className='Header'> Register</div>
                    <div className='Body'>
                        <form className='form'>
                            <TextField
                                error={setBooleanValues.complainantNameFlag}
                                className='TextField'
                                name='complainantName'
                                label="Enter Complainant's Name"
                                variant="outlined"
                                size='small'
                                value={values.complainantName}
                                onChange={handleValues}
                            />
                            <TextField
                                error={setBooleanValues.usernameFlag}
                                className='TextField'
                                name='username'
                                label="Enter the desired Username"
                                variant="outlined"
                                size='small'
                                value={values.username}
                                onChange={handleValues}
                            />
                            <TextField
                                error={setBooleanValues.passwordFlag}
                                className='TextField'
                                name='password'
                                label="Enter Password"
                                variant="outlined"
                                size='small'
                                type='password'
                                value={values.password}
                                onChange={handleValues}
                            />
                            <TextField
                                error={setBooleanValues.emailFlag}
                                className='TextField'
                                name='email'
                                label="Enter Email"
                                variant="outlined"
                                size='small'
                                type='email'
                                value={values.email}
                                onChange={handleValues}
                            />                           
                        </form>
                    </div>
                    <div className='buttons'>
                        <Button variant="text" onClick={handleLogin}>Login</Button>
                        <Button className='Btn' variant="contained" onClick={handleSubmit}>Register </Button>
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

export default RegisterForm;


