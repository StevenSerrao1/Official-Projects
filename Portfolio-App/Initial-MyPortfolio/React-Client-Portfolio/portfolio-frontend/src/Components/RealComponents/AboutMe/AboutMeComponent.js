import React from "react";
import { Typography, Box, Avatar, Container } from "@mui/material";

const AboutMe = () => {
  return (
    <Box id="about" sx={{ padding: 4, backgroundColor: "background.paper" }}>
      <Container>
        {/* Heading */}
        <Typography variant="h4" component="h2" gutterBottom>
          About Me
        </Typography>

        {/* Content Section */}
        <Box sx={{ display: "flex", flexDirection: { xs: "column", md: "row" }, alignItems: "center", gap: 4 }}>
          {/* Text Content */}
          <Box sx={{ flex: 1 }}>
            <Typography variant="body1" component="p" sx={{ marginBottom: 2 }}>
              Hi, I'm Steven! I'm passionate about backend development and building scalable, efficient web applications.
              I specialize in technologies like ASP.NET Core and React, and I love working on both front-end and back-end projects.
            </Typography>
            <Typography variant="body1" component="p" sx={{ marginBottom: 2 }}>
              When I'm not coding, you can find me listening to music, playing basketball, or experimenting with new recipes in the kitchen.
            </Typography>
          </Box>

          {/* Avatar Section */}
          <Avatar
            src="https://via.placeholder.com/150" // Replace with your image URL
            alt="Steven's Avatar"
            sx={{ width: 150, height: 150, flexShrink: 0 }}
          />
        </Box>
      </Container>
    </Box>
  );
};

export default AboutMe;