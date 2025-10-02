import React, { useState, ChangeEvent, FormEvent } from "react";
import axios from "axios";
import { ProjectAddRequest, ImageAddRequest } from "../../Components/Sections/Projects/types/interfaces";
import "../../Assets/Fonts/LemonMilkRegularFont.css";
import { useNavigate } from "react-router-dom";

const CreateProject: React.FC = () => {
    const [project, setProject] = useState<ProjectAddRequest>({
        title: "",
        description: "",
        projectURL: "",
        gitHubRepoName: "",
        images: [{ imageUrl: "", caption: "", altText: "", additionalInfo: "" }]
    });

    const [loading, setLoading] = useState(false);
    const [response, setResponse] = useState("");
    const navigate = useNavigate();

    // Handle changes to project-level inputs
    const handleChange = (e: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
        const { name, value } = e.target;
        setProject({ ...project, [name]: value });
    };

    // Handle changes to images
    const handleImageChange = (index: number, e: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
        const { name, value } = e.target;
        const newImages: ImageAddRequest[] = [...project.images];
        newImages[index] = { ...newImages[index], [name]: value };
        setProject({ ...project, images: newImages });
    };

    const addImageField = () => {
        setProject({
            ...project,
            images: [...project.images, { imageUrl: "", caption: "", altText: "", additionalInfo: "" }]
        });
    };

    const removeImageField = (index: number) => {
        const newImages = project.images.filter((_, i) => i !== index);
        setProject({ ...project, images: newImages });
    };

    const handleSubmit = async (e: FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        setLoading(true);
        setResponse("");
        try {
            const res = await axios.post("https://official-projects.onrender.com/admin/createproject/", project);
            setResponse("Project created successfully!");
            setTimeout(() => navigate('/admin'), 1800); // Redirect to /admin after creation
            console.log(res.data);
            // Optionally reset form
            setProject({
                title: "",
                description: "",
                projectURL: "",
                gitHubRepoName: "",
                images: [{ imageUrl: "", caption: "", altText: "", additionalInfo: "" }]
            });
        } catch (err) {
            console.error(err);
            setResponse("❌ Error creating project.");
        } finally {
            setLoading(false);
        }
    };

    return (
        <div className="container mt-4">
            <h2 className="mb-4 text-light">Create New Project</h2>
            <form onSubmit={handleSubmit} className="bg-dark p-4 rounded shadow-sm text-light">

                {/* Project Info */}
                <div className="mb-3">
                    <label className="form-label">Title</label>
                    <input type="text" name="title" className="form-control" value={project.title} onChange={handleChange} required />
                </div>

                <div className="mb-3">
                    <label className="form-label">Description</label>
                    <textarea name="description" className="form-control" rows={3} value={project.description} onChange={handleChange} required />
                </div>

                <div className="mb-3">
                    <label className="form-label">Project URL</label>
                    <input type="text" name="projectURL" className="form-control" value={project.projectURL} onChange={handleChange} required />
                </div>

                <div className="mb-3">
                    <label className="form-label">GitHub Repository Name</label>
                    <input type="text" name="gitHubRepoName" className="form-control" value={project.gitHubRepoName} onChange={handleChange} required />
                </div>

                {/* Dynamic Images */}
                <div className="mb-3">
                    <strong>Images</strong>
                    {project.images.map((img, idx) => (
                        <div key={idx} className="mb-2 p-2 bg-secondary rounded text-dark">
                            <input
                                type="text"
                                name="imageUrl"
                                placeholder="Image URL"
                                value={img.imageUrl}
                                onChange={(e) => handleImageChange(idx, e)}
                                className="form-control mb-1"
                                required
                            />
                            <input
                                type="text"
                                name="caption"
                                placeholder="Caption"
                                value={img.caption}
                                onChange={(e) => handleImageChange(idx, e)}
                                className="form-control mb-1"
                            />
                            <input
                                type="text"
                                name="altText"
                                placeholder="Alt Text"
                                value={img.altText}
                                onChange={(e) => handleImageChange(idx, e)}
                                className="form-control mb-1"
                                required
                            />
                            <textarea
                                name="additionalInfo"
                                placeholder="Additional Info"
                                value={img.additionalInfo}
                                onChange={(e) => handleImageChange(idx, e)}
                                className="form-control mb-1"
                                rows={2}
                            />
                            <button type="button" className="btn btn-sm btn-danger mt-1" onClick={() => removeImageField(idx)}>Remove Image</button>
                        </div>
                    ))}
                    <button type="button" className="btn btn-sm btn-success mt-2" onClick={addImageField}>Add Another Image</button>
                </div>

                {/* Submit */}
                <button type="submit" className="btn btn-primary" disabled={loading}>
                    {loading ? "Creating..." : "Create Project"}
                </button>

                {response && <p className="mt-2">{response}</p>}
            </form>
        </div>
    );
};

export default CreateProject;
