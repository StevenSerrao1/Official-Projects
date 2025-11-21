import React, { useState } from "react";
import "../../../Assets/Fonts/LemonMilkRegularFont.css";

const ContactMe: React.FC = () => {
    const [formData, setFormData] = useState({
        name: "",
        email: "",
        message: "",
    });

    const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
        const { name, value } = e.target;
        setFormData((prev) => ({
            ...prev,
            [name]: value,
        }));
    };

    const handleSubmit: React.FormEventHandler<HTMLFormElement> = async (e) => {
        e.preventDefault();

        try {
            const response = await fetch("https://formspree.io/f/mrbpbqgn", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(formData),
            });

            if (response.ok) {
                alert("🎉 Message sent successfully!");
                setFormData({ name: "", email: "", message: "" });
            } else {
                alert("❌ Failed to send message.");
            }
        } catch (err) {
            console.error("Error occurred:", err);
            alert("⚠️ An error occurred while sending your message.");
        }
    };

    return (
        <div className="container-fluid py-4" id="contact">
            <div className="card border-0">
                <div className="border border-warning border-3 lm-bold-font bg-dark">
                    <h2 className="fs-4 dark-bg-heading text-center lm-reg-font pt-4 pb-4 mb-0">
                    <i className="fs-4 me-4 bi-terminal"></i>
                    CONTACT ME!
                    <i className="fs-4 ms-4 bi-terminal-fill"></i>
                </h2>
                </div>
                <div className="card-body border border-warning border-3 lm-bold-font bg-dark">
                    <form onSubmit={handleSubmit} className="mx-auto" style={{ maxWidth: "600px" }}>
                        <div className="mb-3 text-center">
                            <label htmlFor="name" className="form-label form-label-text">Name</label>
                            <input
                                type="text"
                                className="form-control lato-p border-warning border-4"
                                id="name"
                                name="name"
                                value={formData.name}
                                onChange={handleChange}
                                required
                            />
                        </div>
                        <div className="mb-3 text-center">
                            <label htmlFor="email" className="form-label form-label-text">Email</label>
                            <input
                                type="email"
                                className="form-control lato-p border-warning border-4"
                                id="email"
                                name="email"
                                value={formData.email}
                                onChange={handleChange}
                                required
                            />
                        </div>
                        <div className="mb-3 text-center">
                            <label htmlFor="message" className="form-label form-label-text">Message</label>
                            <textarea
                                className="form-control lato-p border-warning border-4"
                                id="message"
                                name="message"
                                rows={4}
                                value={formData.message}
                                onChange={handleChange}
                                required
                            ></textarea>
                        </div>
                        <div className="text-center">
                            <button type="submit" className="btn btn-warning px-5 send-button">
                                Send
                            </button>
                        </div>
                    </form>
                </div>
                <div className="card-body border border-warning border-3 lm-bold-font bg-dark">
                    <div className="row">
                        <div className="col lato-p text-light">
                            <i className="bi-telephone-outbound-fill"></i>  +27673199177
                        </div>
                        <div className="col lato-p hover-underline text-light">
                            <a
                                className="nav-link"
                                href="https://www.instagram.com/steven_serrao"
                                target="_blank"
                                rel="noopener noreferrer"
                            >
                            <i className="bi-instagram"></i>   steven_serrao
                            </a>
                        </div>
                        <div className="col lato-p hover-underline text-light">
                            <a
                                className="nav-link"
                                href="https://www.linkedin.com/in/steven-serrao-0729841b1/"
                                target="_blank"
                                rel="noopener noreferrer"
                            >
                                <i className="bi-linkedin"></i>  Steven Serrao
                            </a>
                        </div>
                        <div className="col lato-p hover-underline text-light">
                            <a
                                className="nav-link"
                                href="https://github.com/StevenSerrao1"
                                target="_blank"
                                rel="noopener noreferrer"
                            >
                                <i className="bi-github"></i>  StevenSerrao1
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default ContactMe;
