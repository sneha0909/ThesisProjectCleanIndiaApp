import React, { useState } from "react";
import axios from "axios";
import { Button, Image, Card, Modal } from "semantic-ui-react";

const PhotoGallery = ({ photos }) => {
  const [selectedPhoto, setSelectedPhoto] = useState(null);
  const [deleteModalOpen, setDeleteModalOpen] = useState(false);
  const [setProfilePicModalOpen, setSetProfilePicModalOpen] = useState(false);

  const token = localStorage.getItem("token");
  

  const handleDelete = async () => {
    try {
      const response = await axios.delete(`https://localhost:5001/api/Photos/${selectedPhoto.id}`, {
        headers: {
          Authorization: `Bearer ${token}`
        }
      });
      console.log(response.data);
     
      // Add your code to update the photo gallery after deleting the photo here

    } catch (error) {
      console.error(error);
      // Handle error here
    }
    setDeleteModalOpen(false);
    setSelectedPhoto(null);
  };

  const handleSetProfilePicClick = async () => {
    
    try {
        const response = await axios.post(
          `https://localhost:5001/api/Photos/${selectedPhoto.id}/setMain`,
          null,
          {
            headers: {
              Authorization: `Bearer ${token}`,
            },
          }
        );
        console.log("Setting profile pic:", selectedPhoto);
        setSetProfilePicModalOpen(false);
        setSelectedPhoto(null);
      } catch (error) {
        console.error(error);
        // Handle error here
      }
      
  };
  
  
  
  

  return (
    <div style={{ display: "flex", flexDirection: "row", flexWrap: "wrap" }}>
      <Card.Group>
        {photos.map((photo) => (
          <Card
            key={photo.id}
            style={{ width: "18rem", height: "200px" }}
            onClick={() => setSelectedPhoto(photo)}
          >
            <Image src={photo.url} style={{ height: "200px", width: "290px" }} />
            <Card.Content extra>
              <div className="ui two buttons">
                <Button
                  basic
                  color="red"
                  onClick={() => setDeleteModalOpen(true)}
                  disabled={!selectedPhoto || selectedPhoto.id !== photo.id}
                >
                  Delete
                </Button>
                <Button
                  basic
                  color="green"
                  onClick={() => setSetProfilePicModalOpen(true)}
                  disabled={!selectedPhoto || selectedPhoto.id !== photo.id}
                >
                  Set as Profile Pic
                </Button>
              </div>
            </Card.Content>
          </Card>
        ))}
      </Card.Group>

      {/* Delete Photo Modal */}
      <Modal
        open={deleteModalOpen}
        onClose={() => setDeleteModalOpen(false)}
        size="tiny"
        dimmer="inverted"
      >
        <Modal.Header>Delete Photo?</Modal.Header>
        <Modal.Content>
          <p>Are you sure you want to delete this photo?</p>
        </Modal.Content>
        <Modal.Actions>
          <Button basic color="grey" onClick={() => setDeleteModalOpen(false)}>
            Cancel
          </Button>
          <Button color="red" onClick={handleDelete}>
            Delete
          </Button>
        </Modal.Actions>
      </Modal>

      {/* Set Profile Pic Modal */}
      <Modal
        open={setProfilePicModalOpen}
        onClose={() => setSetProfilePicModalOpen(false)}
        size="tiny"
        dimmer="inverted"
      >
        <Modal.Header>Set as Profile Picture?</Modal.Header>
        <Modal.Content>
          <p>Are you sure you want to set this photo as your profile picture?</p>
        </Modal.Content>
        <Modal.Actions>
          <Button
            basic
            color="grey"
            onClick={() => setSetProfilePicModalOpen(false)}
          >
            Cancel
          </Button>
          <Button color="green" onClick={handleSetProfilePicClick}>
            Set as Profile Pic
          </Button>
        </Modal.Actions>
      </Modal>
    </div>
  );
};

export default PhotoGallery;
