import React from "react";
import { Link as RouterLink } from "react-router-dom"; // Import routing tools
import { AppBar, Toolbar, Typography, Button, Box, IconButton } from "@mui/material"; // Import MUI components
import { GitHub, LinkedIn, Instagram, Mail } from "@mui/icons-material"; // Import icons

function HeaderComponent() {
  return (
    <AppBar position="static" color="primary" sx={{ marginBottom: 2 }}>
      <Toolbar sx={{ display: "flex", alignItems: "center" }}>
        {/* Left Section: App Title or Branding */}
        <Typography variant="h6" sx={{ flex: "0 1 auto" }}>
          Steven Serrao's Dev Portfolio
        </Typography>

        {/* Middle Section: Social Media & Email Links */}
        <Box
          sx={{
            display: "flex",
            alignItems: "center",
            gap: 2,
            flex: 1,
            justifyContent: "center",
            marginLeft: "75px",  // Slight adjustment to center
          }}
        >
          <IconButton
            component="a"
            href="https://www.linkedin.com/in/steven-serrao-0729841b1/"
            target="_blank"
            color="inherit"
            sx={{ textTransform: "none" }}
          >
            <LinkedIn />
          </IconButton>
          <IconButton
            component="a"
            href="https://github.com/StevenSerrao1"
            target="_blank"
            color="inherit"
            sx={{ textTransform: "none" }}
          >
            <GitHub />
          </IconButton>
          <IconButton
            component="a"
            href="https://www.instagram.com/steven_serrao"
            target="_blank"
            color="inherit"
            sx={{ textTransform: "none" }}
          >
            <Instagram />
          </IconButton>
          <IconButton
            component="a"
            href="mailto:stevenserrao111@gmail.com"
            color="inherit"
            sx={{ textTransform: "none" }}
          >
            <Mail />
          </IconButton>
        </Box>

        {/* Right Section: Navigation Links */}
        <Box sx={{ flex: "0 1 auto", display: "flex", gap: 1 }}>
          <Button
            href="#about"
            color="inherit"
            sx={{
              textTransform: "none",
              border: "2px solid rgba(255, 255, 255, 0.3)", // Thin white border around the button
              borderRadius: "20px", // Round the corners to make it a capsule
              padding: "6px 20px", // Add padding for a good capsule size
              display: "inline-flex", // Ensure proper alignment
              alignItems: "center", // Center the text inside the button
            }}
          >
            About Me
          </Button>
          <Button
            href="#projects"
            color="inherit"
            sx={{
              textTransform: "none",
              border: "2px solid rgba(255, 255, 255, 0.3)", // Thin white border around the button
              borderRadius: "20px", // Round the corners to make it a capsule
              padding: "6px 20px", // Add padding for a good capsule size
              display: "inline-flex", // Ensure proper alignment
              alignItems: "center", // Center the text inside the button
            }}
          >
            Projects
          </Button>
          <Button
            href="#contact"
            color="inherit"
            sx={{
              textTransform: "none",
              border: "2px solid rgba(255, 255, 255, 0.3)", // Thin white border around the button
              borderRadius: "20px", // Round the corners to make it a capsule
              padding: "6px 20px", // Add padding for a good capsule size
              display: "inline-flex", // Ensure proper alignment
              alignItems: "center", // Center the text inside the button
            }}
          >
            Contact Me
          </Button>
        </Box>


      </Toolbar>
    </AppBar>
  );
}

export default HeaderComponent;
