import React from "react";
import { Typography, Box, Avatar, Container } from "@mui/material";

const AboutMe = () => {
  return (
    <Box id="about" sx={{ padding: 4, backgroundColor: "background.paper" }}>
      <Container>
        {/* Heading */}
        <Typography variant="h4" component="h2" gutterBottom>
          Welcome to my professional full-stack dev portfolio!
        </Typography>

        {/* Content Section */}
        <Box sx={{ display: "flex", flexDirection: { xs: "column", md: "row" }, alignItems: "center", gap: 4 }}>
          {/* Text Content */}
          <Box sx={{ flex: 1 }}>
            <Typography variant="body1" component="p" sx={{ marginBottom: 2 }}>
              Hey, I'm Steven! I’m primarily a backend developer who thrives on building scalable, efficient systems. My go-to tools for backend development are ASP.NET Core and React, and I’ve built countless APIs and full-stack apps focused on functionality and performance. I’m much more comfortable working with the logic and infrastructure behind an app than with the design elements on the front-end.
            </Typography>
            <Typography variant="body1" component="p" sx={{ marginBottom: 2 }}>
              While I’ve dabbled in the front-end using technologies like React and Blazor, my true passion lies in crafting solid backend architectures. On the Python side, Django is one of my favorites for quickly setting up clean and maintainable backends. I also have experience with Unity3D for game development, where I focus more on the technical side of creating interactive experiences rather than the artistic elements.
            </Typography>
            <Typography variant="body1" component="p" sx={{ marginBottom: 2 }}>
              I’m all about solving problems with robust solutions. Whether I'm working on a complex API, optimizing database queries, or improving system performance, my focus is always on creating something scalable, maintainable, and efficient. I’m constantly striving to level up my skills and stay ahead of the curve when it comes to backend technologies.
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