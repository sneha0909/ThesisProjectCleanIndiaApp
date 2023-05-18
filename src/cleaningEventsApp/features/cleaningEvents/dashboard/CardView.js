import React, { useState, useEffect } from "react";
import axios from "axios";
import { useParams, useNavigate } from "react-router-dom";
import { Card, Button, Image, Icon } from "semantic-ui-react";
import CardEdit from "./CardEdit";
import RegisterFooter from "../../../../Components/Pages/Register Page/RegisterFooter";
import LoginNavbar from "../../../../Components/Pages/Login Page/LoginNavbar";
import { google } from 'google-maps';
import GoogleLocationForm from "./EventLocation";
import './CardView.css';



const CardView = () => {
  const [currentUser, setCurrentUser] = useState(null);
  const { id } = useParams();
  const navigate = useNavigate();
  const [event, setEvent] = useState({});
  const [isEditing, setIsEditing] = useState(false);
  const [title, setTitle] = useState("");
  const [description, setDescription] = useState("");
  const [category, setCategory] = useState("");
  const [date, setDate] = useState("");
  const [city, setCity] = useState("");
  const [venue, setVenue] = useState("");
  const [buttonName, setButtonName] = useState( () => {
    if (event.attendees?.some(
      (a) => a.username === currentUser?.username))
      {
        return "Cancel Attendance"
      }
    else{
      return "Join Event";
    }
    
    });

    useEffect(() => {
      if (event.attendees?.some((a) => a.username === currentUser?.username)) {
        setButtonName("Cancel Attendance");
      } else {
        setButtonName("Join Event");
      }
    }, [event, currentUser]);

  const [hostProfilePic, setHostProfilePic] = useState(null);

  useEffect(() => {
    if (event.hostUsername) {
      axios.get(`http://localhost:5000/api/profiles/${event.hostUsername}`, {
      headers: {
        Authorization: `Bearer ${token}` // Replace `token` with your actual JWT token
      }
    })
    axios.get(`http://localhost:5000/api/profiles/${event.hostUsername}`, {
      headers: {
        Authorization: `Bearer ${token}` // Replace `token` with your actual JWT token
      }
    })
    .then((response) => {
      const { data } = response;
      setHostProfilePic(data.image);
    })
    .catch((error) => {
      console.log(error);
    });
}
}, [event]);
    
  const token = localStorage.getItem("token");

  useEffect(() => {
    console.log(currentUser);
  }, [currentUser]);

  useEffect(() => {
    // Make a GET request to the endpoint to get the current user data
    axios
      .get(`https://localhost:5001/api/Account`, {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      })
      .then((res) => {
        setCurrentUser(res.data);
      })
      .catch((err) => {
        console.log(err);
      });
  }, []);

  useEffect(() => {
    const getEvent = async (id) => {
      try {
        const response = await axios.get(
          `http://localhost:5000/api/CleaningEvents/${id}`,
          {
            headers: {
              Authorization: `Bearer ${token}`,
            },
          }
        );
        console.log(response.data);
        setEvent(response.data);
      } catch (error) {
        console.log(error);
      }
    };

    getEvent(id);
  }, [id]);

  const handleCancel = () => {
    navigate.goBack();
  };

  const handleSubmit = async () => {
    try {
      const updatedEvent = {
        ...event,
        title,
        description,
        category,
        date,
        city,
        venue,
      };
      const response = await axios.put(
        `http://localhost:5000/api/CleaningEvents/${id}`,

        updatedEvent,
        {
          headers: {
            Authorization: `Bearer ${token}`,
            "Content-Type": "multipart/form-data",
          },
        }
      );

      setEvent(response.data);
      setIsEditing(false);
    } catch (error) {
      console.log(error);
    }
  };

  const handleEdit = () => {
    setTitle(event.title);
    setDescription(event.description);
    setCategory(event.category);
    setDate(event.date);
    setCity(event.city);
    setVenue(event.venue);
    setIsEditing(true);
  };

  const handleCancelEvent = async () => {
    try {
      await axios.delete(`http://localhost:5000/api/CleaningEvents/${id}`, {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      });
      navigate(-1);
    } catch (error) {
      console.log(error);
    }
  };

  const handleJoinEvent = async () => {
    try {
      await axios.post(
        `https://localhost:5001/api/CleaningEvents/${id}/attend`,
        null,
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      );
      setButtonName("Cancel Attendance");
    } catch (error) {
      console.log(error);
    }
  };

  const handleCancelAttendance = async () => {
    console.log(buttonName);
    try {
      await axios.post(
        `https://localhost:5001/api/CleaningEvents/${id}/attend`,
        null,
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      );
      
      setButtonName("Join Event");
      console.log(buttonName);
    } catch (error) {
      console.log(error);
    }
  };
  const [venueforLocation, setVenueForLocation] = useState('');
  const [isButtonClicked, setIsButtonClicked] = useState(false);

  const handleSeeDirectionClick = () => {
    // Set the venue value
    setVenueForLocation(event.venue);

    // Set the button clicked flag
    setIsButtonClicked(true);
  };

  console.log(event.venue);
  console.log(venueforLocation);

  return (
    <>
    <LoginNavbar />
    <div className="Container">
    <Card style={{ width: "600px", margin: "20px", height: "550px" }}>
      <Card.Content>
        {isEditing ? (
          <CardEdit
            event={event}
            onCancel={handleCancel}
            onSubmit={handleSubmit}
          />
        ) : (
          <>
            <Card.Header>
              <Image src={hostProfilePic} avatar size="massive" />
              {event.title}
            </Card.Header>
            <Card.Meta>{event.date}</Card.Meta>
            <Card.Description>{event.description}</Card.Description>
            {event.venue &&
      <Card.Description>
        <Icon name="map marker alternate" color="teal" />
        {event.venue}
      </Card.Description>
    }

            {event.hostUsername === currentUser?.username && (
              <Card.Content extra>
                <Icon name="star" color="yellow" />
                You are hosting this activity
              </Card.Content>
            )}
            {event.hostUsername !== currentUser?.username && (
              <Card.Content extra>
                <Icon name="user" />
                Host: {event.hostUsername}
              </Card.Content>
            )}
            {event.attendees?.some(
              (a) => a.username === currentUser?.username
            ) && (
              <Card.Content extra>
                <Icon name="check" color="green" />
                You're going to this event
              </Card.Content>
            )}

            {event.attendees && event.attendees.length > 0 && (
              <Card.Content extra>
                <Icon name="users" size="big" />
                Attendees:{" "}
                {event.attendees.map((a) => a.displayName).join(", ") || "None"}
              </Card.Content>
            )}
          </>
        )}
      </Card.Content>
      <Card.Content extra>
        <div className="ui two buttons">

          
        {event.hostUsername !== currentUser?.username ? (
        <Button onClick={
          event.attendees?.some((a) => a.username === currentUser?.username)
            ? handleCancelAttendance
            : handleJoinEvent
        }>
          {buttonName}
        </Button>
          ) : (
            <>
              <Button onClick={handleCancelEvent}>Cancel event</Button>
              <Button onClick={handleEdit}>Manage event</Button>
            </>
          )}

          
<Button onClick={handleSeeDirectionClick }>Check distance</Button>

          
        </div>
      </Card.Content>
    </Card>
    
    
    {/* Render the Google Maps component */}
    {isButtonClicked && <GoogleLocationForm venueforLocation={venueforLocation} />}
    </div>
    <RegisterFooter />
    </>
  );
};

export default CardView;
