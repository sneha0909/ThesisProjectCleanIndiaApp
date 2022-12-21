import React from 'react';
import {Link} from 'react-router-dom';
import '../Register/RegisterNavbar.css';
import myLogo from '../../images/logo.png';


function RegisterNavbar() {

    return (
        <>
            <nav className="navbar">
                <div className="navbar-container">
                  <Link to="/" className="navbar-logo">
                    <img src={myLogo} />               
                  </Link> 
                </div>
            </nav>
        </>
    )
}

export default RegisterNavbar