import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import pledgeicon from '../../images/pledge-icon.png';
import '../MiddlePart1/Pledge1.css';
import { useTranslation } from "react-i18next";



function Pledge1() {
    const {t} = useTranslation(["middlepart2"]);
    return (
        <>
            <nav className="pledge1">
                <div className="pledge1-container">
                    <div className='pledge-icon'>
                        {/* <img src={pledgeicon} className="photo" alt="Hours Mission"/> */}
                        {t("100Hoursmission")}

                    </div>

                    <div className='pledge-description'>
                        <h3>{t("Swachhbharatabhiyan")}</h3>
                        {t("Primeministershrinarendramodilaunchedtheambitious'SwachhBharatAbhiyan'(CleanIndiaMission)2ndOctober2014The'Abhiyan'waslaunchedontheocassionofmahatamagandhi's145thbirthanniversary")}

                        <div className='pledge-button'>
                            <button>{t("Joinsbmission")}</button>

                        </div>

                    </div>

                    
                    
                </div>
            </nav>

        </>
    )
}

export default Pledge1