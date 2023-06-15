import React, { useState, useEffect } from "react";
import axios from "axios";
import {
  Table,
  Button,
  Confirm,
  Icon,
  Message,
  Dropdown,
  Header,
} from "semantic-ui-react";
import Swal from "sweetalert2";
import withReactContent from "sweetalert2-react-content";
import ComplaintDetails from "./ComplaintDetails";
import { Bar } from "react-chartjs-2";
import "chart.js/auto";
import SearchOutlinedIcon from '@mui/icons-material/SearchOutlined';
import LoginNavbar from "../../Login Page/LoginNavbar";
import RegisterFooter from "../../Register Page/RegisterFooter";


const AdminDashboard = () => {
  const [complaints, setComplaints] = useState([]);
  const [deleteConfirmation, setDeleteConfirmation] = useState(false);
  const [selectedComplaint, setSelectedComplaint] = useState(null);
  const [showComplaintDetails, setShowComplaintDetails] = useState(false);
  const [selectedState, setSelectedState] = useState(null);
  const [selectedCity, setSelectedCity] = useState("");
  const [states, setStates] = useState([]);
  const [cities, setCities] = useState([]);
  const [addressData, setAddressData] = useState([]);
  const [loading, setLoading] = useState(true);
  const [complaintTypeData, setComplaintTypeData] = useState({});
  const [complaintSubTypeData, setComplaintSubTypeData] = useState({});
  const [complaintStatusData, setComplaintStatusData] = useState({});
  const [chartOptions, setChartOptions] = useState({});
  const MySwal = withReactContent(Swal);

  useEffect(() => {
    const fetchComplaints = async () => {
      try {
        const response = await axios.get(
          "https://localhost:5001/api/Complaints"
        );
        const data = response.data;
        console.log(response.data);

        // Fetch state information for each complaint
        const complaintsWithStateAndCity = await Promise.all(
          data.map(async (complaint) => {
            const addressId = complaint.addressId;
            const addressResponse = await axios.get(
              `https://localhost:5001/api/Address/${addressId}`
            );
            return {
              ...complaint,
              stateName: addressResponse.data.state.stateName, // Assuming the state object has a 'name' property
              cityName: addressResponse.data.city.cityName, // Assuming the city object has a 'name' property
            };
          })
        );

        // Generate complaint type data for the chart
        const complaintTypes = {};
        const complaintSubTypes = {};
        const complaintStatuses = {};
        const statusLabels = {
          0: "Filed",
          1: "In Progress",
          2: "Resolved",
        };
        
        data.forEach((complaint) => {
          const complaintType = complaint.complaintType;
          complaintTypes[complaintType] = (complaintTypes[complaintType] || 0) + 1;

          const complaintSubType = complaint.complaintSubType;
          complaintSubTypes[complaintSubType] = (complaintSubTypes[complaintSubType] || 0) + 1;
        
          const complaintStatus = complaint.complaintStatus;
          const statusLabel = statusLabels[complaintStatus];
          complaintStatuses[statusLabel] = complaintStatuses[statusLabel] + 1 || 1;
        });
        
        const chartData = {
          labels: Object.keys(complaintTypes),
          datasets: [
            {
              label: "Complaint Types",
              data: Object.values(complaintTypes),
              backgroundColor: "rgba(75, 192, 192, 0.6)",
              borderWidth: 1,
              borderColor: "rgba(75, 192, 192, 1)",
              hoverBackgroundColor: "rgba(75, 192, 192, 0.8)",
            },
          ],
        };
        
        const chartDataforSubType = {
          labels: Object.keys(complaintSubTypes),
          datasets: [
            {
              label: "Complaint SubTypes",
              data: Object.values(complaintSubTypes),
              backgroundColor: "rgba(0, 123, 255, 0.6)",
              borderWidth: 1,
              borderColor: "rgba(0, 123, 255, 1)",
              hoverBackgroundColor: "rgba(0, 123, 255, 0.8)",
            },
          ],
        };
        
        const statusChartData = {
          labels: Object.keys(complaintStatuses),
          datasets: [
            {
              label: "Complaint Status",
              data: Object.values(complaintStatuses),
              backgroundColor: "rgba(255, 99, 132, 0.6)",
              borderWidth: 1,
              borderColor: "rgba(255, 99, 132, 1)",
              hoverBackgroundColor: "rgba(255, 99, 132, 0.8)",
            },
          ],
        };
        
        const chartOptions = {
          plugins: {
            title: {
              display: true,
              text: "Complaint Analysis",
              font: {
                size: 18,
                weight: "bold",
              },
            },
            tooltip: {
              backgroundColor: "rgba(0, 0, 0, 0.8)",
              titleColor: "rgba(255, 255, 255, 1)",
              bodyColor: "rgba(255, 255, 255, 1)",
              titleFont: {
                size: 14,
                weight: "bold",
              },
              bodyFont: {
                size: 12,
              },
            },
          },
          scales: {
            x: {
              ticks: {
                color: "rgba(0, 0, 0, 0.7)",
                font: {
                  size: 12,
                },
              },
              grid: {
                color: "rgba(0, 0, 0, 0.1)",
              },
            },
            y: {
              ticks: {
                color: "rgba(0, 0, 0, 0.7)",
                font: {
                  size: 12,
                },
              },
              grid: {
                color: "rgba(0, 0, 0, 0.1)",
              },
            },
          },
        };
        
        setComplaintTypeData(chartData);
        setComplaintSubTypeData(chartDataforSubType);
        setComplaintStatusData(statusChartData);
        setChartOptions(chartOptions);
        
        

        setComplaints(complaintsWithStateAndCity);
      } catch (error) {
        console.log(error);
      }
    };

    const fetchStates = async () => {
      try {
        const response = await axios.get("https://localhost:5001/api/States");
        const data = response.data;
        setStates(data);
      } catch (error) {
        console.log(error);
      } finally {
        setLoading(false);
      }
    };

    const fetchCities = async () => {
      try {
        const response = await axios.get(`https://localhost:5001/api/Cities`);
        const data = response.data;
        setCities(data);
      } catch (error) {
        console.log(error);
      }
    };

    fetchComplaints();
    fetchStates();
    fetchCities();
  }, []);

  const handleDeleteConfirmation = (complaint) => {
    setSelectedComplaint(complaint);
    setDeleteConfirmation(true);
  };

  const handleDeleteCancel = () => {
    setSelectedComplaint(null);
    setDeleteConfirmation(false);
  };

  const handleViewComplaint = (complaint) => {
    setSelectedComplaint(complaint);
    setShowComplaintDetails(true);
  };

  const handleDeleteComplaint = async () => {
    const { id, description } = selectedComplaint;

    try {
      await axios.delete(`https://localhost:5001/api/Complaints/${id}`);
      setComplaints((prevComplaints) =>
        prevComplaints.filter((complaint) => complaint.id !== id)
      );

      MySwal.fire({
        icon: "success",
        title: "Complaint Deleted",
        text: `Complaint with ID ${id} and description "${description}" has been deleted.`,
      });
    } catch (error) {
      console.log(error);
      MySwal.fire({
        icon: "error",
        title: "Delete Error",
        text: "An error occurred while deleting the complaint. Please try again later.",
      });
    } finally {
      setSelectedComplaint(null);
      setDeleteConfirmation(false);
    }
  };

  const enumMapping = {
    0: "Filed",
    1: "In Review",
    2: "Resolved",
    3: "Feedback",
  };

  const handleEditStatus = async (id, currentStatus) => {
    const { value: newStatus } = await Swal.fire({
      title: "Edit Complaint Status",
      html: `<p>Current Status: ${enumMapping[currentStatus]}</p>`,
      input: "select",
      inputOptions: enumMapping,
      inputValue: enumMapping[currentStatus],
      showCancelButton: true,
      confirmButtonText: "Save",
      cancelButtonText: "Cancel",
    });

    if (newStatus) {
      try {
        const newStatusNumeric = parseInt(newStatus, 10);
        const newStatusText = enumMapping[newStatusNumeric];

        console.log("New Status Numeric:", newStatusNumeric);

        const formData = new URLSearchParams();
        formData.append("complaintStatus", newStatusNumeric);

        await axios.put(
          `https://localhost:5001/api/Complaints/${id}`,
          formData
        );

        setComplaints((prevComplaints) =>
          prevComplaints.map((complaint) =>
            complaint.id === id
              ? { ...complaint, complaintStatus: newStatusNumeric }
              : complaint
          )
        );

        MySwal.fire({
          icon: "success",
          title: "Complaint Status Updated",
          text: `Complaint with ID ${id} has been updated to status "${newStatusText}".`,
        });
      } catch (error) {
        console.log(error);
        MySwal.fire({
          icon: "error",
          title: "Update Error",
          text: "An error occurred while updating the complaint status. Please try again later.",
        });
      }
    }
  };

  const handleFilterByState = async (stateName) => {
    try {
      const response = await axios.get(
        `https://localhost:5001/api/Complaints/filterByState?stateName=${stateName}`
      );
      const data = response.data;
      setComplaints(data);
    } catch (error) {
      console.log(error);
    }
  };

  const handleFilterByCity = async (cityName) => {
    try {
      const response = await axios.get(
        `https://localhost:5001/api/Complaints/filterByCity?cityName=${cityName}`
      );
      const data = response.data;
      setComplaints(data);
    } catch (error) {
      console.log(error);
    }
  };

  const handleClearFilter = async () => {
    try {
      const response = await axios.get("https://localhost:5001/api/Complaints");
      const data = response.data;
      setComplaints(data);
      setSelectedState(null);
      setSelectedCity(null);
    } catch (error) {
      console.log(error);
    }
  };

  const handleFilter = () => {
    if (selectedCity) {
      handleFilterByCity(selectedCity);
    } else if (selectedState) {
      handleFilterByState(selectedState);
    } else {
      // No filter selected, show an error message or perform other actions
      alert("Please choose a filter category before clicking Filter.");
    }
  };

  return (
    <>
    <LoginNavbar />
    <div style={{backgroundColor: "#E6F7FF"}}>
      <h1 style={{ padding: "10px"}}>Admin Dashboard</h1>

      {loading ? (
        <Message info>
          <Message.Header>Loading...</Message.Header>
        </Message>
      ) : (
        <div>
          <div>
            <Dropdown
              placeholder="Filter by State"
              selection
              options={states.map((state) => ({
                key: state.stateId,
                text: state.stateName,
                value: state.stateName,
              }))}
              value={selectedState}
              onChange={(event, { value }) => {
                setSelectedState(value);
                setSelectedCity(null);
              }}
              style={{marginLeft: "5px"}}
            />
            <Dropdown
              placeholder="Filter by City"
              search
              selection
              options={cities.map((city) => ({
                key: city.cityId,
                text: city.cityName,
                value: city.cityName,
              }))}
              value={selectedCity}
              onChange={(event, { value }) => {
                setSelectedCity(value);
                setSelectedState(null);
              }}
              style={{marginLeft: "5px"}}
            />
            <Dropdown
              placeholder="Filter by Complaint Status"
              search
              selection
              style={{marginLeft: "5px"}}
            />
            <Dropdown
              placeholder={
                <div>
                  <Icon name="calendar" />
                  Filter by date
                </div>
              }
              search
              selection
              style={{marginLeft: "5px"}}
            />

            <Button color="blue" onClick={handleFilter} style={{marginLeft: "5px"}}>
              Filter
            </Button>
            <Button color="grey" style={{marginLeft: "2px"}}>
              <Icon name="map marker alternate" />
              Visualize Complaints on Map
            </Button>
            {(selectedState || selectedCity) && (
              <Button color="grey" onClick={handleClearFilter}>
                Clear Filter
              </Button>
            )}
          </div>
          {complaints.length === 0 ? (
            <Message info>
              <Message.Header>No complaints found</Message.Header>
              <p>There are no complaints available at the moment.</p>
            </Message>
          ) : (
            <>
              <Table celled striped style={{backgroundColor: "#F2F2F2"}}>
                <Table.Header>
                  <Table.Row style={{backgroundColor: "#FFFFFF"}}>
                    <Table.HeaderCell>ID</Table.HeaderCell>
                    <Table.HeaderCell>Type</Table.HeaderCell>
                    <Table.HeaderCell>Subtype</Table.HeaderCell>
                    <Table.HeaderCell>State</Table.HeaderCell>
                    <Table.HeaderCell>City</Table.HeaderCell>
                    <Table.HeaderCell>Status</Table.HeaderCell>
                    <Table.HeaderCell>Actions</Table.HeaderCell>
                  </Table.Row>
                </Table.Header>

                <Table.Body>
                  {complaints.map((complaint) => (
                    <Table.Row key={complaint.id}>
                      <Table.Cell>{complaint.id}</Table.Cell>
                      <Table.Cell>
                        {complaint.complaintType
                          .replace(/([a-z])([A-Z])/g, "$1 $2")
                          .replace(/([A-Z]+)/g, " $1")}
                      </Table.Cell>
                      <Table.Cell>
                        {complaint.complaintSubType
                          .replace(/([a-z])([A-Z])/g, "$1 $2")
                          .replace(/([A-Z]+)/g, " $1")}
                      </Table.Cell>
                      <Table.Cell>{complaint.stateName}</Table.Cell>
                      <Table.Cell>{complaint.cityName}</Table.Cell>
                      <Table.Cell>
                        {enumMapping[complaint.complaintStatus]}
                      </Table.Cell>
                      <Table.Cell>
                        <Button.Group>
                          <Button
                            color="red"
                            icon
                            onClick={() =>
                              handleDeleteConfirmation({
                                id: complaint.id,
                                description: complaint.city,
                              })
                            }
                          >
                            <Icon name="trash" />
                          </Button>
                          <Button
                            color="blue"
                            icon
                            onClick={() =>
                              handleEditStatus(
                                complaint.id,
                                complaint.complaintStatus
                              )
                            }
                          >
                            <Icon name="edit" />
                          </Button>
                          <Button
                            color="green"
                            icon
                            onClick={() => handleViewComplaint(complaint)}
                          >
                            <Icon name="eye" />
                          </Button>
                        </Button.Group>
                      </Table.Cell>
                    </Table.Row>
                  ))}
                  {/* Render ComplaintDetails component when showComplaintDetails is true */}
                  {showComplaintDetails && (
                    <ComplaintDetails
                      complaint={selectedComplaint}
                      onClose={() => setShowComplaintDetails(false)}
                    />
                  )}
                </Table.Body>
              </Table>
              <h2 style={{textAlign: "center", padding: "10px"}}>
              <img width="48" height="48" src="https://img.icons8.com/color/48/bullish.png" alt="bullish"/> Complaint Analysis
              </h2>
              <div style={{ display: 'flex' }}>
  <div style={{ marginRight: '20px' }}>
    <div style={{ width: '500px', height: '300px' }}>
      <Bar data={complaintTypeData} />
    </div>
  </div>
  <div>
    <div style={{ width: '500px', height: '300px' }}>
      <Bar data={complaintStatusData} />
    </div>
  </div>
  <div>
    <div style={{ width: '500px', height: '300px' }}>
      <Bar data={complaintSubTypeData} />
    </div>
  </div>
</div>
            </>
          )}
        </div>
      )}

      <Confirm
        open={deleteConfirmation}
        content={`Are you sure you want to delete the complaint with ID ${selectedComplaint?.id}?`}
        onCancel={handleDeleteCancel}
        onConfirm={handleDeleteComplaint}
        cancelButton="Cancel"
        confirmButton="Delete"
      />
    </div>
    <RegisterFooter />
    </>
  );
};

export default AdminDashboard;
