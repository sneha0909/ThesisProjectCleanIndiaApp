import React, { useEffect, useRef, useState } from 'react'
import GpsFixedIcon from '@mui/icons-material/GpsFixed';
import SearchIcon from '@mui/icons-material/Search';


// const apiKey = import.meta.env.CLEAN_INDIA_GMAP_API_KEY;
const apiKey = "AIzaSyA6iTv5EZiD487CQwyq07hiZU64LGBLu7U";
const mapApiJs = 'https://maps.googleapis.com/maps/api/js';
const geocodeJson = 'https://maps.googleapis.com/maps/api/geocode/json';


//load google map api js
function loadAsyncScript(src) {
  return new Promise(resolve => {
    const script = document.createElement("script");
    Object.assign(script, {
      type: "text/javascript",
      async: true,
      src
    })
    script.addEventListener("load", () => resolve(script));
    document.head.appendChild(script);
  })
}

function GoogleLocationForm() {
    const mapContainerRef = useRef(null);
    const mapRef = useRef(null);
  
    const initMapScript = () => {
      if (window.google) {
        return Promise.resolve();
      }
      const src = `${mapApiJs}?key=${apiKey}&libraries=places&v=weekly`;
      return loadAsyncScript(src);
    }
  
    const initMap = () => {
      if (!mapContainerRef.current) return;
  
      const mapOptions = {
        center: { lat: 28.6139, lng: 77.209 },
        zoom: 10,
      };
  
      mapRef.current = new window.google.maps.Map(mapContainerRef.current, mapOptions);
  
      // Set the default marker at New Delhi
      const marker = new window.google.maps.Marker({
        position: { lat: 28.6139, lng: 77.209 },
        map: mapRef.current,
      });
    };
  
    useEffect(() => {
      initMapScript().then(() => {
        initMap();
      });
    }, []);
  
    return (
      <>
        <div className='GoogleMaps'>
          <div ref={mapContainerRef} style={{ height: '500px', width: '100%' }}></div>
        </div>
      </>
    );
  }
  
export default GoogleLocationForm;


