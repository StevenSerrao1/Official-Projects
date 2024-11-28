import React, { useState, useEffect } from 'react';
import axios from 'axios';

const Projects = () => {
  const [projects, setProjects] = useState([]);

  useEffect(() => {
    // Make an Axios call to the ASP.NET Core API to fetch projects
    axios.get('http://localhost:5000/api/projects') // The backend endpoint
      .then(response => {
        setProjects(response.data); // Update the state with the received data
      })
      .catch(error => {
        console.error('There was an error fetching the projects!', error);
      });
  }, []);

  return (
    <div>
        <section id="projects">
        <h2>My Projects</h2>
            <div className="project-list">
                {projects.map(project => (
                <div key={project.id} className="project-item">
                    <img src={project.imageUrl} alt={project.title} />
                    <h3>{project.title}</h3>
                    <p>{project.description}</p>
                    <a href={project.link}>View Project</a>
                </div>
                ))}
            </div>
        </section>      
    </div>
  );
};

export default Projects;