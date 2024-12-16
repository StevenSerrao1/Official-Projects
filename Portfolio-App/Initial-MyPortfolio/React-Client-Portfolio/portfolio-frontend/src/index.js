import React from "react";
import ReactDOM from "react-dom/client";
import { BrowserRouter as Router } from "react-router-dom"; // To enable routing between links on CLIENT side
import { ThemeProvider, createTheme } from "@mui/material/styles"; // Import ThemeProvider and createTheme
import CssBaseline from "@mui/material/CssBaseline"; // Optional for resetting CSS to match Material Design standards
import App from "./App"; // Import App.js as the root component

// Define a custom theme (you can customize colors, typography, etc.)
const theme = createTheme({
  palette: {
    primary: {
      main: "#1976d2", // Default MUI blue
    },
    secondary: {
      main: "#dc004e", // Default MUI pink
    },
  },
});

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
  <React.StrictMode>
    <ThemeProvider theme={theme}>
      <CssBaseline /> {/* Optional: Normalizes CSS */}
      <Router>
        <App />
      </Router>
    </ThemeProvider>
  </React.StrictMode>
);
