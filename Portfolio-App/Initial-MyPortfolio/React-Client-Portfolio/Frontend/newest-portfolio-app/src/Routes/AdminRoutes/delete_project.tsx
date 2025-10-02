import React, { useState, ChangeEvent, FormEvent } from "react";
import axios from "axios";
import { ProjectAddRequest, ImageAddRequest } from "../../Components/Sections/Projects/types/interfaces";
import "../../Assets/Fonts/LemonMilkRegularFont.css";
import { useNavigate, useParams } from "react-router-dom";

const DeleteProject: React.FC = () => {

    const { id } = useParams<{ id: string }>(); // Grab 'id' parameter from URL!
    const [projectId, setProjectId] = useState<number | "">(id ? parseInt(id) : ""); // Ensures type matching
    const navigate = useNavigate(); // Navigation hook
    const ProjectDelete = async (id: number) => {
    try {
        const res = await axios.delete(`https://official-projects.onrender.com/admin/deleteproject/${id}`);
        console.log(res.data);
        alert("Project Deleted Successfully!"); // prompt → alert is simpler here
        setTimeout(() => navigate("/admin"), 1800);
    } catch (err) {
        console.error(err);
        alert("Failed to delete project.");
    }
}


    return(<div>


        <div className="container mt-4">
            <h2 className="mb-4 text-light">Delete Project</h2>
        </div>
        <div>
            <div className="container mt-4">
                <div className="mb-3">
                    <label htmlFor="projectId" className="form-label text-light">Project ID to Delete: {projectId}</label>
                    <h3 className="text-light">Are you sure you wish to delete Project ID: {projectId}?</h3>
                    <button className="bg-success" onClick={() => projectId && ProjectDelete(projectId) }>YES</button>
                    <button className="bg-danger mx-3" onClick={() => navigate("/admin")}>NO</button>
                </div>
            </div>
        </div>


    </div>);
}

export default DeleteProject;