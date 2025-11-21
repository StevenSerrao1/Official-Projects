import React, { JSX, useState } from "react";
import "../../Assets/Fonts/LemonMilkRegularFont.css";
import AboutSection from "../Sections/About/AboutSection";
import ProjectSection from "../Sections/Projects/ProjectSection";
import FreelanceSection from "../Sections/Freelance/FreelanceSection";
import ContactSection from "../Sections/Contact/ContactSection";

type Section = "about" | "projects" | "contact" | "freelance";

const LayoutDynamic: React.FC = () => {
    const [section, setSection] = useState<Section>("about");

    const renderSection = (): JSX.Element => {
        switch (section) {
            case "about":
                return <AboutSection />;
            case "projects":
                return <ProjectSection />;
            case "contact":
                return <ContactSection />;
            case "freelance":
                return <FreelanceSection />;
            default: {
                const _exhaustiveCheck: never = section;
                throw new Error(`Unhandled section: ${_exhaustiveCheck}`);
            }
        }
    };

    return (
        <div>
            <div
                className="container-fluid bg-dark border-bottom border-warning border-3"
                style={{ padding: "10px" }}
            >
                <nav
                    className="nav d-flex justify-content-between align-items-center flex-wrap text-light"
                    style={{ margin: "auto" }}
                >
                    <button
                        onClick={() => setSection("about")}
                        className="hover-underline lm-reg-font-m border-0 bg-transparent text-light"
                    >
                        About Me
                    </button>
                    <i className="bi-bullseye text-warning"></i>
                    <button
                        onClick={() => setSection("projects")}
                        className="hover-underline lm-reg-font-m border-0 bg-transparent text-light"
                    >
                        My Projects
                    </button>
                    {/*<i className="bi-bullseye text-warning"></i>
                        <button
                        onClick={() => setSection("freelance")}
                        className="hover-underline lm-reg-font-m border-0 bg-transparent text-light"
                    >
                        Freelancing
                    </button>*/}
                    <i className="bi-bullseye text-warning"></i>
                    <button
                        onClick={() => setSection("contact")}
                        className="hover-underline lm-reg-font-m border-0 bg-transparent text-light"
                    >
                        Contact Me
                    </button>
                </nav>
            </div>
            <div>{renderSection()}</div>
        </div>
    );
};

export default LayoutDynamic;
