import React, { useState, useEffect } from 'react';
import axios from 'axios';
import ProjectsCarousel from './ProjectsCarousel';
import PropTypes from 'prop-types';
import 'swiper/css'; // Import Swiper styles
import { Paper, CircularProgress, Box } from '@mui/material';

const Projects = () => {
  const [projects, setProjects] = useState([]);
  const [loading, setLoading] = useState(true); // Loading state

  Projects.propTypes = {
    projects: PropTypes.arrayOf(
      PropTypes.shape({
        Title: PropTypes.string.isRequired, // corresponds to Title in the model
        ShortDescription: PropTypes.string, // corresponds to ShortDescription
        FullDescription: PropTypes.string, // corresponds to FullDescription
        ProjectURL: PropTypes.string.isRequired, // corresponds to ProjectURL
        DateCreatedFormatted: PropTypes.string.isRequired, // corresponds to DateCreatedFormatted
        GitHubViews: PropTypes.string, // corresponds to GitHubViews
        Images: PropTypes.arrayOf(
          PropTypes.shape({
            ImageUrl: PropTypes.string.isRequired, // corresponds to ImageUrl
            Caption: PropTypes.string, // corresponds to Caption
            AltText: PropTypes.string.isRequired // corresponds to AltText
          })
        ).isRequired
      })
    ).isRequired
  };

  useEffect(() => {
    // Make an Axios call to the ASP.NET Core API to fetch projects
    axios.get('https://official-projects.onrender.com/api/projects/loadprojects') // The PRODUCTION backend endpoint
     //axios.get('http://127.0.0.1/api/projects/loadprojects') // The DEVELOPMENT backend endpoint
      .then(response => {
        setProjects(response.data); // Update the state with the received data
        setLoading(false); // Data is loaded, update loading state to false
      })
      .catch(error => {
        console.error('There was an error fetching the projects!', error);
        setLoading(false); // In case of error, set loading to false
      });
  }, []);

  return (
    <div>
      {loading ? (
        // Display CircularProgress or a Loading Indicator
        <Box sx={{ display: 'flex', justifyContent: 'center', alignItems: 'center', height: '100vh' }}>
          <CircularProgress />
        </Box>
      ) : (
        // Once loading is false, display ProjectsCarousel
        <Paper elevation={3}>
          <ProjectsCarousel projects={projects} /> {/* Pass the projects as a prop */}
        </Paper>
      )}
    </div>
  );
};

export default Projects;
