import React, { useEffect, useRef, useState } from "react";
import L from "leaflet";
import "leaflet/dist/leaflet.css";
import axios from "axios";
import "leaflet.heat/dist/leaflet-heat.js";
import "leaflet.markercluster/dist/MarkerCluster.css";
import "leaflet.markercluster/dist/MarkerCluster.Default.css";
import "leaflet.markercluster/dist/leaflet.markercluster";

function Map() {
  const mapRef = useRef(null);
  const [complaints, setComplaints] = useState([]);

  useEffect(() => {
    if (!mapRef.current) {
      mapRef.current = L.map("mapid").setView([20.5937, 78.9629], 4);

      L.tileLayer("https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png", {
        attribution:
          'Map data © <a href="https://openstreetmap.org">OpenStreetMap</a> contributors',
      }).addTo(mapRef.current);
    }
  }, []);

  useEffect(() => {
    axios
      .get("https://localhost:5001/api/Complaints")
      .then((response) => {
        setComplaints(response.data);
        console.log(response.data); // print the response data to console
      })
      .catch((error) => {
        console.error(error);
      });
  }, []);

  useEffect(() => {
    const markers = L.markerClusterGroup();
    const complaintStatus = {
      "In Review": 0,
      Filed: 0,
      Resolved: 0,
    };

    const requests = complaints.map((complaint) => {
      const { complainantAddressState } = complaint;
      const url = `https://api.opencagedata.com/geocode/v1/json?q=${complainantAddressState}&key=f4e9e0e3686544438a2802560aa31af3`;
      return axios.get(url);
    });

    Promise.all(requests)
      .then((responses) => {
        const childMarkers = responses.map((response, index) => {
          const { lat, lng } = response.data.results[0].geometry;
          const marker = L.marker([lat, lng], {
            complaintStatus: complaints[index].complaintStatus,
          });

          const status = complaints[index].complaintStatus;
          if (status in complaintStatus) {
            complaintStatus[status] += 1;
          }

          return marker;
        });

        markers.addLayers(childMarkers);

        markers.on("clusterclick", function (event) {
          const childStatus = {
            "In Review": 0,
            Filed: 0,
            Resolved: 0,
          };

          const childMarkers = event.layer.getAllChildMarkers();
          childMarkers.forEach((childMarker) => {
            const status = childMarker.options.complaintStatus;
            if (status in childStatus) {
              childStatus[status] += 1;
            }
          });

          const statusList = Object.entries(childStatus)
            .map(([status, count]) => `${status}: ${count}`)
            .join("<br>");
          const popupContent = `<b>Number of Complaints:</b> ${
            event.layer.getAllChildMarkers().length
          }<br><br>${statusList}`;
          L.popup()
            .setLatLng(event.latlng)
            .setContent(popupContent)
            .openOn(mapRef.current);
        });

        mapRef.current.addLayer(markers);
      })
      .catch((error) => {
        console.error(error);
      });
  }, [complaints]);

  return <div id="mapid" style={{ height: "800px" }} />;
}

export default Map;
