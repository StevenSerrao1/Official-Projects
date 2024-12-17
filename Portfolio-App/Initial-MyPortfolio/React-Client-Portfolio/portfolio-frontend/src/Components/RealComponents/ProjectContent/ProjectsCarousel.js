import React from "react";
import { Swiper, SwiperSlide } from "swiper/react";
import "swiper/css";
import "swiper/css/navigation";
import "swiper/css/pagination";
import { Navigation, Pagination, Autoplay } from "swiper/modules";
import { Box, Typography, Button, Link as MuiLink } from "@mui/material";

const ProjectsCarousel = ({ projects }) => {
  return (
    <Box component="section" sx={{ padding: 4 }} id="projects">
      {/* Section Heading */}
      <Typography
        variant="h4"
        component="h2"
        gutterBottom
        sx={{
          textAlign: "center",
          marginBottom: 4,
          textDecorationLine: "underline",
        }}
      >
        These Are My Projects
      </Typography>

      {/* Swiper Component */}
      <Swiper
        modules={[Navigation, Pagination, Autoplay]}
        spaceBetween={30}
        slidesPerView={1}
        loop={true}
        autoplay={{
          delay: 4000,
          disableOnInteraction: false,
        }}
        pagination={{
          clickable: true,
        }}
        navigation={true}
        style={{
          padding: "0 20px",
        }}
      >
        {projects.map((project) => (
          <SwiperSlide key={project.id}>
            <Box
              sx={{
                display: "flex",
                flexDirection: "column",
                alignItems: "center",
                gap: 2,
              }}
            >
              {/* Project Title */}
              <Typography variant="h5" component="h3" gutterBottom>
                {project.title}
              </Typography>

              {/* Image Preview */}
              {project.images && project.images.length > 0 ? (
                <Box sx={{ textAlign: "center" }}>
                  <img
                    src={project.images[0].imageUrl}
                    alt={project.images[0].altText || "Project Image"}
                    style={{
                      maxWidth: "65%",
                      height: "auto",
                      maxHeight: "300px",
                      borderRadius: 4,
                      boxShadow: "1px 4px 10px rgba(0, 0, 0, 0.2)",
                    }}
                  />
                  {project.images[0].caption && (
                    <Typography
                      variant="caption"
                      component="p"
                      sx={{ marginTop: 1 }}
                    >
                      {project.images[0].caption}
                    </Typography>
                  )}
                </Box>
              ) : (
                <Typography variant="body2" color="textSecondary">
                  No images available
                </Typography>
              )}

              {/* Project Details */}
              <Typography variant="body2" color="textSecondary">
                Created on: {project.dateCreatedFormatted}
              </Typography>
              <Typography variant="body2" color="textSecondary">
                Views on GitHub:{" "}
                <MuiLink
                  href={project.projectURL}
                  target="_blank"
                  rel="noopener noreferrer"
                >
                  {project.gitHubViews}
                </MuiLink>
              </Typography>
              <Typography
                variant="body1"
                sx={{ textAlign: "center", marginY: 2 }}
              >
                {project.shortDescription}
              </Typography>

              {/* Project Links */}
              <MuiLink
                href={project.projectURL}
                target="_blank"
                rel="noopener noreferrer"
                sx={{
                  textDecoration: "none",
                  color: "primary.main",
                  fontWeight: "bold",
                }}
              >
                Go To Project
              </MuiLink>

              {/* Expand Project Placeholder */}
              <Button
                variant="outlined"
                sx={{ marginTop: 2 }}
                onClick={() => console.log(`Expand Project ${project.id}`)}
              >
                Expand Project
              </Button>
            </Box>
          </SwiperSlide>
        ))}
      </Swiper>

      {/* Custom Pagination Styling */}
      <style>
        {`
          .swiper-pagination {
            bottom: 43px !important; /* Move dots lower */
          }

          .swiper-button-prev,
          .swiper-button-next {
            color: #1976d2; /* Default navigation arrow color (MUI primary blue) */
          }
        `}
      </style>
    </Box>
  );
};

export default ProjectsCarousel;
