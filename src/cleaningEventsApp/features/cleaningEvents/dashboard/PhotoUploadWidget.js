import React, { useState, useEffect } from "react";
import axios from "axios";
import {
  Button,
  Grid,
  Header
} from "semantic-ui-react";
import PhotoWidgetDropzone from "./PhotoWidgetDropzone";
import PhotoWidgetCropper from "./PhotoWidgetCropper";

export default function PhotoUploadWidget({ setUrl }) {
  const [files, setFiles] = useState([]);
  const [cropper, setCropper] = useState();

  function onCrop() {
    const token = localStorage.getItem("token");
    if (cropper) {
      cropper.getCroppedCanvas().toBlob((blob) => {
        console.log(blob);
        const formData = new FormData();
        formData.append("file", blob, files[0].name);

        axios
          .post("https://localhost:5001/api/Photos", formData, {
            headers: {
              Authorization: `Bearer ${token}`,
              // "Content-Type": "multipart/form-data"
            },
          })

          .then((response) => {
            console.log(response.data.url);
            setUrl(response.data.url);
          })
          .catch((error) => {
            console.log(error.response.data);
          });
      });
    }
  }

  useEffect(() => {
    return () => {
      files.forEach((file) => URL.revokeObjectURL(file.preview));
    };
  }, [files]);

  return (
    <>
      
        <Grid>
          <Grid.Column width={4}>
            <Header sub color="teal" content="Step 1 - Add Photo" />
            <PhotoWidgetDropzone setFiles={setFiles} />
          </Grid.Column>
          <Grid.Column width={1} />
          <Grid.Column width={4}>
            <Header sub color="teal" content="Step 2 - Resize image" />
            {files && files.length > 0 && (
              <PhotoWidgetCropper
                setCropper={setCropper}
                imagePreview={files[0].preview}
              />
            )}
          </Grid.Column>
          <Grid.Column width={1} />
          <Grid.Column width={4}>
            <Header sub color="teal" content="Step 3 - Preview & Upload" />
            {files && files.length > 0 && (
              <>
                <div
                  className="img-preview"
                  style={{ minHeight: 200, overflow: "hidden" }}
                />
                <Button.Group widths={2}>
                  <Button onClick={onCrop} positive icon="check" />
                  <Button onClick={() => setFiles([])} icon="close" />
                </Button.Group>
              </>
            )}
          </Grid.Column>
        </Grid>
      
    </>
  );
}
