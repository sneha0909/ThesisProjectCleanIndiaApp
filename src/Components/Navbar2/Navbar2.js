import React, { useState } from 'react';
import {Link} from 'react-router-dom';
import '../Navbar2/Navbar2.css';
import myLogo from '../../images/logo.png';
import { useTranslation } from "react-i18next";
import useDarkMode from '../../Hooks/useDarkMode';



function Navbar2() {
  const {t} = useTranslation(["navbar2"]);
    const [click, setClick] = useState(false);
    const [button, setButton] = useState(true)

    const handleClick = () => setClick(!click);
    const closeMobileMenu = () => setClick(false)

    const [darkMode, toggleDarkMode] = useDarkMode();
    
    const [fontSize, setFontSize] = useState();

    const showButton = () => {
        if(window.innerWidth <= 960) {
           setButton(false) 
        } else {
            setButton(true);
        }
    };

    // style={{fontSize: `${fontSize}px`}}
    window.addEventListener('resize', showButton);

    return (
        <>
            <nav className="navbar">
                <div className="navbar-container">
                  <Link to="/" className="navbar-logo">
                    <img src={myLogo} />               
                  </Link> 
                  <div className='menu-icon' onClick={handleClick}>
                    <i className={click ? 'fas fa-times' : 'fas fa-bars'} />
                  </div>
                  <ul className={click ? 'nav-menu active' : 'nav-menu'}>
                    <li className='nav-item'>
                      <Link to='/createComplaint'  className='nav-links' onClick={closeMobileMenu}>
                        REGISER COMPLAINT
                      </Link>
                    </li>
                    <li className='nav-item'>
                      <Link to='/login'  className='nav-links' onClick={closeMobileMenu}>
                        POST CLEANING EVENTS
                      </Link>
                    </li>
                    <li className='nav-item'>
                      <Link to='/login'  className='nav-links' onClick={closeMobileMenu}>
                      {t("Swachhbharatactivities")}
                      </Link>
                    </li>
                    <li className='nav-item'>
                      <Link to='/login'  className='nav-links' onClick={closeMobileMenu}>
                      {t("Swachhatapakhwada2022")}
                      </Link>
                    </li>
                    <li className='nav-item'>
                      <Link to='/login'  className='nav-links' onClick={closeMobileMenu}>
                      {t("Swachhatapakhwada2021")}
                      </Link>
                    </li>
                    <li className='nav-item'>
                      <Link to='/login'  className='nav-links' onClick={closeMobileMenu}>
                      {t("Swachhbharatparticipants")}
                      </Link>
                    </li>
                  </ul>
                  {/* {button && <Button buttonStyle='btn--outline'>Register</Button>} */}
                </div>
            </nav>

        </>
    )
}

export default Navbar2