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
              <img
                src={project.imageUrl}
                alt={project.title}
                className={styles['project-image']}
              />
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
