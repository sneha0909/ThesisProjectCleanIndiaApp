import React, { } from "react";
import GoogleLocationForm from '../../Location/GoogleLocationForm';


function LoggedinPage() {

    return (       
      <>
      <div className="Intro">
        <h1>You're Logged In!</h1>      
      </div>
      <GoogleLocationForm/>
      </>

    );
}

export default LoggedinPage;