import React, { useState, ChangeEvent, FormEvent, useEffect } from "react";
import axios from "axios";
import {
  ProjectAddRequest,
  AdminProject,
} from "../../Components/Sections/Projects/types/interfaces";
import "../../Assets/Fonts/LemonMilkRegularFont.css";
import { useNavigate, useParams } from "react-router-dom";

const UpdateProject: React.FC = () => {
  const { id } = useParams<{ id: string }>();
  const navigate = useNavigate();

  const [projectToEdit, setProjectToEdit] = useState<ProjectAddRequest | null>(
    null
  );
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  // Fetch the project by ID on mount
  useEffect(() => {
    if (!id) return;

    axios
      .get<AdminProject>(
        `https://official-projects.onrender.com/admin/project/${id}`
      )
      .then((res) => {
        const p = res.data;
        const mapped: ProjectAddRequest = {
          title: p.title,
          description: p.description,
          projectURL: p.projectURL,
          gitHubRepoName: p.gitHubRepoName,
          images:
            p.images?.map((img) => ({
              imageUrl: img.imageUrl,
              caption: img.caption,
              altText: img.altText,
              additionalInfo: img.additionalInfo,
            })) ?? [],
        };
        setProjectToEdit(mapped);
        setLoading(false);
      })
      .catch(() => {
        setError("Failed to load project");
        setLoading(false);
      });
  }, [id]);

  // Handle form changes
  const handleChange = (
    e: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
  ) => {
    if (!projectToEdit) return;
    const { name, value } = e.target;
    setProjectToEdit({ ...projectToEdit, [name]: value });
  };

  // Handle submit
  const handleSubmit = async (e: FormEvent) => {
    e.preventDefault();
    if (!projectToEdit || !id) return;

    try {
      // Attempt update (id in URL + id in body)
      await axios.put(
        `https://official-projects.onrender.com/admin/${id}/post`,
        { ...projectToEdit, projectId: Number(id) }
      );
      navigate("/admin");
    } catch (err) {
      console.warn("Update failed, attempting create+delete fallback");

      try {
        // Create new project with same ID
        await axios.post(
          "https://official-projects.onrender.com/admin/createproject/",
          { ...projectToEdit, projectId: Number(id) }
        );

        // Delete old project
        await axios.delete(
          `https://official-projects.onrender.com/admin/deleteproject/${id}`
        );

        navigate("/admin");
      } catch (fallbackErr) {
        setError("Both update and fallback failed");
        console.error(fallbackErr);
      }
    }
  };

  if (loading) return <p>Loading project...</p>;
  if (error) return <p className="text-danger">{error}</p>;

  return (
    <div className="container mt-5">
      <h2 className="lm-reg-font text-warning">Update Project</h2>
      {projectToEdit && (
        <form onSubmit={handleSubmit} className="mt-4">
          <div className="mb-3">
            <label className="form-label text-light">Title</label>
            <input
              type="text"
              name="title"
              value={projectToEdit.title}
              onChange={handleChange}
              className="form-control"
              required
            />
          </div>

          <div className="mb-3">
            <label className="form-label text-light">Description</label>
            <textarea
              name="description"
              value={projectToEdit.description}
              onChange={handleChange}
              className="form-control"
              rows={4}
              required
            ></textarea>
          </div>

          <div className="mb-3">
            <label className="form-label text-light">Project URL</label>
            <input
              type="text"
              name="projectURL"
              value={projectToEdit.projectURL}
              onChange={handleChange}
              className="form-control"
            />
          </div>

          <div className="mb-3">
            <label className="form-label text-light">GitHub Repo Name</label>
            <input
              type="text"
              name="gitHubRepoName"
              value={projectToEdit.gitHubRepoName}
              onChange={handleChange}
              className="form-control"
            />
          </div>

          {/* Images section (just editing first one for now) */}
          {projectToEdit.images.length > 0 && (
            <div className="mb-3">
              <label className="form-label text-light">Image URL</label>
              <input
                type="text"
                value={projectToEdit.images[0].imageUrl}
                onChange={(e) => {
                  const updatedImages = [...projectToEdit.images];
                  updatedImages[0].imageUrl = e.target.value;
                  setProjectToEdit({ ...projectToEdit, images: updatedImages });
                }}
                className="form-control"
              />
            </div>
          )}

          <button type="submit" className="btn btn-warning mt-3">
            Save Changes
          </button>
        </form>
      )}
    </div>
  );
};

export default UpdateProject;
