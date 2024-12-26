import React from "react";
import { AppBar, Toolbar, Typography, Button, Box, IconButton } from "@mui/material"; // Import MUI components
import { GitHub, LinkedIn, Instagram, Mail } from "@mui/icons-material"; // Import icons
import ToggleThemeButton from "./ToggleThemeButton";

const HeaderComponent = ({ darkMode, setDarkMode }) => {
  return (
    <AppBar position="static" color="primary" sx={{ marginBottom: 2 }}>
      <Toolbar sx={{ display: "flex", alignItems: "center", justifyContent: "space-between" }}>
        {/* Left Section: App Title or Branding */}
        <Typography variant="h6" sx={{ flex: "0 1 auto" }}>
          Steven Serrao's Dev Portfolio
        </Typography>

        {/* Theme Toggle Button */}
        <ToggleThemeButton toggleTheme={() => setDarkMode(!darkMode)} darkMode={darkMode} setDarkMode={setDarkMode} />

        {/* Middle Section: Social Media & Email Links */}
        <Box sx={{ display: "flex", alignItems: "center", gap: 2, flex: 1, justifyContent: "center" }}>
          <IconButton component="a" href="https://www.linkedin.com/in/steven-serrao-0729841b1/" target="_blank" color="inherit">
            <LinkedIn />
          </IconButton>
          <IconButton component="a" href="https://github.com/StevenSerrao1" target="_blank" color="inherit">
            <GitHub />
          </IconButton>
          <IconButton component="a" href="https://www.instagram.com/steven_serrao" target="_blank" color="inherit">
            <Instagram />
          </IconButton>
          <IconButton component="a" href="mailto:stevenserrao111@gmail.com" color="inherit">
            <Mail />
          </IconButton>
        </Box>

        {/* Right Section: Navigation Links */}
        <Box sx={{ flex: "0 1 auto", display: "flex", gap: 1 }}>
          <Button href="#about" color="inherit" sx={{ textTransform: "none", border: "2px solid rgba(255, 255, 255, 0.3)", borderRadius: "20px", padding: "6px 20px" }}>
            About Me
          </Button>
          <Button href="#projects" color="inherit" sx={{ textTransform: "none", border: "2px solid rgba(255, 255, 255, 0.3)", borderRadius: "20px", padding: "6px 20px" }}>
            Projects
          </Button>
          <Button href="#contact" color="inherit" sx={{ textTransform: "none", border: "2px solid rgba(255, 255, 255, 0.3)", borderRadius: "20px", padding: "6px 20px" }}>
            Contact Me
          </Button>
          <Button href="https://StevenSerrao1.github.io/Official-Projects/assets/resume.pdf" target="_blank" rel="noopener noreferrer" download="resume.pdf" color="inherit" sx={{ textTransform: "none", border: "2px solid rgba(255, 255, 255, 0.3)", borderRadius: "20px", padding: "6px 20px" }}>
            My CV
          </Button>
        </Box>
      </Toolbar>
    </AppBar>
  );
};

export default HeaderComponent;
