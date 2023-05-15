import React, { } from "react";
// import './ComplaintAdmin.css'
import Sidebar from "./Sidebar/Sidebar";
import MainDash from "./MainDash/MainDash";
import RightSide from "./RightSide/RightSide";
import ListofComplaints from "./ListofComplaints";

function ComplaintAdmin() {

  return (
    <>
      <div className="Admin">
        <ListofComplaints />
      </div>
    </>
  );

  
  // return (
  //   <>
  //     <div className="Admin">
  //       <div className="AppGlass">
  //         <Sidebar />
  //         <MainDash />
          
  //         {/* <RightSide /> */}
  //       </div>
  //     </div>
  //   </>
  // );
}

export default ComplaintAdmin;