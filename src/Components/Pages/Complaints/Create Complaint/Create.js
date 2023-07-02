import React, { useState, useEffect } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import { Form, Button, Dropdown, Header } from "semantic-ui-react";
import LoginNavbar from "../../Login Page/LoginNavbar";
import RegisterFooter from "../../Register Page/RegisterFooter";
import Swal from "sweetalert2";

const ComplaintForm = () => {
  const [formData, setFormData] = useState({
    complaintType: "",
    complaintSubType: "",
    description: "",
    complainantName: "",
    phoneNumber: "",
    email: "",
    pincode: "",
    selectedState: "",
    selectedCity: "",
    complaintLocationWardNo: "",
    complaintLocationArea: "",
    complaintLocationLandmark: "",
    complainantLocationWardNo: "",
    complainantLocationHouseNo: "",
    complainantLocationHouseName: "",
    complainantLocationLandmark: "",
    complainantLocationArea: "",
  });

  const [photo, setPhoto] = useState(null);
  const [states, setStates] = useState([]);
  const [cities, setCities] = useState([]);
  const navigate = useNavigate();

  useEffect(() => {
    const fetchCitiesStates = async () => {
      try {
        const response = await axios.get(
          "https://localhost:5001/api/CitiesStates"
        );
        const data = response.data;
        console.log(response.data);

        const stateOptions = data.map((state) => ({
          key: state.id,
          value: state.id,
          text: state.name,
        }));

        setStates(stateOptions);
      } catch (error) {
        console.log(error);
      }
    };

    fetchCitiesStates();
  }, []);

  const handleChange = (e, { name, value }) => {
    setFormData({ ...formData, [name]: value });
  };

  const handleFileChange = (e) => {
    setPhoto(e.target.files[0]);
  };

  const handleStateChange = (e, { value }) => {
    const selectedState = states.find((state) => state.value === value);
    console.log(selectedState);

    if (selectedState) {
      setFormData((prevState) => ({
        ...prevState,
        selectedState: {
          id: selectedState.value,
        },
        selectedCity: null, // Clear the selected city when changing the state
      }));

      const fetchCities = async (stateId) => {
        try {
          const response = await axios.get(
            `https://localhost:5001/api/CitiesStates/${stateId}/Cities`
          );
          const data = response.data;
          setCities(data);

          // Check if there are cities available for the selected state
          if (data.length > 0) {
            setFormData((prevState) => ({
              ...prevState,
              selectedCity: data[0],
            }));
          }
        } catch (error) {
          console.log(error);
        }
      };

      fetchCities(selectedState.value);
    }
  };

  const handleSubmit = async () => {
    try {
      // Create form data and append all fields
      const form = new FormData();
      form.append("complaintType", formData.complaintType);
      form.append("complaintSubType", formData.complaintSubType);
      form.append("description", formData.description);
      form.append("complainantName", formData.complainantName);
      form.append("complaintLocationWardNo", formData.complaintLocationWardNo);
      form.append("complaintLocationArea", formData.complaintLocationArea);
      form.append(
        "complaintLocationLandmark",
        formData.complaintLocationLandmark
      );
      form.append("complainantLocationWardNo", formData.complainantLocationWardNo);
      form.append("complainantLocationHouseNo", formData.complainantLocationHouseNo);
      form.append(
        "complainantLocationHouseName",
        formData.complainantLocationHouseName
      );
      form.append(
        "complainantLocationLandmark",
        formData.complainantLocationLandmark
      );
      form.append("complainantLocationArea", formData.complainantLocationArea);
      form.append("pincode", formData.pincode);
      form.append("phoneNumber", formData.phoneNumber);
      form.append("selectedState", formData.selectedState.id);
      form.append("selectedCity", formData.selectedCity.id);

      form.append("email", formData.email);
      form.append("PictureUrl", photo);

      console.log("Selected State:", formData.selectedState);
      console.log("Selected City:", formData.selectedCity);

      const response = await axios.post(
        "https://localhost:5001/api/Complaints",
        form,
        {
          headers: {
            "Content-Type": "multipart/form-data",
        //  'Content-Type': 'application/json'
          },
        }
      );

      console.log(response.data);
      Swal.fire({
        icon: "success",
        title: "Complaint Submitted",
        text: `Complaint with ID ${response.data.id} has been submitted successfully.`,
      }).then(() => {
        navigate("/");
      });
    } catch (error) {
      console.log(error);
    }
  };

  const complaintTypeOptions = [
    {
      key: "garbageAndWasteManagement",
      value: "GarbageAndWasteManagement",
      text: "Garbage and Waste Management",
    },
    { key: "streetCleaning", value: "StreetCleaning", text: "Street Cleaning" },
    {
      key: "publicToiletsAndSanitation",
      value: "PublicToiletsAndSanitation",
      text: "Public Toilets and Sanitation",
    },
    {
      key: "drainageAndSewage",
      value: "DrainageAndSewage",
      text: "Drainage and Sewage",
    },
    {
      key: "publicParksAndRecreationalAreas",
      value: "PublicParksAndRecreationalAreas",
      text: "Public Parks and Recreational areas",
    },
    { key: "pestControl", value: "PestControl", text: "Pest Control" },
  ];

  const complaintSubTypeOptions = [
    {
      key: "improperGarbageDisposal",
      value: "ImproperGarbageDisposal",
      text: "Improper Garbage Disposal",
    },
    {
      key: "overflowingGarbageBins",
      value: "OverflowingGarbageBins",
      text: "Overflowing Garbage Bins",
    },
    {
      key: "dumpingOfWasteInPublicAreas",
      value: "DumpingOfWasteInPublicAreas",
      text: "Dumping of Waste in Public areas",
    },
    {
      key: "lackOfWasteSegregation",
      value: "LackOfWasteSegregation",
      text: "Lack of Waste Segregation",
    },
    {
      key: "litteredStreetsAndSidewalks",
      value: "LitteredStreetsAndSidewalks",
      text: "Littered Streets and Sidewalks",
    },
    {
      key: "accumulationOfLeavesAndDebris",
      value: "AccumulationOfLeavesAndDebris",
      text: "Accumulation of Leaves and Debris",
    },
    {
      key: "uncleanAndDirtyPublicSpaces",
      value: "UncleanAndDirtyPublicSpaces",
      text: "Unclean and Dirty Public Spaces",
    },
    {
      key: "lackOfCleanAndAccessiblePublicToilets",
      value: "LackOfCleanAndAccessiblePublicToilets",
      text: "Lack of Clean and accessible Public Toilets",
    },
    {
      key: "poorMaintenanceOfExistingToilets",
      value: "PoorMaintenanceOfExistingToilets",
      text: "Poor Maintenance of Existing Toilets",
    },
    {
      key: "insufficientSanitationFacilitiesInPublicAreas",
      value: "InsufficientSanitationFacilitiesInPublicAreas",
      text: "Insufficient Sanitation Facilities in Public areas",
    },
    {
      key: "cloggedDrainsAndSewers",
      value: "CloggedDrainsAndSewers",
      text: "Clogged Drains and Sewers",
    },
    {
      key: "overflowingSewageLines",
      value: "OverflowingSewageLines",
      text: "Overflowing Sewage Lines",
    },
    {
      key: "foulOdorFromDrainageSystems",
      value: "FoulOdorFromDrainageSystems",
      text: "FoulOdorFromDrainageSystems",
    },
    {
      key: "uncleanAndLitteredParks",
      value: "UncleanAndLitteredParks",
      text: "Unclean and Littered Parks",
    },
    {
      key: "inadequateMaintenanceOfPlaygroundsAndEquipment",
      value: "InadequateMaintenanceOfPlaygroundsAndEquipment",
      text: "Inadequate Maintenance of Playgrounds and Equipment",
    },
    {
      key: "lackOfCleanlinessInRecreationalAreas",
      value: "LackOfCleanlinessInRecreationalAreas",
      text: "Lack of Cleanliness in Recreational areas",
    },
    {
      key: "infestationOfInsectsOrRodentsInPublicAreas",
      value: "InfestationOfInsectsOrRodentsInPublicAreas",
      text: "Infestation of Insects or Rodents in Public areas",
    },
  ];

  return (
    <>
      <LoginNavbar />
      <Header as="h2" textAlign="center">
        Application for Complaint / Grievance
      </Header>
      <Form onSubmit={handleSubmit}>
        <Form.Select
          label="Complaint Type"
          name="complaintType"
          value={formData.complaintType}
          options={complaintTypeOptions}
          onChange={handleChange}
        />
        <Form.Select
          label="Complaint SubType"
          name="complaintSubType"
          value={formData.complaintSubType}
          options={complaintSubTypeOptions}
          onChange={handleChange}
        />
        <Form.TextArea
          label="Description"
          name="description"
          value={formData.description}
          onChange={handleChange}
        />
        <Form.Input
          label="Complaint Location Area"
          name="complaintLocationArea"
          value={formData.complaintLocationArea}
          onChange={handleChange}
        />
        <Form.Input
          label="Complaint Landmark"
          name="complaintLocationLandmark"
          value={formData.complaintLocationLandmark}
          onChange={handleChange}
        />
        <Form.Input
          label="Complaint Location Ward No"
          name="complaintLocationWardNo"
          value={formData.complaintLocationWardNo}
          onChange={handleChange}
        />
        <Form.Input
          label="Complainant Name"
          name="complainantName"
          value={formData.complainantName}
          onChange={handleChange}
        />
        <Form.Input
          label="Complainant Ward No"
          name="complainantLocationWardNo"
          value={formData.complainantLocationWardNo}
          onChange={handleChange}
        />
        <Form.Input
          label="Complainant House No"
          name="complainantLocationHouseNo"
          value={formData.complainantLocationHouseNo}
          onChange={handleChange}
        />
        <Form.Input
          label="Complainant House Name"
          name="complainantLocationHouseName"
          value={formData.complainantLocationHouseName}
          onChange={handleChange}
        />

        <Form.Input
          label="Complainant Landmark"
          name="complainantLocationLandmark"
          value={formData.complainantLocationLandmark}
          onChange={handleChange}
        />

        <Form.Input
          label="Complainant Area"
          name="complainantLocationArea"
          value={formData.complainantLocationArea}
          onChange={handleChange}
        />
        <Form.Input
          label="Complaint Location Pincode"
          name="pincode"
          value={formData.pincode}
          onChange={handleChange}
        />
        <Form.Input
          label="Phone Number"
          name="phoneNumber"
          value={formData.phoneNumber}
          onChange={handleChange}
        />
        <Form.Input
          label="Email"
          name="email"
          value={formData.email}
          onChange={handleChange}
        />
        <Form.Field>
          <label>State</label>
          <Dropdown
            placeholder="Select State"
            fluid
            selection
            options={states}
            onChange={handleStateChange}
          />
        </Form.Field>
        <Form.Field>
          <label>City</label>
          <Dropdown
            placeholder="Select City"
            fluid
            selection
            options={cities.map((city) => ({
              key: city.id,
              value: city.id,
              text: city.cityName,
            }))}
            onChange={(e, { value }) => {
              const selectedCity = cities.find((city) => city.id === value);
              setFormData((prevState) => ({
                ...prevState,
                selectedCity: {
                  id: selectedCity.id,
                  name: selectedCity.cityName,
                },
              }));
            }}
          />
        </Form.Field>
        <Form.Field>
          <label>Upload Photo</label>
          <input type="file" accept="image/*" onChange={handleFileChange} />
        </Form.Field>
        <Button primary type="submit">
          Submit
        </Button>
      </Form>
      <RegisterFooter />
    </>
  );
};

export default ComplaintForm;
