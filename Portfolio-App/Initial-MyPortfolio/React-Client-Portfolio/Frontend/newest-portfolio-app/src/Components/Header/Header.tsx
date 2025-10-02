import React from "react";
import "../../Assets/Fonts/LemonMilkBoldFont.css";
import "./Header.css"
import { Link } from "react-router-dom";

const HeaderComponent: React.FC = () => {
    return (
        <header
            className="container-fluid px-3 py-2 bg-dark custom-header-border"
            style={{ lineHeight: 1 }}
        >
            <nav className="d-flex flex-wrap justify-content-between align-items-center">
                {/* Left: Name */}
                <div className="lm-bold-font fs-5 text-warning">
                    <a href="/" className="lm-bold-font fs-5 text-warning">STEvEN SERRAO</a>
                </div>

                {/* Center: Social Links */}
                <div className="d-flex align-items-center gap-3 me-5">
                    <a
                        className="nav-link text-light d-flex align-items-center justify-content-center"
                        href="https://github.com/StevenSerrao1"
                        target="_blank"
                        rel="noopener noreferrer"
                    >
                        <i className="bi bi-github fs-4"></i>
                    </a>
                    <Link to="/admin">ADMIN BUTTON</Link>
                    <a
                        className="nav-link text-light d-flex align-items-center justify-content-center"
                        href="https://www.instagram.com/steven_serrao"
                        target="_blank"
                        rel="noopener noreferrer"
                    >
                        <i className="bi bi-instagram fs-4"></i>
                    </a>
                    <a
                        className="nav-link text-light d-flex align-items-center justify-content-center"
                        href="https://www.linkedin.com/in/steven-serrao-0729841b1/"
                        target="_blank"
                        rel="noopener noreferrer"
                    >
                        <i className="bi bi-linkedin fs-4"></i>
                    </a>
                    <a
                        className="nav-link text-success d-flex align-items-center justify-content-center"
                        href="https://wa.me/27673199177?text=Hi%20Steven%2C%20I%27m%20interested%20in%20your%20work!"
                        target="_blank"
                        rel="noopener noreferrer"
                    >
                        <i className="bi bi-whatsapp fs-4"></i>
                    </a>
                </div>

                {/* Right: CV Button */}
                <div>
                    <a
                        href="https://StevenSerrao1.github.io/Official-Projects/assets/STEVEN_SERRAO_DEVELOPER_RESUME.pdf"
                        target="_blank"
                        rel="noopener noreferrer"
                        download="resume.pdf"
                        className="btn btn-warning text-dark lm-bold-font px-4 py-2 border-0 send-button"
                    >
                        My CV
                    </a>
                </div>
            </nav>
        </header>
    );
};

export default HeaderComponent;
