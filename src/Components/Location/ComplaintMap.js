import React from "react";
import { MapContainer, GeoJSON } from "react-leaflet";
import "leaflet/dist/leaflet.css";
import "../Location/ComplaintMap.css";


const ComplaintMap = ({ indianStates }) => {
    const mapStyle = {
        fillColor: "white",
        weight: 1,
        color: "black",
        fillOpacity: 1,
    };
    //console.log(indianStates);

    const onEachCountry = (istate, layer) => {
        layer.options.fillColor = istate.properties.color;
        const name = istate.properties.NAME_1;
        const confirmedText = istate.properties.confirmedText;
        layer.bindPopup(`${name} ${confirmedText}`);
    }
    return (
        <MapContainer style={{ height: "90vh" }} zoom={2} center={[20, 100]}>
            <GeoJSON style={mapStyle} data={indianStates} onEachFeature={onEachCountry} />

        </MapContainer>
    );

};

export default ComplaintMap;