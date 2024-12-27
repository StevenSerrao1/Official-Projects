import React, { useState } from "react";
import { Button, Dialog, DialogActions, DialogContent, DialogTitle } from "@mui/material";

const ExpandableProject = ({ project }) => {
    const [isExpanded, setIsExpanded] = useState(false);

    const toggleExpand = (e) => {
        e.stopPropagation(); // Prevents event interference with Swiper
        setIsExpanded((prev) => !prev);
        console.log("ExpandableProject isExpanded:", !isExpanded); // Debugging
    };

    return (
        <div style={{ marginBottom: "5px", border: "1px solid #ccc" }}>
            {/* Expand/Collapse Button */}
            <Button
                variant="outlined"
                onClick={toggleExpand}
                sx={{
                    color: "text.primary", // Ensure button text adapts to dark mode
                    borderColor: "text.primary",
                    "&:hover": {
                        borderColor: "text.secondary", // Hover effect with theme colors
                    },
                }}
            >
                {isExpanded ? "Close Project" : "Expand Project"}
            </Button>

            {/* Full-Screen Modal */}
            <Dialog
                open={isExpanded}
                onClose={toggleExpand}
                fullWidth
                maxWidth="lg"
                PaperProps={{
                    sx: {
                        backgroundColor: "background.paper", // Apply background from the theme
                        padding: "30px",
                        borderRadius: "10px",
                        zIndex: 10000, // Modal stays on top
                    },
                }}
            >
                <DialogTitle sx={{ color: "text.primary" }}>{project.title}</DialogTitle>

                {isExpanded && ( // Lazy-load dialog content
                    <DialogContent>
                        {/* Project Full Description */}
                        <p>
                            <strong>Description:</strong> {project.fullDescription}
                        </p>

                        {/* Image 1 */}
                        {project.images && project.images[0] && (
                            <div style={{ marginBottom: "20px" }}>
                                <img
                                    src={project.images[0].imageUrl}
                                    alt={project.images[0].altText || "Project Image 1"}
                                    style={{
                                        width: "100%",
                                        height: "auto",
                                        borderRadius: "5px",
                                        boxShadow: "0 4px 8px rgba(0, 0, 0, 0.1)",
                                    }}
                                />
                            </div>
                        )}

                        {/* Paragraph after image 1 */}
                        <p>
                            <strong>Additional Info:</strong> {project.images[0].additionalInfo}
                        </p>

                        {/* Image 2 */}
                        {project.images && project.images[1] && (
                            <div style={{ marginBottom: "20px" }}>
                                <img
                                    src={project.images[1].imageUrl}
                                    alt={project.images[1].altText || "Project Image 2"}
                                    style={{
                                        width: "100%",
                                        height: "auto",
                                        borderRadius: "5px",
                                        boxShadow: "0 4px 8px rgba(0, 0, 0, 0.1)",
                                    }}
                                />
                            </div>
                        )}

                        {/* Paragraph after image 2 */}
                        <p>
                            <strong>More Information:</strong> {project.images[1].additionalInfo}
                        </p>

                        {/* GitHub Views */}
                        <p>
                            <strong>GitHub Views:</strong> {project.gitHubViews}
                        </p>

                        {/* Project URL */}
                        <p>
                            <strong>URL:</strong>{" "}
                            <a href={project.projectURL} target="_blank" rel="noopener noreferrer">
                                {project.projectURL}
                            </a>
                        </p>
                    </DialogContent>
                )}

                <DialogActions>
                    <Button onClick={toggleExpand} variant="contained">
                        Close
                    </Button>
                </DialogActions>
            </Dialog>
        </div>
    );
};

export default ExpandableProject;
