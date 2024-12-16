import React from "react";
import { Link as RouterLink } from "react-router-dom"; // Import routing tools
import { AppBar, Toolbar, Typography, Button, Box } from "@mui/material"; // Import MUI components

function HeaderComponent() {
  return (
    <AppBar position="static" color="primary" sx={{ marginBottom: 2 }}>
      <Toolbar>
        {/* App Title or Branding */}
        <Typography variant="h6" sx={{ flexGrow: 1 }}>
          My Portfolio
        </Typography>

        {/* Navigation Links */}
        <Box>
          <Button
            component={RouterLink}
            to="/"
            color="inherit"
            sx={{ textTransform: "none" }}
          >
            About Me
          </Button>
          <Button
            href="#projects"
            color="inherit"
            sx={{ textTransform: "none" }}
          >
            Projects
          </Button>
          <Button
            component={RouterLink}
            to="/"
            color="inherit"
            sx={{ textTransform: "none" }}
          >
            Contact Me
          </Button>
        </Box>
      </Toolbar>
    </AppBar>
  );
}

export default HeaderComponent;
