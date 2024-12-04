import React from 'react';
import styles from './AboutMeComponent.module.css'; // Import the CSS Module

const AboutMe = () => {
  return (
    <section id="about" className={styles.aboutSection}>
      <h2>About Me</h2>
      <div className={styles.aboutContent}>
        <p>
          Hi, I'm Steven! I'm passionate about backend development and building scalable, efficient web applications.
          I specialize in technologies like ASP.NET Core and React, and I love working on both front-end and back-end projects.
        </p>
        <p>
          When I'm not coding, you can find me listening to music, playing basketball, or experimenting with new recipes in the kitchen.
        </p>
        <div className={styles.avatar}>
          <img
            src="https://via.placeholder.com/150" // Replace with your image URL
            alt="Steven's Avatar"
            className={styles.avatarImg}
          />
        </div>
      </div>
    </section>
  );
};

export default AboutMe;
