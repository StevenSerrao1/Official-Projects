// FreelanceSection.js
import React from 'react';
import { Container, Typography, Button, Box } from '@mui/material';

const FreelanceSection = () => {
  return (
    <Box sx={{ padding: '50px 0'  }}>
      <Container>
        <Typography variant="h4" component="h2" gutterBottom align="center">
          Freelance Services
        </Typography>
        <Typography variant="body1" paragraph align="center">
          I offer a range of freelance services, including:
        </Typography>
        <Box sx={{ display: 'flex', justifyContent: 'center', gap: '30px', marginBottom: '30px' }}>
          <Box sx={{ textAlign: 'center' }}>
            <Typography variant="h6">Web Development</Typography>
            <Typography variant="body2">Build fast, responsive, and custom websites.</Typography>
          </Box>
          <Box sx={{ textAlign: 'center' }}>
            <Typography variant="h6">App Development</Typography>
            <Typography variant="body2">Create mobile apps for both iOS and Android.</Typography>
          </Box>
          <Box sx={{ textAlign: 'center' }}>
            <Typography variant="h6">Consulting</Typography>
            <Typography variant="body2">Offer expert advice on software solutions.</Typography>
          </Box>
        </Box>
        <Button variant="contained" color="primary" href="mailto:stevenserrao111@gmail.com" fullWidth>
          Contact Me for Projects
        </Button>
      </Container>
    </Box>
  );
};

export default FreelanceSection;
