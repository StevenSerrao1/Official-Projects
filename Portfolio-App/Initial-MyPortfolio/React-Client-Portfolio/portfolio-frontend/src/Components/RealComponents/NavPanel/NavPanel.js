import React from 'react';
import { AppBar, Toolbar, Typography, Button, Box } from '@mui/material';
import { styled } from '@mui/system';
import { useTheme } from '@mui/material/styles';

// Styled AppBar for a custom background color based on theme mode
const StyledAppBar = styled(AppBar)(({ theme }) => ({
  backgroundColor: theme.palette.mode === 'dark' ? '#3C3C3C' : '#3C3C3C', // Dark background for dark mode, light for light mode
  borderBottom: theme.palette.mode === 'dark' ? '5px solid #F76F00' : '5px solid cornflowerblue',
  borderTop: theme.palette.mode === 'dark' ? '5px solid #F76F00' : '5px solid cornflowerblue',
}));

const NavPanel = ({ onSectionChange, onActiveSection }) => {

  const theme = useTheme(); // Get the theme object using the useTheme hook

  // Function to generate button styles dynamically based on active section and theme mode
  const getButtonStyles = (section) => {
    const isActive = onActiveSection === section;
    return {
      backgroundColor: isActive
        ? (theme.palette.mode === 'dark' ? '#555' : '#3C3C3C') // Dark mode vs light mode
        : 'transparent',
      fontWeight: isActive ? 'bold' : 'normal',
      borderRadius: '8px',
      border: isActive
        ? (theme.palette.mode === 'dark' ? '3px solid #F76F00' : '3px solid cornflowerblue') // Border color change based on active section and theme
        : 'none',
      padding: '10px 20px',
      transition: 'all 0.3s ease',
    };
  };

  return (
    <StyledAppBar position="static">
      <Toolbar>
        {/* Flexbox container with 4 sections */}
        <Box sx={{ display: 'flex', width: '100%' }}>
          {/* First section */}
          <Box sx={{ flex: '1 1 25%', display: 'flex', justifyContent: 'center' }}>
            <Button
            color="inherit"
            onClick={() => onSectionChange('about')}
            style={getButtonStyles('about')} // Apply the dynamic styles
            onMouseEnter={(e) => {

              e.target.style.backgroundColor = theme.palette.mode === 'dark' ? '#3C3C3C' : '#555';
            }}
            onMouseLeave={(e) => {
              e.target.style.backgroundColor = theme.palette.mode === 'dark' ? 'rgb(70, 80, 80)' : '#3C3C3C';
            }}
            >
             About
            </Button>
          </Box>

          {/* Second section */}
          <Box sx={{ flex: '1 1 25%', display: 'flex', justifyContent: 'center' }}>
            <Button
            color="inherit"
            onClick={() => onSectionChange('projects')}
            style={getButtonStyles('projects')} // Apply the dynamic styles
            onMouseEnter={(e) => {

              e.target.style.backgroundColor = theme.palette.mode === 'dark' ? '#3C3C3C' : '#555';
            }}
            onMouseLeave={(e) => {
              e.target.style.backgroundColor = theme.palette.mode === 'dark' ? 'rgb(70, 80, 80)' : '#3C3C3C';
            }}
            >
             My Projects
            </Button>
          </Box>
          {/* Third section */}
          <Box sx={{ flex: '1 1 25%', display: 'flex', justifyContent: 'center' }}>
            <Button
            color="inherit"
            onClick={() => onSectionChange('contact')}
            style={getButtonStyles('contact')} // Apply the dynamic styles
            onMouseEnter={(e) => {

              e.target.style.backgroundColor = theme.palette.mode === 'dark' ? '#3C3C3C' : '#555';
            }}
            onMouseLeave={(e) => {
              e.target.style.backgroundColor = theme.palette.mode === 'dark' ? 'rgb(70, 80, 80)' : '#3C3C3C';
            }}
            >
             Contact Me
            </Button>
          </Box>
          {/* Fourth section */}
          <Box sx={{ flex: '1 1 25%', display: 'flex', justifyContent: 'center' }}>
            <Button
            color="inherit"
            onClick={() => onSectionChange('freelance')}
            style={getButtonStyles('freelance')} // Apply the dynamic styles
            onMouseEnter={(e) => {

              e.target.style.backgroundColor = theme.palette.mode === 'dark' ? '#3C3C3C' : '#555';
            }}
            onMouseLeave={(e) => {
              e.target.style.backgroundColor = theme.palette.mode === 'dark' ? 'rgb(70, 80, 80)' : '#3C3C3C';
            }}
            >
             Freelancing
            </Button>
          </Box>
        </Box>
      </Toolbar>
    </StyledAppBar>
  );
};

export default NavPanel;
