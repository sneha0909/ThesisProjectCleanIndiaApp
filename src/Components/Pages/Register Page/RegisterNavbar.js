import React from 'react';
import {Link} from 'react-router-dom';
import '../Register Page/RegisterNavbar.css';
import myLogo from '../../../images/logo.png';


function RegisterNavbar() {

    return (
        <>
            <nav className="navbar">
                <div className="navbar-container">
                  <Link to="/" className="navbar-logo">
                    <img src={myLogo} alt="" />               
                  </Link> 
                </div>
            </nav>
        </>
    )
}

export default RegisterNavbar