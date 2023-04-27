import React, {useState, useEffect} from 'react';
import Loading from "./Loading";
import ComplaintMap from '../Location/ComplaintMap';
import LoadIndianStatesTask from '../../tasks/LoadIndianStatesTask';
import Legend from '../Location/Legend';
import legendItems from '../../entities/LegendItems';

const Heatmap = () => {

  const [indianStates, setIndianStates] = useState([]);

  const legendItemsReverse = [...legendItems].reverse();
  
  const load = () => {
    const loadIndianStatesTask = new LoadIndianStatesTask();
    loadIndianStatesTask.load((indianStates) => setIndianStates(indianStates));
  };

  useEffect(load, []);

  return (
    <div>
      {indianStates.length === 0 ? (
        <Loading />
      ) : (
        <div>
          <ComplaintMap indianStates={indianStates} />
          <Legend legendItems={legendItemsReverse} />
        </div>
      )}
    </div>

  );
  
};

export default Heatmap;





// import React from 'react';
// import { MapContainer, TileLayer, useMap, Marker, Popup } from 'react-leaflet';
// import '../Location/Heatmap.css';

// export default function Heatmap() {
//   return (
//     <MapContainer center={[51.505, -0.09]} zoom={13} scrollWheelZoom={true}>
//   <TileLayer
//     attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
//     url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
//   />
//   <Marker position={[51.505, -0.09]}>
//     <Popup>
//       A pretty CSS3 popup. <br /> Easily customizable.
//     </Popup>
//   </Marker>
// </MapContainer>

//   );
// }

// import React from 'react';
// import { GoogleMap, LoadScript, MarkerF } from '@react-google-maps/api';

// const Heatmap = () => {
  
//     const locations = [
//         {
//           name: "Location 1",
//           location: { 
//             lat: 41.3954,
//             lng: 2.162 
//           },
//         },
//         {
//           name: "Location 2",
//           location: { 
//             lat: 41.3917,
//             lng: 2.1649
//           },
//         },
//         {
//           name: "Location 3",
//           location: { 
//             lat: 41.3773,
//             lng: 2.1585
//           },
//         },
//         {
//           name: "Location 4",
//           location: { 
//             lat: 41.3797,
//             lng: 2.1682
//           },
//         },
//         {
//           name: "Location 5",
//           location: { 
//             lat: 41.4055,
//             lng: 2.1915
//           },
//         }
//       ];

//       const heatmapData = 
//       [
//         new window.google.maps.LatLng(37.765153, -122.418618),
//         new window.google.maps.LatLng(37.765136, -122.419112),
//         new window.google.maps.LatLng(37.765129, -122.419378),
//         new window.google.maps.LatLng(37.765119, -122.419481),
//         new window.google.maps.LatLng(37.7651, -122.419852),
//       ]

//       const mapStyles = {        
//         height: "100vh",
//         width: "100%"};
      
//       const defaultCenter = {
//         lat: 41.3851, lng: 2.1734
//       }

  
//   return (
//      <LoadScript
//        googleMapsApiKey='AIzaSyA6iTv5EZiD487CQwyq07hiZU64LGBLu7U&libraries=visualization'>
//         <GoogleMap
//           mapContainerStyle={mapStyles}
//           zoom={13}
//           center={defaultCenter}>
//          {
//             locations.map(item => {
//               return (
//               <MarkerF key={item.name} position={item.location}/>
//               )
//             })
//          }
//      </GoogleMap>
//      </LoadScript>
//   )
//         }

// export default Heatmap;