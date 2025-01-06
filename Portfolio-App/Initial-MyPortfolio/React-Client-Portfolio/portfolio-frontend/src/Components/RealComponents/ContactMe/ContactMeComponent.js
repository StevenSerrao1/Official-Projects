import React, { useState } from "react";
import {
  Box,
  Button,
  TextField,
  Typography,
  Container,
  Paper,
} from "@mui/material";

const ContactMe = () => {
  const [formData, setFormData] = useState({
    name: "",
    email: "",
    message: "",
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({
      ...formData,
      [name]: value,
    });
  };

  const handleSubmit = async (e) => {
    e.preventDefault(); // Prevent page refresh

    try {
      const response = await fetch(
        "https://official-projects.onrender.com/api/projects/contactform",
        {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify(formData), // Send the form data
        }
      );

      if (response.ok) {
        alert("Message sent successfully!");
        setFormData({ name: "", email: "", message: "" }); // Reset form
      } else {
        alert("Failed to send message.");
      }
    } catch (err) {
      console.error("Error occurred:", err);
      alert("An error occurred while sending your message.");
    }
  };

  return (
    <div>
      <Container id="contact" maxWidth="sm" sx={{ marginTop: 5, marginBottom: 5 }}>
      <Paper elevation={3} sx={{ padding: 3 }}>
        <Typography variant="h4" component="h2" gutterBottom>
          Contact Me
        </Typography>
        <form onSubmit={handleSubmit}>
          <Box sx={{ marginBottom: 2 }}>
            <TextField
              label="Name"
              variant="outlined"
              fullWidth
              name="name"
              value={formData.name}
              onChange={handleChange}
              required
            />
          </Box>
          <Box sx={{ marginBottom: 2 }}>
            <TextField
              label="Email"
              variant="outlined"
              type="email"
              fullWidth
              name="email"
              value={formData.email}
              onChange={handleChange}
              required
            />
          </Box>
          <Box sx={{ marginBottom: 2 }}>
            <TextField
              label="Message"
              variant="outlined"
              fullWidth
              multiline
              rows={5}
              name="message"
              value={formData.message}
              onChange={handleChange}
              required
            />
          </Box>
          <Button type="submit" variant="contained" color="primary" fullWidth>
            Send Message
          </Button>
        </form>
      </Paper>
    </Container>
    </div> 
  );
};

export default ContactMe;
