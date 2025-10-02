import React, { useState, useEffect } from "react";
import axios from "axios";
import { AdminProject } from "../../Components/Sections/Projects/types/interfaces";
import "../../Assets/Fonts/LemonMilkRegularFont.css";
import { Link } from "react-router-dom";

const AdminPanel: React.FC = () => {
    const [projects, setProjects] = useState<AdminProject[]>([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        axios.get('https://official-projects.onrender.com/admin/loadadminprojects')
            .then(res => setProjects(res.data))
            .finally(() => setLoading(false));
    }, []);

    if (loading) return <p className="text-light">Loading projects...</p>;

    return (
        <div className="container mt-4">

            {/* Global Create Project Button */}
            <div className="mb-4">
                <Link to="/admin/createproject" className="btn btn-success">Create New Project</Link>
            </div>

            {projects.map(p => (
                <div key={p.projectId} className="mb-4 border rounded p-3 bg-dark text-light shadow-sm">

                    <div className="d-flex justify-content-between align-items-center mb-2 border-bottom pb-2">
                        <h4 className="m-0">{p.title}</h4>
                        <span className="badge bg-warning text-dark">ID: {p.projectId}</span>
                    </div>

                    <div className="mb-2">
                        <p><strong>Description:</strong> {p.description}</p>
                    </div>

                    <div className="mb-2">
                        <p><strong>GitHub Repo:</strong> {p.gitHubRepoName} | <strong>Views:</strong> {p.gitHubViews}</p>
                        <p><strong>Project URL:</strong> <a href={p.projectURL} target="_blank" rel="noreferrer">{p.projectURL}</a></p>
                    </div>

                    <div className="mb-3">
                        <strong>Images:</strong>
                        {p.images.length > 0 ? (
                            <div className="d-flex flex-wrap gap-2 mt-1">
                                {p.images.map((img, idx) => (
                                    <div key={idx} className="p-2 bg-secondary rounded text-dark" style={{ minWidth: '150px' }}>
                                        <img 
                                            src={img.imageUrl} 
                                            alt={img.altText} 
                                            className="rounded mb-1" 
                                            style={{ width: '150px', height: '100px', objectFit: 'cover' }} 
                                        />
                                        <p className="mb-0"><strong>Alt:</strong> {img.altText}</p>
                                        <p className="mb-0"><strong>Caption:</strong> {img.caption}</p>
                                        {img.additionalInfo && <p className="mb-0"><strong>Info:</strong> {img.additionalInfo}</p>}
                                    </div>
                                ))}
                            </div>
                        ) : <p className="text-muted">No images</p>}
                    </div>

                    {/* CRUD Buttons per project */}
                    <div className="d-flex gap-2 mt-2">
                        <Link to={`/admin/updateproject/${p.projectId}`} className="btn btn-sm btn-primary">Update</Link>
                        <Link to={`/admin/deleteproject/${p.projectId}`} className="btn btn-sm btn-danger">Delete</Link>
                    </div>
                </div>
            ))}
        </div>
    );
};

export default AdminPanel;
