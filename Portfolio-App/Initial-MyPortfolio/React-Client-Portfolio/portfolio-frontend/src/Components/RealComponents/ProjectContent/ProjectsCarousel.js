import React from 'react';
import { Swiper, SwiperSlide } from 'swiper/react';
import 'swiper/css'; // Import Swiper styles
import styles from './ProjectsCarousel.module.css'; // Import the CSS module

const ProjectsCarousel = ({ projects }) => {
  return (
    <section id="projects" className={styles['projects-carousel']}>
      <h2>My Projects for real</h2>

      <Swiper
        spaceBetween={30}
        slidesPerView={1}
        loop={true}
        autoplay={{
          delay: 2500,
          disableOnInteraction: false,
        }}
        pagination={{ clickable: true }}
        navigation={true}
        className={styles['swiper-container']} // Use class from CSS module
      >
        {projects.map((project) => (
      <SwiperSlide key={project.id} className={styles['swiper-slide']}>
        <div className={styles['project-item']}>
          {/* Map through images for the current project */}
          {project.images && project.images.length > 0 ? (
            project.images.map((image, index) => (
              <div key={index} className={styles['image-container']}>
                <img
                  src={image.imageUrl}
                  alt={image.altText}
                  className={styles['project-image']}
                />
                {image.caption && <p className={styles['image-caption']}>{image.caption}</p>}
              </div>
            ))
          ) : (
            <p>No images available</p>
          )}

          <h2>{project.title}</h2>
          <h5>Created on: {project.dateCreatedFormatted}</h5>
          <p>{project.shortDescription}</p>
          <a href={project.projectURL} className={styles['project-link']}>
            View Project
          </a>
        </div>
      </SwiperSlide>
    ))}
      </Swiper>
    </section>
  );
};

export default ProjectsCarousel;
