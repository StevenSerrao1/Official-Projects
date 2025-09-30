import React from "react";
import "../../../Assets/Fonts/LemonMilkRegularFont.css"
import "./Footer.css"; // we'll add the styles here

const Footer: React.FC = () => {
    return (
        <footer className="footer-container dark-bg border-top border-warning border-3 mt-3">
            <div className="container py-3">
                <p className="text-light mb-2 mb-md-0 lato-p text-center">
                    © {new Date().getFullYear()} Steven — Full-stack Developer Portfolio
                </p>
            </div>
        </footer>
    );
};

export default Footer;
