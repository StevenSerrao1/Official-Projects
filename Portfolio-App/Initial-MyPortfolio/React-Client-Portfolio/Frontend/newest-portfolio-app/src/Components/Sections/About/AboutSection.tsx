import React from "react";
import "../../../Assets/Fonts/LemonMilkRegularFont.css";
import "../../../styles/AboutMeCSS.css"; // New shared style file for dark + yellow theme
import { useNavigate } from "react-router-dom";

const AboutSection: React.FC = () => {
    const navigate = useNavigate();

    return (
        <div className="container-fluid my-4" id="about">
            <div className="border border-3 border-warning p-0">
                {/* Heading */}
                <h2 className="fs-4 dark-bg-heading text-center lm-reg-font pt-4 pb-4 mb-0">
                    <i className="fs-4 me-4 bi-terminal"></i>
                    Welcome to my professional full-stack developer portfolio!
                    <i className="fs-4 ms-4 bi-terminal-fill"></i>
                </h2>
            </div>

            <div className="border border-warning border-3 p-4 text-light rounded-bottom">

                {/* Content */}
                <div className="row align-items-center gx-4">
                    {/* Text Section */}
                    <div className="col-md-8">
                        <p className="lato-p text-light">
                            I’m a <strong>full-stack developer</strong> with a strong focus on <strong>backend engineering</strong> using <strong>ASP.NET Core</strong>, <strong>EF Core</strong>, and <strong>SQL</strong>. I am currently building <strong>SoundBite™</strong>, a music rating app designed to improve my skills in creating <strong>scalable</strong>, <strong>user-focused applications</strong>. I am experienced in deploying containerized applications with <strong>Docker</strong> and managing cloud infrastructure on <strong>Azure</strong> to ensure systems are <strong>reliable</strong> and <strong>maintainable</strong>. While I enjoy creating intuitive frontends with <strong>React</strong> and <strong>Blazor</strong>, my core strength lies in <strong>backend development</strong>, building <strong>high-performance APIs</strong> and services in <strong>C#</strong> and <strong>Python</strong> that deliver results. Based in South Africa, I am seeking full-time opportunities anywhere in the <strong>Western Cape Province</strong>, <strong>Johannesburg</strong>, or <strong>Pretoria</strong>, whether <strong>remote</strong>, <strong>hybrid</strong>, or <strong>on-site</strong>. I want to join a team that values <strong>clean code</strong>, <strong>practical problem-solving</strong>, and delivering features that make a difference.
                        </p>
                        <p className="yellow-underline fs-5 lato-p mt-3"><strong>Let's Build Something Real.</strong></p>
                    </div>

                    {/* Avatar Section */}
                    <div className="col-md-4 text-center mb-5 ps-0">
                        <img
                            src="https://i.imgur.com/xhAiq5z.png"
                            alt="Steven's Avatar"
                            className="img-fluid rounded-circle border border-3 border-warning avatar-img"
                        />
                    </div>
                </div>

                <h3 className="fw-bold mt-4 mb-5 yellow-underline text-center lm-reg-font">My Tech Stack</h3>

                <div className="row">
                    <div className="col-md-6 mt-3 text-light">
                        <div className="mb-4">
                            <strong className="yellow-underline lato-p">Languages:</strong>
                            <span className="lato-p ms-2"> C#, JavaScript/TypeScript, Python</span>
                        </div>
                        <div className="mb-4">
                            <strong className="yellow-underline lato-p">Frameworks:</strong>
                            <span className="lato-p ms-2"> ASP.NET Core, React, Django, Blazor</span>
                        </div>
                        <div className="mb-4">
                            <strong className="yellow-underline lato-p">Tools:</strong>
                            <span className="lato-p ms-2"> Docker, Git, GitHub, PowerShell, Git Bash</span>
                        </div>
                        <div className="mb-4">
                            <strong className="yellow-underline lato-p">Databases:</strong>
                            <span className="lato-p ms-2"> SQL Server, PostgreSQL</span>
                        </div>
                        <div className="mb-4">
                            <strong className="yellow-underline lato-p">Cloud:</strong>
                            <span className="lato-p ms-2"> Microsoft Azure, Render</span>
                        </div>
                        <div>
                            <strong className="yellow-underline lato-p">Other:</strong>
                            <span className="lato-p ms-2"> Unity3D, REST APIs, Clean Architecture</span>
                        </div>
                    </div>

                    <div className="col-md-6">
                        <small className="text-muted text-decoration-underline">Relative proficiency (self-assessed)</small>
                        {[{
                            label: "ASP.NET Core (with C#)",
                            value: 85,
                            barClass: "bg-success"
                        },{
                            label: "React (with TypeScript/JavaScript)",
                            value: 65,
                            barClass: "bg-info"
                        },{
                            label: "EF Core (with C#)",
                            value: 65,
                            barClass: "bg-primary"
                        },{
                            label: "SQL/PostgreSQL (with SQL)",
                            value: 70,
                            barClass: "bg-warning"
                        }].map(({label, value, barClass}) => (
                            <div className="mb-2" key={label}>
                                <span className="fs-5"><strong className="lato-p">{label}</strong></span>
                                <div className="progress mt-1" style={{height: 24}}>
                                    <div
                                        className={`progress-bar ${barClass}`}
                                        style={{width: `${value}%`, color: "#000", fontWeight: 600}}
                                    >
                                        {value}%
                                    </div>
                                </div>
                            </div>
                        ))}
                    </div>
                </div>
            </div>
        </div>
    );
};

export default AboutSection;
