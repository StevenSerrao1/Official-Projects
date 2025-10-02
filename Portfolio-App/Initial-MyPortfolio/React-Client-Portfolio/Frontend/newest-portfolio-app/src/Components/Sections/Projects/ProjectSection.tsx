import React, { useState, useEffect } from "react";
import axios from "axios";
import { Project } from "./types/interfaces";
import "../../../styles/card-styling.css";
import "../../../Assets/Fonts/LemonMilkRegularFont.css";
import CarouselComponent from "../../Helper Components/Carousel/CarouselComponent";

const ProjectSection: React.FC = () => {
  // Hold all fetched projects
  const [projects, setProjects] = useState<Project[]>([]);
  // Single Project hold for modal
  const [project, setProject] = useState<Project | null>(null);
  // Track loading state while fetching data
  const [loading, setLoading] = useState(true);
  // Add modal display state
  const [open, setOpen] = useState(false);

  useEffect(() => {
    // Fetch project data from API
    // Swap between local and production endpoints when needed
    axios
      //.get("http://localhost:5000/api/projects/loadprojects") // Dev endpoint
      .get("https://official-projects.onrender.com/api/projects/loadprojects") // Production endpoint
      .then((res) => {
        // Store response in state
        setProjects(res.data);
        // Disable loading spinner
        setLoading(false);
      })
      .catch(() => {
        // Handle failure by disabling spinner
        setLoading(false);
      });
  }, []);

  // Show loading state until projects are fetched
  if (loading) {
    return (
      <div className="container-fluid my-4">
        <div className="border border-3 border-warning p-0">
          {/* Render section heading */}
          <h2 className="fs-4 dark-bg-heading text-center lm-reg-font pt-4 pb-4 mb-0">
            <i className="fs-4 me-4 bi-code"></i>
            MY PERSONAL PROJECTS
            <i className="fs-4 ms-4 bi-code"></i>
          </h2>
        </div>
        {/* Render loading spinner */}
        <div className="d-flex justify-content-center my-5">
          <div className="spinner-border text-info" role="status">
            <span className="visually-hidden">Loading…</span>
          </div>
            <span className="text-light ms-2">* Long wait times are due to Render instance spinning down with inactivity; 
               can delay project fetch times by 50 seconds or more
            </span>
        </div>
      </div>
    );
  }

  // Render list of projects once data has loaded
  return (
    <div className="container-fluid my-4">
      <div className="border border-3 border-warning p-0">
        {/* Render section heading */}
        <h2 className="fs-4 dark-bg-heading text-center lm-reg-font pt-4 pb-4 mb-0">
          <i className="fs-4 me-4 bi-code"></i>
          MY PERSONAL PROJECTS
          <i className="fs-4 ms-4 bi-code"></i>
        </h2>
      </div>

      <div className="border border-warning border-3 shadow p-4 bg-dark">
        <div className="container py-3">
          <div className="row g-4">
            {/* Loop over all projects and render them */}
            {projects.map((p) => (
              <div
                key={p.images[0].projectId}
                className="col-12 col-sm-6 col-md-4"
              >
                <div className="card h-100 border-warning border-2 hover-lift bg-dark">
                  {/* Render project image if available */}
                  {p.images?.[0] && (
                    <img
                      src={p.images[0].imageUrl}
                      alt={p.images[0].altText}
                      className="card-img-top"
                      style={{ height: "160px", objectFit: "cover" }}
                    />
                  )}

                  {/* Render project details */}
                  <div className="card-body d-flex flex-column">
                    {/* Render project title */}
                    <h5 className="card-title border-bottom border-3 border-warning lato-p fs-4 text-light text-center">
                      {p.title}
                    </h5>

                    {/* Render project description */}
                    <p className="card-text flex-grow-1 lato-p text-light">
                      {p.shortDescription}
                    </p>

                    {/* Render GitHub views if available */}
                    <p className="lato-caption text-light">
                      Github Views: {p.gitHubViews}
                    </p>

                    {/* Render external project link */}
                    <a
                      href={p.projectURL}
                      target="_blank"
                      rel="noopener noreferrer"
                      className="btn btn-sm btn-warning mt-auto send-button"
                    >
                      View Project! <i className="bi bi-box-arrow-up-right"></i>
                    </a>

                    {/* Render GitHub repo link */}
                    <a
                      href={"https://github.com/StevenSerrao1/" + p.gitHubRepoName}
                      target="_blank"
                      rel="noopener noreferrer"
                      className="btn btn-sm btn-warning mt-2 send-button"
                    >
                      View Source Code! <i className="bi bi-box-arrow-up-right"></i>

                    </a>

                    {/* Render overlay modal for project details */}
                    <a
                      onClick={() => [setOpen(true), setProject(p)]}
                      target="_blank"
                      rel="noopener noreferrer"
                      className="btn btn-sm btn-warning mt-2 send-button"
                    >
                      Read More!
                    </a>
                    {open && project && (
                      <div className="modal-overlay"> {/*Close modal by clicking anywhere*/}
                      
                        <div className="modal-content2">
                          <div>
                            <p className="modal-text">{project.fullDescription}</p>
                          </div>
                          <div>
                            {CarouselComponent && <CarouselComponent images={project.images} />}
                          </div>
                          <div className="text-center">
                            <button className="close-modal-button cv-button" onClick={() => setOpen(false)}>[X] CLOSE [X]</button>
                          </div>
                        </div>
                      </div>
                    )}
                  </div>
                </div>
              </div>
            ))}
          </div>
        </div>
      </div>
    </div>
  );
};

export default ProjectSection;
