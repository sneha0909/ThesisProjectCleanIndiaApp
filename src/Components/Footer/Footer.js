import React from 'react'
import '../Footer/Footer.css';
import { Link } from "react-router-dom"
import logoTransformIndia from '../../images/transform.png';
import logoBlog from '../../images/blog-logo.png';
import logoInnovation from '../../images/innovation-logo.png';
import logoSwacchBharat from '../../images/swachh-bharat.png';
import logoGreeting from '../../images/e-greating.png';
import logoITowe from '../../images/itowe-logo.png';
import logoQuiz from '../../images/mygov_quiz.png';

function Footer() {
    return (
        <div className='footer-container'>
            <div className='footer-links'>
                <div className='footer-link-wrapper'>
                    <div className='footer-link-items'>

                        <Link to='/register'>Home</Link>
                        <Link to='/register'>Feedback</Link>
                        <Link to='/register'>Associate with MyGov</Link>
                        <Link to='/register'>SHS 2019</Link>
                    </div>

                    <div className='footer-link-items'>

                        <Link to='/register'>About Us</Link>
                        <Link to='/register'>Sitemap</Link>
                        <Link to='/register'>Link to Us</Link>
                        <Link to='/register'>
                            Swachhata Pakhwada
                            2020 Activities
                        </Link>

                    </div>

                </div>
                <div className='footer-link-wrapper'>
                    <div className='footer-link-items'>

                        <Link to='/register'>Terms & Conditions</Link>
                        <Link to='/register'>FAQ</Link>
                        <Link to='/register'>Contact Us</Link>
                        <Link to='/register'>SHS 2019</Link>
                    </div>


                </div>
            </div>

            <div class="container">
                <div className='card'><img src={logoTransformIndia} /></div>
                <div className='card'><img src={logoInnovation} /></div>
                <div className='card'><img src={logoSwacchBharat} /> </div>
                <div className='card'><img src={logoQuiz} /></div>
                <div className='card'><img src={logoBlog} /></div>
                <div className='card'><img src={logoITowe} /></div>
                <div className='card'><img src={logoGreeting} /></div>
            </div>
        </div>
    );
}

export default Footer