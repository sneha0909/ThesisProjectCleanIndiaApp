import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import '../Navbar1/Navbar1.css';
import myLogo from '../../images/flag.gif';
import logoFb from '../../images/ico-fb.png';
import logoTw from '../../images/ico-tw.png';
import logoYt from '../../images/ico-yt.png';
import logoIn from '../../images/ico-insta.png';
import { useTranslation } from "react-i18next";
import i18next from 'i18next';
import useDarkMode from '../../Hooks/useDarkMode';


function Navbar1() {

  const url = 'https://www.india.gov.in/'
  const { i18n, t } = useTranslation(["common"]);

  useEffect(() => {
    if (localStorage.getItem("i18nextLng")?.length > 2) {
      i18next.changeLanguage("en");
    }

  }, []);

  const handleLanguageChange = (e) => {

    i18n.changeLanguage(e.target.value);
  }


  const handleRedirect = () => {

    if (window.confirm('You are being redirected to an external website. Please note that MyGov Website cannot be held responsible for external websites content & privacy policies.')) {

      window.open(url, '_blank')
    }

  }

  const [darkMode, toggleDarkMode] = useDarkMode();
  const [fontSize, setFontSize] = useState(16);

  const [click, setClick] = useState(false);
  const [button, setButton] = useState(true)

  const handleClick = () => setClick(!click);
  const closeMobileMenu = () => setClick(false)

  const showButton = () => {
    if (window.innerWidth <= 960) {
      setButton(false)
    } else {
      setButton(true);
    }
  };

  window.addEventListener('resize', showButton);

  return (
    <>
      <nav className="navbar2" >
        <div className="navbar2-container" >
          {/* <Link to={{ pathname: "https://www.india.gov.in/"}} className="navbar2-logo"> */}
          <div className="navbar2-logo" onClick={() => handleRedirect()}>

            <img src={myLogo} />

            {t("Governmentofindia")}

          </div>

          {/* </Link>  */}
          <div className='menu2-icon' onClick={handleClick}>
            <i className={click ? 'fas fa-times' : 'fas fa-bars'} />
          </div>
          <ul className={click ? 'nav2-menu active' : 'nav2-menu'}>
            <li className='nav2-item'>
              <Link to='/' className='nav2-links' onClick={closeMobileMenu}>
                {t("Skiptomaincontent")}
              </Link>
            </li>
            <li className='nav2-item'>
              <Link to='/login' className='nav2-links' onClick={closeMobileMenu}>
                <i class="fa fa-user" aria-hidden="true"></i>
                {t("Login")}
              </Link>
            </li>
            <li className='nav2-item'>
              <Link to='/register' className='nav2-links' onClick={closeMobileMenu}>
                <i class="fa fa-pencil" aria-hidden="true"></i>
                {t("Register")}
              </Link>
            </li>
            <li className='nav2-item'>
              <Link to='/login' className='nav2-links' onClick={closeMobileMenu}>
                <img src={logoFb} />
              </Link>
            </li>
            <li className='nav2-item'>
              <Link to='/login' className='nav2-links' onClick={closeMobileMenu}>
                <img src={logoTw} />
              </Link>
            </li>
            <li className='nav2-item'>
              <Link to='/login' className='nav2-links' onClick={closeMobileMenu}>
                <img src={logoYt} />
              </Link>
            </li>
            <li className='nav2-item'>
              <Link to='/login' className='nav2-links' onClick={closeMobileMenu}>
                <img src={logoIn} />
              </Link>
            </li>
            <li className='nav2-item'>
              {/* <img src={logoGlobe} /> */}
              <select
                value={localStorage.getItem("i18nextLng")}
                onChange={handleLanguageChange}>
                <option value="en">English</option>
                <option value="hi">Hindi</option>
                <option value="bn">Bengali</option>
                <option value="gu">Gujarati</option>
                <option value="kn">Kannada</option>
                <option value="ml">Malayalam</option>
                <option value="mr">Marathi</option>
                <option value="ne">Nepali</option>
                <option value="or">Oriya</option>
                <option value="pa">Punjabi</option>
                <option value="ta">Tamil</option>
                <option value="te">Telugu</option>
              </select>
            </li>
            <li className="nav2-item">
              <button onClick={() => toggleDarkMode()}>A</button>
            </li>
            <li className='nav2-item' >
              <button onClick={() => setFontSize(fontSize + 5)}>+</button>
              <button onClick={() => setFontSize(fontSize - 5)}>-</button>
            </li>
          </ul>
          {/* {button && <Button buttonStyle='btn--outline'>Register</Button>} */}
        </div>
      </nav>

    </>
  )
}

export default Navbar1