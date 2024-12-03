import React, { useEffect, useState } from "react";
import axios from "axios";

function GetTest() {
  // Currently just here for test purposes
  const [message, setMessage] = useState("");

  useEffect(() => {
    axios.get("https://official-projects.onrender.com/api/test/get")
      .then((response) => setMessage(response.data))
      .catch((error) => console.error(error));
  }, []);

  return (
    <div>
      <h1>React + ASP.NET Core Integration</h1>
      <p>{message}</p>
    </div>
  );
}

export default GetTest;
