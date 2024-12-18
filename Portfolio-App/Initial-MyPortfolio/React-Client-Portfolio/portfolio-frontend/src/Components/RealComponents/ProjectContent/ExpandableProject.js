import React, { useState } from "react";
import { Button, Dialog, DialogActions, DialogContent, DialogTitle, Backdrop, CircularProgress } from "@mui/material";

const ExpandableProject = ({ project }) => {
    const [isExpanded, setIsExpanded] = useState(false);

    const toggleExpand = () => {
        setIsExpanded(prev => !prev);
    };

    return (
        <div style={{ marginBottom: "5px", border: "1px solid #ccc" }}>
            {/* Expand/Collapse Button */}
            <Button variant="outlined" onClick={toggleExpand}>
                {isExpanded ? "Close Project" : "Expand Project"}
            </Button>

            {/* Full-Screen Modal */}
            <Dialog
                open={isExpanded}
                onClose={toggleExpand}
                fullWidth
                maxWidth="lg"
                PaperProps={{
                    style: {
                        backgroundColor: "white",
                        padding: "30px",
                        borderRadius: "10px",
                        zIndex: 10000, // Modal stays on top
                    },
                }}
            >
                <DialogTitle>{project.title}</DialogTitle>
                <DialogContent>
                    {/* Project Full Description */}
                    <p><strong>Description:</strong> {project.fullDescription}</p>

                    {/* Tech Stack */}
                    <p><strong>Github Views:</strong> {project.gitHubViews}</p>

                    {/* Project URL */}
                    <p><strong>URL:</strong> <a href={project.projectURL} target="_blank" rel="noopener noreferrer">{project.projectURL}</a></p>

                    {/* Display both images */}
                    <div style={{ display: "flex", justifyContent: "space-around", marginTop: "20px" }}>
                        <img src={project.images[0].imageUrl} alt="Project Image 1" style={{ width: "45%", height: "auto", borderRadius: "5px", boxShadow: "0 4px 8px rgba(0, 0, 0, 0.1)" }} />
                        <img src={project.images[1].imageUrl} alt="Project Image 2" style={{ width: "45%", height: "auto", borderRadius: "5px", boxShadow: "0 4px 8px rgba(0, 0, 0, 0.1)" }} />
                    </div>
                </DialogContent>
                <DialogActions>
                    <Button onClick={toggleExpand} color="secondary" variant="contained">
                        Close
                    </Button>
                </DialogActions>
            </Dialog>
        </div>
    );
};

export default ExpandableProject;
