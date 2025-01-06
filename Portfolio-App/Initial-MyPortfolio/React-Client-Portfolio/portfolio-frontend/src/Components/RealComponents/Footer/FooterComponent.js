import React from "react";
import { Box, Typography, IconButton } from "@mui/material"; // Import MUI components
import { GitHub, LinkedIn, Instagram, Mail } from "@mui/icons-material"; // Import icons
import { useTheme } from "@mui/material/styles"; // Make sure this is imported correctly

function FooterComponent() {
  const theme = useTheme(); // Correctly use the useTheme hook to get the current theme

  return (
    <Box
      component="footer"
      sx={{
        backgroundColor: theme.palette.mode === 'dark' ? '#3C3C3C' : '#3C3C3C', // Use the theme object to apply styles conditionally
        color: theme.palette.mode === 'dark' ? 'white' : 'white', // Adjust text color based on dark mode
        padding: "20px",
        textAlign: "center",
        display: "flex",
        flexDirection: "column",
        justifyContent: "center",
        alignItems: "center",
        marginTop: "5px",
        borderTop: theme.palette.mode === 'dark' ? '5px solid #F76F00' : '6px solid cornflowerblue', // Conditional border color based on theme mode
        gap: 2,
      }}
    >
      {/* Social Media Links */}
      <Box sx={{ display: "flex", gap: 2, marginBottom: 2 }}>
        <IconButton
          component="a"
          href="https://www.linkedin.com/in/steven-serrao-0729841b1/"
          target="_blank"
          color="inherit"
        >
          <LinkedIn />
        </IconButton>
        <IconButton
          component="a"
          href="https://github.com/StevenSerrao1"
          target="_blank"
          color="inherit"
        >
          <GitHub />
        </IconButton>
        <IconButton
          component="a"
          href="https://www.instagram.com/steven_serrao"
          target="_blank"
          color="inherit"
        >
          <Instagram />
        </IconButton>
        <IconButton
          component="a"
          href="mailto:stevenserrao111@gmail.com"
          color="inherit"
        >
          <Mail />
        </IconButton>
      </Box>

      {/* Footer Text */}
      <Typography variant="body2" sx={{ marginTop: 1 }}>
        &copy; {new Date().getFullYear()} Steven Serrao | All rights reserved.
      </Typography>
    </Box>
  );
}

export default FooterComponent;
