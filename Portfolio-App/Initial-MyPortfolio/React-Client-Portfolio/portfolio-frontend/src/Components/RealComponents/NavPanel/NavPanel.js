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

const NavPanel = ({ onSectionChange }) => {
  return (
    <StyledAppBar position="static">
      <Toolbar>
        {/* Flexbox container with 4 sections */}
        <Box sx={{ display: 'flex', width: '100%' }}>
          {/* First section */}
          <Box sx={{ flex: '1 1 25%', display: 'flex', justifyContent: 'center' }}>
            <Button color="inherit" onClick={() => onSectionChange('about')}>
              About
            </Button>
          </Box>
          {/* Second section */}
          <Box sx={{ flex: '1 1 25%', display: 'flex', justifyContent: 'center' }}>
            <Button color="inherit" onClick={() => onSectionChange('projects')}>
              Projects
            </Button>
          </Box>
          {/* Third section */}
          <Box sx={{ flex: '1 1 25%', display: 'flex', justifyContent: 'center' }}>
            <Button color="inherit" onClick={() => onSectionChange('contact')}>
              Contact
            </Button>
          </Box>
          {/* Fourth section */}
          <Box sx={{ flex: '1 1 25%', display: 'flex', justifyContent: 'center' }}>
            <Button color="inherit" onClick={() => onSectionChange('freelance')}>
              Freelance
            </Button>
          </Box>
        </Box>
      </Toolbar>
    </StyledAppBar>
  );
};

export default NavPanel;
