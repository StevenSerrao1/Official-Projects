import HeaderComponent from "../../Components/RealComponents/Header/HeaderComponent";
import AboutMe from "../../Components/RealComponents/AboutMe/AboutMeComponent";
import Projects from "../../Components/RealComponents/ProjectContent/ProjectsComponent";
import ContactMe from "../../Components/RealComponents/ContactMe/ContactMeComponent";

function HomePage()
{
    return(
        <div>
            <HeaderComponent />
            <AboutMe />
            <Projects />
            <ContactMe />
        </div>
    );
}

export default HomePage;