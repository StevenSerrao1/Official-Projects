import React, { useState } from 'react';
import HeaderComponent from "../../Components/RealComponents/Header/HeaderComponent";
import AboutMe from "../../Components/RealComponents/AboutMe/AboutMeComponent";
import Projects from "../../Components/RealComponents/ProjectContent/ProjectsComponent";
import ContactMe from "../../Components/RealComponents/ContactMe/ContactMeComponent";
import FooterComponent from "../../Components/RealComponents/Footer/FooterComponent";
import NavPanel from '../../Components/RealComponents/NavPanel/NavPanel';
import FreelanceSection from '../../Components/RealComponents/FreelanceSection/FreelanceSection';

function HomePage({ darkMode, setDarkMode }) {
    const [activeSection, setActiveSection] = useState('about'); // State to track active section

    const handleSectionChange = (section) => {
        setActiveSection(section);
    };

    return (
        <div>
            <HeaderComponent darkMode={darkMode} setDarkMode={setDarkMode} onSectionChange={handleSectionChange} />
            {/* Pass handleSectionChange to NavPanel */}
            <NavPanel onSectionChange={handleSectionChange} />
            <div className="content">
                {activeSection === 'about' && <AboutMe />}
                {activeSection === 'projects' && <Projects />}
                {activeSection === 'contact' && <ContactMe />}
                {activeSection === 'freelance' && <FreelanceSection />}
            </div>
            <FooterComponent />
        </div>
    );
}

export default HomePage;
