import { useState, useEffect } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import {
  Card,
  Icon,
  Menu,
  Sidebar,
  Segment,
  Header,
  Image,
  Button,
} from "semantic-ui-react";
import { Link } from "react-router-dom";
import "./CardList.css";
import CardView from "./CardView";
import Navbar2 from "../../../../Components/Navbar2/Navbar2";
import RegisterFooter from "../../../../Components/Pages/Register Page/RegisterFooter";
import LoginNavbar from "../../../../Components/Pages/Login Page/LoginNavbar";
import moment from "moment";

const CardList = () => {
  const navigate = useNavigate();
  const [events, setEvents] = useState([]);
  const [activePage, setActivePage] = useState(1);
  const [totalPages, setTotalPages] = useState(1);
  const [sidebarVisible, setSidebarVisible] = useState(false);
  const [currentUser, setCurrentUser] = useState(null);
  const [selectedEventId, setSelectedEventId] = useState(null);
  const [hostProfilePics, setHostProfilePics] = useState({});
  const [filter, setFilter] = useState("All");

  const handleSidebarHide = () => {
    setSidebarVisible(false);
  };
  const handleSidebarToggle = () => setSidebarVisible(!sidebarVisible);

  const token = localStorage.getItem("token");

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
    axios
      .get(
        `http://localhost:5000/api/CleaningEvents?page=${activePage}&limit=10`,
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      )
      .then((response) => {
        console.log(response.data);
        setEvents(response.data);
        setTotalPages(response.data.totalPages);
      })
      .catch((error) => console.error(error));
  }, [activePage]);

  useEffect(() => {
    const fetchHostProfilePic = async (hostUsername) => {
      try {
        const response = await axios.get(
          `http://localhost:5000/api/profiles/${hostUsername}`,
          {
            headers: {
              Authorization: `Bearer ${token}`,
            },
          }
        );
        setHostProfilePics((prevState) => ({
          ...prevState,
          [hostUsername]: response.data.image,
        }));
      } catch (error) {
        console.error(error);
      }
    };

    events.forEach((event) => {
      fetchHostProfilePic(event.hostUsername);
    });
    console.log("Host Profile Pics: ", hostProfilePics);
  }, [events, token]);

  const handleLogout = () => {
    localStorage.removeItem("token");
    navigate("/login");
  };

  const handleCardClick = (eventId) => {
    setSelectedEventId(eventId);
  };

  const handlePageChange = (e, { activePage }) => {
    setActivePage(activePage);
  };

  const handleFilterChange = (selectedFilter) => {
    setFilter(selectedFilter);
  };

  const filteredEvents = events.filter((event) => {
    if (filter === "Host") {
      return event.hostUsername === currentUser?.username;
    }
    if (filter === "Attending") {
      return event.attendees?.some((a) => a.username === currentUser?.username);
    }
    return true; // Show all events
  });
  const handleDateFilter = () => {
    // Implement the date filter logic here
    // You can use a state variable to store the selected date and apply the filter accordingly
  };

  return (
    <>
      <LoginNavbar />
      <Sidebar.Pushable as={Segment}>
        <Sidebar
          as={Menu}
          animation="overlay"
          icon="labeled"
          inverted
          vertical
          visible={sidebarVisible}
          onHide={handleSidebarHide}
          style={{ backgroundColor: "green", paddingTop: "20px" }}
        >
          <Menu.Item as={Link} to="/profile">
            <Icon name="user" />
            My Profile
          </Menu.Item>
          <Menu.Item onClick={handleLogout}>
            <Icon name="log out" />
            Logout
          </Menu.Item>
          <Menu.Item onClick={() => navigate("/create-event")}>
            <Icon name="add" />
            Create Event
          </Menu.Item>
        </Sidebar>
        <Sidebar.Pusher dimmed={sidebarVisible}>
          <Segment inverted style={{ backgroundColor: "#088F8F" }}>
            <Header
              as="h3"
              textAlign="center"
              style={{
                backgroundColor: "#088F8F",
                color: "#fff",
                padding: "10px",
              }}
            >
              <Icon
                name="content"
                onClick={handleSidebarToggle}
                style={{ cursor: "pointer" }}
              />
              Cleaning Events
            </Header>
          </Segment>

          <div className="card-container">
            {events.length === 0 ? (
              <p>Loading events...</p>
            ) : (
              <>
                <div
                  className="filter-buttons"
                  style={{
                    display: "flex",
                    justifyContent: "center",
                    marginBottom: "20px",
                  }}
                >
                  <Button
                    color={filter === "All" ? "blue" : null}
                    onClick={() => handleFilterChange("All")}
                    icon={<Icon name="filter" />}
                    content="All"
                  ></Button>
                  <Button
                    color={filter === "Host" ? "blue" : null}
                    onClick={() => handleFilterChange("Host")}
                    icon={<Icon name="user" />}
                    content="I am Hosting"
                  ></Button>
                  <Button
                    color={filter === "Attending" ? "blue" : null}
                    onClick={() => handleFilterChange("Attending")}
                    icon={<Icon name="check" />}
                    content="I am Attending"
                  ></Button>

                  <Button icon labelPosition="left" onClick={handleDateFilter}>
                    <Icon name="calendar alternate outline" />
                    Filter by Date
                  </Button>
                </div>
                <Card.Group centered>
                  {filteredEvents.map((event) => (
                    <Card
                      key={event.id}
                      style={{ width: "500px", margin: "20px",  }}
                    >
                      <Card.Content>
                        <Card.Header>
                          <Image
                            src={hostProfilePics[event.hostUsername]}
                            avatar
                            size="massive"
                          />
                          {event.title}
                        </Card.Header>

                        <Card.Description>{event.description}</Card.Description>
                        {event.venue && (
                          <Card.Content extra >
                          <Card.Description >
                            <Icon name="map marker alternate" color="teal" />
                            {event.venue}
                            <Card.Meta>
                              <Icon name="calendar outline" color="teal" />
                              {moment(event.date).format("MMMM Do, YYYY")}
                            </Card.Meta>
                          </Card.Description>
                          </Card.Content>
                        )}
                      </Card.Content >
                      {event.hostUsername === currentUser?.username && (
                        <Card.Content extra style={{ marginBottom: '10px' }}>
                          <Icon name="star" color="yellow" />
                          You are hosting this activity
                        </Card.Content>
                      )}
                      {event.hostUsername !== currentUser?.username && (
                        <Card.Content extra style={{ marginBottom: '10px' }}>
                          <Icon name="user" />
                          Host: {event.hostUsername}
                        </Card.Content>
                      )}
                      {!event.hostUsername.includes(currentUser?.username) &&
                        event.attendees?.some(
                          (a) => a.username === currentUser?.username
                        ) && (
                          <Card.Content extra>
                            <Icon name="check" color="green" />
                            You're going to this event
                          </Card.Content>
                        )}
                      {event.attendees && event.attendees.length > 0 && (
                        <Card.Content extra style={{ marginBottom: '10px' }}>
                          <Icon name="users" size="big" />
                          Attendees:{" "}
                          {event.attendees
                            .map((a) => a.displayName)
                            .join(", ") || "None"}
                        </Card.Content>
                      )}
                      <Card.Content extra style={{ marginBottom: '20px' }}>
                        <div className="ui two buttons">
                          <Link
                            to={`/card/${event.id}`}
                            className="ui basic button green"
                          >
                            View
                          </Link>
                        </div>
                      </Card.Content>
                    </Card>
                  ))}
                </Card.Group>
                {selectedEventId && (
                  <CardView
                    event={events.find((event) => event.id === selectedEventId)}
                    hostProfilePic={
                      hostProfilePics[
                        events.find((event) => event.id === selectedEventId)
                          .hostUsername
                      ]
                    }
                  />
                )}
              </>
            )}
          </div>

          <div className="pagination-container">
            <Menu pagination>
              <Menu.Item
                disabled={activePage === 1}
                onClick={() => setActivePage(activePage - 1)}
              >
                <Icon name="chevron left" />
              </Menu.Item>
              {Array.from({ length: totalPages }, (_, i) => i + 1).map(
                (page) => (
                  <Menu.Item
                    key={page}
                    active={page === activePage}
                    onClick={handlePageChange}
                  >
                    {page}
                  </Menu.Item>
                )
              )}
              <Menu.Item
                disabled={activePage === totalPages}
                onClick={() => setActivePage(activePage + 1)}
              >
                <Icon name="chevron right" />
              </Menu.Item>
            </Menu>
          </div>
        </Sidebar.Pusher>
      </Sidebar.Pushable>
      <RegisterFooter />
    </>
  );
};

export default CardList;
