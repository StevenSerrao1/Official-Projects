import React, { useState } from 'react';
import axios from 'axios';

const PostTest = () => {

    // Initialize 'message' variable as empty, with 'setMessage' method to update state
    const [message, setMessage] = useState("");

    const sendData = async () =>
    {
        try {
            // Send an ASP.NET post request to PostTestEndpoint action method(Hosted through Render) with param Name: "Steven"
            const response = await axios.post("https://official-projects.onrender.com/api/test/post", { Name: "Steven" },
                {
                    headers: { "Content-Type": "application/json" }
                }
            );
            
            // The ASP.NET post request gets processed and returns an object "Greeting"
            //  the 'setMessage' method is used to update 'message' state, which is then displayed in html below
            setMessage(response.data)
        }
        catch (error) {
            console.error(error);
        }
    };

    return (
        <div>
          {/* When this button is clicked, the ASP.NET post request will be made */}
          <button onClick={sendData}>Send Data</button>
          <p>{message}</p> {/* Display the greeting message */}
        </div>
      );

}

export default PostTest;