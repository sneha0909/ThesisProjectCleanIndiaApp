import React, { useState, useEffect, useCallback } from 'react';
import { Link } from 'react-router-dom';
import pledgeicon from '../../images/pledge-icon.png';
import '../MiddlePart1/Pledge1.css';
import { useTranslation } from "react-i18next";

const pledges = [
    "Prime Minister Shri Narendra Modi Launched the ambitious 'Swachh Bharat Abhiyan' (Clean India Mission) 2nd\nOctober 2014The 'Abhiyan' was launched on the ocassion of Mahatama Gandhi's 145th birth anniversary", 'I pledge to segregate my (household, shop, establishment) waste in two dustbins, wet waste in Green and dry\nwaste in Blue, as my contribution to the Swachh Bharat Mission', 'Millions of students and youth taking pledge for a clean India. It is our country.'
]

const pledgeHeading = ["SWACHH BHARAT ABHIYAN", "PLEDGE TO SEGREGATE", "LETS KEEP IT CLEAN."]

const pledgeButtonText = ["JOIN SB MISSION", "TAKE\nA PLEDGE TO SEGREGATE", "TAKE\nA MASS PLEDGE"]
function Pledge1() {
    const [index, setIndex] = useState(0);

    const [newPledgeHeading, setnewPledgeHeading] = useState(0);

    const [newPledgeButtonText, setnewPledgeButtonText] = useState(0);

    useEffect(() => {
        const timer = () => {
            setIndex(prevIndex => {
                if (prevIndex === pledges.length - 1) {
                    return 0;
                }
                return prevIndex + 1;
            })
            setnewPledgeHeading(prevIndex => {
                if (prevIndex === pledgeHeading.length - 1) {
                    return 0;
                }
                return prevIndex + 1;
            })
            setnewPledgeButtonText(prevIndex => {
                if (prevIndex === pledgeButtonText.length - 1) {
                    return 0;
                }
                return prevIndex + 1;
            })
        };
        setInterval(timer, 5000);

        //cleanup function in order clear the interval timer
        //when the component unmounts
        return () => { clearInterval(timer); }
    }, []);



    const { t } = useTranslation(["middlepart2"]);
    return (
        <>
            <nav className="pledge1">
                <div className="pledge1-container">
                    <div className='pledge-icon'>
                        {/* <img src={pledgeicon} className="photo" alt="Hours Mission"/> */}
                        {t("100Hoursmission")}

                    </div>

                    <div className='pledge-description'>
                        {/* <h3>{t("Swachhbharatabhiyan")}</h3> */}
                        <h3>{pledgeHeading[newPledgeHeading]}</h3>
                        {pledges[index].split("\n").map((i, key) => {
                            return <div key={key}>{i}</div>;
                        })}
                        {/* {t("Primeministershrinarendramodilaunchedtheambitious'SwachhBharatAbhiyan'(CleanIndiaMission)2ndOctober2014The'Abhiyan'waslaunchedontheocassionofmahatamagandhi's145thbirthanniversary")} */}
                        {/* {pledges[index]} */}

                        
                            {/* <button>{t("Joinsbmission")}</button> */}
                            <button class="button pledgeButton1">{pledgeButtonText[newPledgeButtonText].split("\n").map((i, key) => {
                                return <div key={key}>{i}</div>;
                            })}</button>

                    </div>
                </div>
            </nav>

        </>
    )
}

export default Pledge1