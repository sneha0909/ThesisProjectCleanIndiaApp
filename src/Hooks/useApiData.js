import { useState, useEffect } from 'react';
import axios from 'axios';

const useApiData = (url) => {
  const [data, setData] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await axios.get(url);
        setData(response.data);
      } catch (error) {
        console.log(error);
      }
    };
    fetchData();
  }, [url]);

  return data;
};

export default useApiData;