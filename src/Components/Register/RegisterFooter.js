import React from 'react'
import '../Register/RegisterFooter.css'
import { Link } from "react-router-dom"
import myLogo from '../../images/nic_logo.png';

function RegisterFooter() {
    return (
        <div className='footer-container'>

            <div className='footer-link-wrapper'>
                <Link to="/" className="footer-logo">
                    <img src={myLogo} />
                </Link>

            </div>
            <div className='footer-text'>
            © MyGov Auth platform is designed, developed and hosted by National Informatics Centre and this 
            website belongs to MyGov, Ministry of Electronics & Information Technology, Government of India.
            </div>

            <div className='footer-bottomtext'>
              auth-90 - Last Updated: 25/11/22
            </div>


        </div>
    );
}

export default RegisterFooter;