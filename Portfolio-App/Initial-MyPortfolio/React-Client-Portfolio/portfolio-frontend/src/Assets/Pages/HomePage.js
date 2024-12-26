import React from 'react';
import HeaderComponent from "../../Components/RealComponents/Header/HeaderComponent";
import AboutMe from "../../Components/RealComponents/AboutMe/AboutMeComponent";
import Projects from "../../Components/RealComponents/ProjectContent/ProjectsComponent";
import ContactMe from "../../Components/RealComponents/ContactMe/ContactMeComponent";
import FooterComponent from "../../Components/RealComponents/Footer/FooterComponent";

function HomePage({ darkMode, setDarkMode }) {
    return (
        <div>
            <HeaderComponent darkMode={darkMode} setDarkMode={setDarkMode} />
            <AboutMe />
            <Projects />
            <ContactMe />
            <FooterComponent />
        </div>
    );
}

export default HomePage;
