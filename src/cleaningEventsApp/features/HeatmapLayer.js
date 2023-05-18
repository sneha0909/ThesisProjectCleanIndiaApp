import React, { useEffect, useRef } from "react";
import L from "leaflet";

const HeatmapLayer = ({ data }) => {
  const canvasRef = useRef(null);

  useEffect(() => {
    const canvas = canvasRef.current;
    const context = canvas.getContext("2d");

    // Implement the custom heatmap logic here
    const width = canvas.width;
const height = canvas.height;

const maxValue = Object.keys(data).reduce((max, key) => {
  const count = data[key].length;
  return count > max ? count : max;
}, 0);

const gradient = context.createLinearGradient(0, 0, width, 0);
gradient.addColorStop(0, "green");
gradient.addColorStop(0.5, "yellow");
gradient.addColorStop(1, "red");

Object.keys(data).forEach((state) => {
  const complaints = data[state];

  const latLngs = complaints.map((complaint) => [    complaint.latitude,    complaint.longitude,  ]);

  const intensity = complaints.length / maxValue;
  const color = gradient(intensity);

  L.canvasOverlay()
    .drawing(drawingOnCanvas)
    .addTo(map);

  function drawingOnCanvas(canvasOverlay, params) {
    const ctx = params.canvas.getContext("2d");
    const bounds = params.bounds;

    const topLeft = map.latLngToLayerPoint(bounds.getNorthWest());
    const bottomRight = map.latLngToLayerPoint(bounds.getSouthEast());

    const scaleX = (bottomRight.x - topLeft.x) / width;
    const scaleY = (bottomRight.y - topLeft.y) / height;

    complaints.forEach((complaint) => {
      const latLng = L.latLng(complaint.latitude, complaint.longitude);
      const point = map.latLngToLayerPoint(latLng);

      const x = (point.x - topLeft.x) / scaleX;
      const y = (point.y - topLeft.y) / scaleY;

      const radius = 10;
      const opacity = 0.5;

      ctx.beginPath();
      ctx.arc(x, y, radius, 0, 2 * Math.PI, false);
      ctx.fillStyle = color;
      ctx.globalAlpha = opacity;
      ctx.fill();
      ctx.closePath();
    });
  }
});

  }, [data]);

  return <canvas ref={canvasRef} />;
};

export default HeatmapLayer;
