import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { Header, List } from 'semantic-ui-react';

import axios from 'axios';

const Details = () => {
    const { empid } = useParams();
    const [complaints, setComplaints] = useState({})
    useEffect(() => {
        fetch('http://localhost:5000/api/complaints' + empid).then((res) => {
            return res.json();
        }).then((res) => {
            setComplaints(res);
        }).catch((err) => {
            console.log(err.message);
        })

    }, []);
    return (
        <div>

            {
                complaints &&
                <h1>Complainant : ({complaints.email})</h1>
            }
        </div>
    );

}

export default Details;