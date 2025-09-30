import React, { useState, useEffect } from "react";
import axios from "axios";
import { Project } from "./types/interfaces";
import "../../../styles/card-styling.css";
import "../../../Assets/Fonts/LemonMilkRegularFont.css";

const ProjectSection: React.FC = () => {
  const [projects, setProjects] = useState<Project[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    axios
      //.get('http://localhost:5000/api/projects/loadprojects') // Dev Endpoint
      .get("https://official-projects.onrender.com/api/projects/loadprojects") // Production Endpoint
      .then((res) => {
        setProjects(res.data);
        setLoading(false);
      })
      .catch(() => setLoading(false));
  }, []);

  if (loading) {
    return (
      <div className="container-fluid my-4">
        <div className="border border-3 border-warning p-0">
          {/* Heading */}
          <h2 className="fs-4 dark-bg-heading text-center lm-reg-font pt-4 pb-4 mb-0">
            <i className="fs-4 me-4 bi-code"></i>
            MY PERSONAL PROJECTS
            <i className="fs-4 ms-4 bi-code"></i>
          </h2>
        </div>
        <div className="d-flex justify-content-center my-5">
          <div className="spinner-border text-info" role="status">
            <span className="visually-hidden">Loading…</span>
          </div>
        </div>
      </div>
    );
  }

  return (
    <div className="container-fluid my-4">
      <div className="border border-3 border-warning p-0">
        {/* Heading */}
        <h2 className="fs-4 dark-bg-heading text-center lm-reg-font pt-4 pb-4 mb-0">
          <i className="fs-4 me-4 bi-code"></i>
          MY PERSONAL PROJECTS
          <i className="fs-4 ms-4 bi-code"></i>
        </h2>
      </div>
      <div className="border border-warning border-3 shadow p-4 bg-dark">
        <div className="container py-3">
          <div className="row g-4">
            {projects.map((p) => (
              <div
                key={p.images[0].projectId}
                className="col-12 col-sm-6 col-md-4"
              >
                <div className="card h-100 border-warning border-2 hover-lift bg-dark">
                  {p.images?.[0] && (
                    <img
                      src={p.images[0].imageUrl}
                      alt={p.images[0].altText}
                      className="card-img-top"
                      style={{ height: "160px", objectFit: "cover" }}
                    />
                  )}
                  <div className="card-body d-flex flex-column">
                    <h5 className="card-title border-bottom border-3 border-warning lato-p fs-4 text-light text-center">
                      {p.title}
                    </h5>
                    <p className="card-text flex-grow-1 lato-p text-light">
                      {p.shortDescription}
                    </p>
                    <a
                      href={p.projectURL}
                      target="_blank"
                      rel="noopener noreferrer"
                      className="btn btn-sm btn-warning mt-auto"
                    >
                      View Project!
                    </a>
                    <a
                      href={"https://github.com/StevenSerrao1/" + p.gitHubRepoName}
                      target="_blank"
                      rel="noopener noreferrer"
                      className="btn btn-sm btn-warning mt-2"
                    >
                      View Source Code!
                    </a>
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
