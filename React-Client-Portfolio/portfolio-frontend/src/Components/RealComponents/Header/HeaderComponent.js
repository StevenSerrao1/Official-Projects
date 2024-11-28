import React from "react";
import { Link } from "react-router-dom"; // Import routing tools
import styles from './HeaderComponent.module.css'; // Import the CSS Module

function HeaderComponent() {
  return (
    <header className={styles.header}>
      {/* Navigation Links */}
      <nav>
        <ul>
          <li><Link to="/">About Me</Link></li> {/* Home link */}
          <li><Link to="#projects">Projects</Link></li> {/* Projects link */}
          <li><Link to="/">Contact Me</Link></li> {/* Contact link */}
        </ul>
      </nav>
    </header>
  );
}

export default HeaderComponent;
