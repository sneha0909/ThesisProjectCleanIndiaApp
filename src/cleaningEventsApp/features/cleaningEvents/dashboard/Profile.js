import React, { useState, useEffect } from "react";
import axios from "axios";
import { Button, Form, Grid, Header, Message, Segment, Image } from "semantic-ui-react";
import { useNavigate } from 'react-router-dom';
import PhotoUploadWidget from "./PhotoUploadWidget";
import PhotoGallery from "./PhotoGallery";
import Navbar1 from "../../../../Components/Navbar1/Navbar1";
import Navbar2 from "../../../../Components/Navbar2/Navbar2";
import RegisterFooter from "../../../../Components/Pages/Register Page/RegisterFooter";

const Profile = () => {
  const navigate = useNavigate();
  const [displayName, setDisplayName] = useState("");
  const [bio, setBio] = useState("");
  const [pic, setPic] = useState("");
  const [errorMessage, setErrorMessage] = useState("");
  const [editing, setEditing] = useState(true);
  const [showPhotosForm, setShowPhotosForm] = useState(false);
  const [showPhotoUploadButton, setShowPhotoUploadButton] = useState(false);
  const [showPhotosGallery, setShowPhotosGallery] = useState(false);

  const [imageUrl, setImageUrl] = useState("");
  const [photos, setPhotos] = useState([]);



  const setUrl = (url) => {
    setImageUrl(url);
  };

  
  useEffect(() => {
    const token = localStorage.getItem("token");
    axios
      .get(`https://localhost:5001/api/Profiles/${localStorage.getItem('username')}`, {
        headers: {
          Authorization: `Bearer ${token}`
        }
      })
      .then((response) => {
        console.log(response.data);
        setDisplayName(response.data.displayName);
        setBio(response.data.bio);
        setPic(response.data.image);
        setPhotos(response.data.photos);
      })
      .catch((error) => {
        console.log(error.response.data);
        setErrorMessage("Failed to fetch user details");
      });
  }, []);

  const handleEdit = (e) => {
    e.preventDefault();
    const token = localStorage.getItem("token");
    axios
      .put(`https://localhost:5001/api/profiles`, { displayName, bio }, {
        headers: {
          Authorization: `Bearer ${token}`
        }
      })
      .then((response) => {
        console.log(response.data);
        navigate('/profile');
      })
      .catch((error) => {
        console.log(error.response.data);
        setErrorMessage("Failed to update user details");
      });
  };

  const handleLogout = () => {
    localStorage.removeItem("token");
    navigate('/login');
  };

  return (
    <>
    <Navbar2/>
    <Grid columns={2} stackable centered style={{ margin: "0 auto", maxWidth: 800 }}>
      <Grid.Column width={4} style={{padding: 0}} >
        <Segment >
          <Image src={pic} circular centered />
        
          <Button style={{margin: '10px'}} fluid color="teal" onClick={() => {setEditing(true); setShowPhotosForm(false); setShowPhotosGallery(false);}}>
            Edit Profile
          </Button>
          <Button style={{margin: '10px'}} fluid onClick={() => {setShowPhotosForm(true); setShowPhotoUploadButton(true); setEditing(false); setShowPhotosGallery(false);}}>
            Add Photo
          </Button>
          <Button style={{margin: '10px'}} fluid onClick={() => { setShowPhotosGallery(true); setShowPhotosForm(false); setShowPhotoUploadButton(false); setEditing(false);}}>
            Photos Gallery
          </Button>
          <Button style={{margin: '10px'}} fluid color="red" onClick={handleLogout}>
          Logout
        </Button>
        </Segment>
      </Grid.Column>
      <Grid.Column width={12}>
        <Segment>
        {editing && (
          <>
          <Header as="h2">Edit Profile</Header>
          <Form onSubmit={handleEdit}>
            <Form.Field>
              <label>Display Name</label>
              <input
                type="text"
                placeholder="Display Name"
                value={displayName}
                onChange={(e) => setDisplayName(e.target.value)}
              />
            </Form.Field>
            <Form.Field>
              <label>Bio</label>
              <textarea
                rows={3}
                placeholder="Tell us about yourself"
                value={bio}
                onChange={(e) => setBio(e.target.value)}
              />
            </Form.Field>
            <Button fluid type="submit" color="teal">
              Save Changes
            </Button>
          </Form>
          {errorMessage && (
            <Message negative>
              <Message.Header>{errorMessage}</Message.Header>
            </Message>
          )}
          </>
          )}
        

        {showPhotosForm && (
          <>
          
          
          <PhotoUploadWidget setUrl={setUrl} />
          </>
        )}

        
          {showPhotosGallery && (
            <>

            <PhotoGallery photos={photos} />
            
            
            </>
          )}
        </Segment>
      </Grid.Column>
    </Grid>
    <RegisterFooter />
    </>
  );
};

export default Profile;
