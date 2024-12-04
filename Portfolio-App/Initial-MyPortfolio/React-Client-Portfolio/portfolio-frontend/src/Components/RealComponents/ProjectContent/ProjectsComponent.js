import React, { useState, useEffect } from 'react';
import axios from 'axios';
import ProjectsCarousel from './ProjectsCarousel';
import 'swiper/css'; // Import Swiper styles

const Projects = () => {
  const [projects, setProjects] = useState([]);

  useEffect(() => {
    // Make an Axios call to the ASP.NET Core API to fetch projects
    axios.get('http://localhost:7199/api/projects') // The backend endpoint
      .then(response => {
        setProjects(response.data); // Update the state with the received data
      })
      .catch(error => {
        console.error('There was an error fetching the projects!', error);
      });
  }, []);

  return (
    <div>
      <ProjectsCarousel projects={projects} /> {/* Pass the projects as a prop */}
    </div>
  );
};

export default Projects;
