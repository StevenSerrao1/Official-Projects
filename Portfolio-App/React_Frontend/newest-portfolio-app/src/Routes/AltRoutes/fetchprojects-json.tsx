import axios from "axios";
import { AdminProject } from "../../Components/Sections/Projects/types/interfaces"; // optional, for typing
import React, { useEffect, useState } from "react";

const FetchProjectsJSON: React.FC = () => {
  const [projects, setProjects] = useState<AdminProject[]>([]);

  useEffect(() => {
    const fetchData = async () => {
      const res = await axios.get<AdminProject[]>(
        "https://official-projects.onrender.com/admin/loadadminprojects"
      );
      setProjects(res.data);
    };
    fetchData();
  }, []);

  return (
    <div>
      {projects.map(p => (
        <div key={p.projectId} className="text-light">
            Title: {p.title} <br />
            Date Created: {p.dateCreatedFormatted} <br />
            Description: {p.description} <br />
            Project URL: {p.projectURL} <br />
            GitHub Repo Name: {p.gitHubRepoName} <br />
            GitHub Views: {p.gitHubViews} <br />
            Images: {p.images.map((img) => (
                <div>
                    Id: {img.projectId} <br />
                    URL: {img.imageUrl} <br />
                    Caption: {img.caption} <br />
                    Alt Text: {img.altText} <br />
                    Additional Info: {img.additionalInfo} <br />
                </div>
            ))}
            <br /><br />
        </div>
        
      ))}
    </div>
  );
};


export default FetchProjectsJSON;
