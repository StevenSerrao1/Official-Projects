import React from "react";
import { IconButton } from "@mui/material";
import { Brightness4, Brightness7 } from "@mui/icons-material"; // Import MUI icons

function ToggleThemeButton({ toggleTheme, darkMode }) {
  return (
    <IconButton onClick={toggleTheme} color="inherit">
      {darkMode ? <Brightness7 /> : <Brightness4 />} {/* Toggle between sun and moon icons */}
    </IconButton>
  );
}

export default ToggleThemeButton;
