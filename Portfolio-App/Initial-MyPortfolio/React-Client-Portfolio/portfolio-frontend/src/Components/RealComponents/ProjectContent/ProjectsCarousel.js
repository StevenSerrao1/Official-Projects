import React from 'react';
import { Swiper, SwiperSlide } from 'swiper/react';
import 'swiper/css'; // Import Swiper styles
import styles from './ProjectsCarousel.module.css'; // Import the CSS module

const ProjectsCarousel = ({ projects }) => {
  return (
    <section className={styles['projects-carousel']}>
      <h2>These Are My Projects</h2>
  {/* Your Swiper component */}
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
    className={styles['swiper-container']}
    id="projects"
  >
    {projects.map((project) => (
      <SwiperSlide key={project.id} className={styles['swiper-slide']} >
        <div className={styles['swiper-button-prev']}>
        <h4>Swipe ←</h4>
        </div>
        <div className={styles['project-item']}>
          {/* Display only the first image for preview */}
          <h2>{project.title}</h2>
          {project.images && project.images.length > 0 ? (
            <div className={styles['image-container']}>
              <img
                src={project.images[0].imageUrl} // Display the first image
                alt={project.images[0].altText || 'Project Image'} // Provide alt text fallback
                className={styles['project-image']}
                style={{ maxWidth: '60%', height: 'auto', maxHeight: '300px' }}
              />
              {project.images[0].caption && (
                <p className={styles['image-caption']}>{project.images[0].caption}</p>
              )}
            </div>
          ) : (
            <p>No images available</p>
          )}
          <h5>Created on: {project.dateCreatedFormatted}</h5>
          <h5>
            <a
              href={project.projectURL}
              target="_blank"
              rel="noopener noreferrer"
              className={styles['project-link']}
            >
              Views on GitHub:
            </a>{' '}
            {project.gitHubViews}
          </h5>
          <p>{project.shortDescription}</p>
          {/* Below link must lead to actual project URL */}
          <a
            href={project.projectURL}
            target="_blank"
            rel="noopener noreferrer"
            className={styles['project-link']}
          >
            Go To Project
          </a>
          <br />
          {/* Placeholder for dynamic expansion */}
          <button
            className={styles['expand-project-button']}
            /*onClick={() => handleExpandProject(project.id)}*/
          >
            Expand Project
          </button>
        </div>
        <div className={styles['swiper-button-next']}>
          <h4>Swipe →</h4>
        </div>
      </SwiperSlide>
    ))}
  </Swiper>

   </section>
  );
};

export default ProjectsCarousel;
