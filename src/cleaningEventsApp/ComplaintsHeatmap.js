import React, { useState, useEffect } from "react";
import axios from "axios";
import GoogleMapReact from "google-map-react";
import HeatmapLayer from "google-map-react-heatmap";

const ComplaintsHeatmap = () => {
  const [complaintData, setComplaintData] = useState([]);

  useEffect(() => {
    const fetchComplaintData = async () => {
      try {
        const response = await axios.get("http://localhost:5000/api/CleaningEvents");
        console.log(response.data);
        setComplaintData(response.data);
      } catch (error) {
        console.log(error);
      }
    };

    fetchComplaintData();
  }, []);

  return (
    <div style={{ height: "100vh", width: "100%" }}>
      <GoogleMapReact
        bootstrapURLKeys={{ key: "AIzaSyA6iTv5EZiD487CQwyq07hiZU64LGBLu7U" }}
        defaultCenter={{ lat: 22.5937, lng: 78.9629 }}
        defaultZoom={4}
      >
        <HeatmapLayer
          points={complaintData}
          options={{ radius: 20 }}
          heatmapMode={"POINTS_WEIGHT"}
        />
      </GoogleMapReact>
    </div>
  );
};

export default ComplaintsHeatmap;
