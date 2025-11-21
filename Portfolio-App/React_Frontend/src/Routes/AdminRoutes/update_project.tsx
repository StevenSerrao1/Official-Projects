import React, { useState, ChangeEvent, FormEvent, useEffect } from "react";
import axios from "axios";
import { ProjectAddRequest, AdminProject } from "../../Components/Sections/Projects/types/interfaces";
import "../../Assets/Fonts/LemonMilkRegularFont.css";
import { useNavigate, useParams } from "react-router-dom";

const UpdateProject: React.FC = () => {
  const { id } = useParams<{ id: string }>();
  const navigate = useNavigate();

  const [projectToEdit, setProjectToEdit] = useState<ProjectAddRequest | null>(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  // Fetch project on mount
  useEffect(() => {
    if (!id) return;

    axios.get<AdminProject>(`https://official-projects.onrender.com/admin/project/${id}`)
      .then((res) => {
        const p = res.data;
        const mapped: ProjectAddRequest = {
          title: p.title,
          description: p.description,
          projectURL: p.projectURL,
          gitHubRepoName: p.gitHubRepoName,
          images: p.images?.map(img => ({
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

  const handleChange = (e: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
    if (!projectToEdit) return;
    const { name, value } = e.target;
    setProjectToEdit({ ...projectToEdit, [name]: value });
  };

  // Safely update image fields
  const handleImageChange = (
    index: number,
    field: keyof ProjectAddRequest["images"][0],
    value: string
  ) => {
    setProjectToEdit(prev => {
      if (!prev) return prev;
      const updatedImages = [...prev.images];
      updatedImages[index][field] = value;
      return { ...prev, images: updatedImages };
    });
  };

  const addImage = () => {
    if (!projectToEdit) return;
    setProjectToEdit(prev => prev ? {
      ...prev,
      images: [...prev.images, { imageUrl: "", caption: "", altText: "", additionalInfo: "" }],
    } : null);
  };

  const removeImage = (index: number) => {
    setProjectToEdit(prev => {
      if (!prev) return prev;
      const updatedImages = prev.images.filter((_, i) => i !== index);
      return { ...prev, images: updatedImages };
    });
  };

  const handleSubmit = async (e: FormEvent) => {
    e.preventDefault();
    if (!projectToEdit || !id) return;

    try {
      await axios.put(`https://official-projects.onrender.com/admin/${id}/post`, { ...projectToEdit, projectId: Number(id) });
      navigate("/admin");
    } catch (err) {
      console.warn("Update failed, attempting create+delete fallback");
      try {
        await axios.post("https://official-projects.onrender.com/admin/createproject/", { ...projectToEdit, projectId: Number(id) });
        await axios.delete(`https://official-projects.onrender.com/admin/deleteproject/${id}`);
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

          {/* Basic project info */}
          <div className="mb-3">
            <label className="form-label text-light">Title</label>
            <input type="text" name="title" value={projectToEdit.title} onChange={handleChange} className="form-control" required />
          </div>
          <div className="mb-3">
            <label className="form-label text-light">Description</label>
            <textarea name="description" value={projectToEdit.description} onChange={handleChange} className="form-control" rows={4} required></textarea>
          </div>
          <div className="mb-3">
            <label className="form-label text-light">Project URL</label>
            <input type="text" name="projectURL" value={projectToEdit.projectURL} onChange={handleChange} className="form-control" />
          </div>
          <div className="mb-3">
            <label className="form-label text-light">GitHub Repo Name</label>
            <input type="text" name="gitHubRepoName" value={projectToEdit.gitHubRepoName} onChange={handleChange} className="form-control" />
          </div>

          {/* Images editing */}
          <div className="mb-3">
            <h4 className="text-light">Images</h4>
            {projectToEdit.images.map((img, idx) => (
              <div key={idx} className="border p-2 mb-3 bg-dark text-light">
                <img src={img.imageUrl} alt={img.altText} className="mb-2" style={{ width: '150px', height: '100px', objectFit: 'cover' }} />
                <div className="mb-1">
                  <label className="form-label">Image URL</label>
                  <input type="text" value={img.imageUrl} onChange={(e) => handleImageChange(idx, "imageUrl", e.target.value)} className="form-control" />
                </div>
                <div className="mb-1">
                  <label className="form-label">Alt Text</label>
                  <input type="text" value={img.altText} onChange={(e) => handleImageChange(idx, "altText", e.target.value)} className="form-control" />
                </div>
                <div className="mb-1">
                  <label className="form-label">Caption</label>
                  <input type="text" value={img.caption} onChange={(e) => handleImageChange(idx, "caption", e.target.value)} className="form-control" />
                </div>
                <div className="mb-1">
                  <label className="form-label">Additional Info</label>
                  <input type="text" value={img.additionalInfo} onChange={(e) => handleImageChange(idx, "additionalInfo", e.target.value)} className="form-control" />
                </div>
                <button type="button" className="btn btn-danger mt-2" onClick={() => removeImage(idx)}>Remove Image</button>
              </div>
            ))}
            <button type="button" className="btn btn-success mb-3" onClick={addImage}>Add New Image</button>
          </div>

          <button type="submit" className="btn btn-warning mt-3">Save Changes</button>
        </form>
      )}
    </div>
  );
};

export default UpdateProject;
