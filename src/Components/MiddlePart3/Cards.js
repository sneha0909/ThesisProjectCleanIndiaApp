import React from 'react';
import CardItem from './CardItem';
import '../MiddlePart3/Cards.css';
import activity1 from '../../images/activity1.jpeg';
import activity2 from '../../images/activity2.jpg';
import activity3 from '../../images/activity3.jpg';
import activity4 from '../../images/activity4.jpg';
import activity5 from '../../images/activity5.jpg';
import activity6 from '../../images/activity6.jpg';
import { useTranslation } from "react-i18next";


function Cards() {
    const {t} = useTranslation(["middlepart3"]);
    return (
        <div className='cards'>
            <h1>{t("Swachhbharatpinboard")}</h1>
            <div className='cards__container'>
                <div className='cards__wrapper'>
                    <ul className='cards__items'>
                        <CardItem
                            src={activity1}
                            text= {t("Generalcleanlinessincommonarea2ndfloor")}
                            label={t("Swachhbharatactivity")}
                            path='/services'
                        />
                        <CardItem
                            src={activity2}
                            text={t("Plasticfreechandigarhcampaignlaunchedbymayorchdsmtsarbjitkaurandmsaninditamitraiasmcccommissioner")}
                            label={t("Swachhbharatactivity")}
                            path='/services'
                        />
                    </ul>
                    <ul className='cards__items'>
                        <CardItem
                            src={activity3}
                            text={t("Cleanalambiprojecton73rdRepublicDayofIndia")}
                            label={t("Swachhbharatactivity")}
                            path='/services'
                        />
                        <CardItem
                            src={activity4}
                            text={t("Generalcleanlinessincommonareas")}
                            label={t("Swachhbharatactivity")}
                            path='/services'
                        />
                    </ul>
                    <ul className='cards__items'>
                        <CardItem
                            src={activity5}
                            text={t("CleanIndiacampaignbynssnykavolunteersinjasanapanchayat")}
                            label={t("Swachhbharatactivity")}
                            path='/services'
                        />
                        <CardItem
                            src={activity6}
                            text={t("Generalcleaningofcommonareas(Electronicniketanbuilding3rdfloor).")}
                            label={t("Swachhbharatactivity")}
                            path='/services'
                        />

                    </ul>
                </div>
            </div>
        </div>
    )
}

export default Cards;