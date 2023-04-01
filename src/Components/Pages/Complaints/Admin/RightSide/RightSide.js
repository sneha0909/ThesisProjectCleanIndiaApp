import React from "react";
import ComplainantReview from "../ComplaintReviews/ComplainantReview";
import Updates from "../Updates/Updates";
import "../RightSide/RightSide.css";

const RightSide = () => {
  return (
    <div className="RightSide">
      <div>
        <h3>Updates</h3>
        <Updates />
      </div>
      <div>
        <h3>Complainant Review</h3>
        <ComplainantReview />
      </div>
    </div>
  );
};

export default RightSide;