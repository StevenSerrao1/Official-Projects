import React from "react";
import { Typography, Box, Avatar, Paper, Container } from "@mui/material";

const AboutMe = () => {
  return (
    <div class="MuiPaper-root">
     <Paper elevation={3}>
      <Box id="about" sx={{ padding: 4, backgroundColor: "background.paper" }}>
 
      <Container>
        {/* Heading */}
        <Typography variant="h4" component="h2" gutterBottom sx ={{ textDecorationLine: "underline" }}>
          Welcome to my professional full-stack dev portfolio!
        </Typography>

        {/* Content Section */}
        <Box sx={{ display: "flex", flexDirection: { xs: "column", md: "row" }, alignItems: "center", gap: 4 }}>
          {/* Text Content */}
          <Box sx={{ flex: 1 }}>
            <Typography variant="body1" component="p" sx={{ marginBottom: 2, marginTop: 2 }}>
            Hey, I'm Steven! I'm primarily a backend developer who thrives on building scalable, efficient, and reliable systems. My go-to tools for full-stack development are ASP.NET Core and React, which I use to craft robust APIs and full-stack applications that prioritize functionality, performance, and clean architecture. I excel at solving complex problems, optimizing database interactions, and ensuring applications run seamlessly under the hood. While I have experience working with front-end technologies, I feel most at home building the logic, infrastructure, and core features that power an app behind the scenes.
            </Typography>
            <Typography variant="body1" component="p" sx={{ marginBottom: 2 }}>
              While I've dabbled in the front-end using technologies like React and Blazor, my true passion lies in crafting solid backend architectures. On the Python side, Django is one of my favorites for quickly setting up clean and maintainable backends. I also have experience with Unity3D for game development, where I focus more on the technical side of creating interactive experiences rather than the artistic elements.
            </Typography>
            <Typography variant="body1" component="p" sx={{ marginBottom: 2 }}>
              Other skills include working with Docker as well as Kubernetes for containerization. I have used MS Azure services for cloud-focused solutions. EFCore + SQLServer as well as PostgreSQL are my go to DB tools. I'm proficient in using CLI's such as Powershell and Gitbash, and I am also well-versed in using Github for verison control. I am a quick learner, dedicated to constant improvement and I'm willing to learn any new technologies required to a proficient level.  
            </Typography>
            <Typography variant="body1" component="p" sx={{ marginBottom: 2 }}>
              I'm all about solving problems with robust solutions. Whether I'm working on a complex API, optimizing database queries, or improving system performance, my focus is always on creating something scalable, maintainable, and efficient. I'm constantly striving to level up my skills and stay ahead of the curve when it comes to backend technologies.
            </Typography>
            <Typography variant="body1" component="p" sx={{ marginBottom: 2 }}>
              Currently, I'm seeking on-site or hybrid opportunities in major cities such as Cape Town, Johannesburg and Pretoria, any of which I'm willing to relocate to if necessary. I am also open to being part of a fully-remote team, as I am very organized and can work independently to a highly-effective extent. Feel free to browse my projects below and/or download my resume in the header.
            </Typography>
          </Box>

          {/* Avatar Section */}
          <Avatar
            src="https://via.placeholder.com/150" // Replace with your image URL
            alt="Steven's Avatar"
            sx={{ width: 205, height: 205, flexShrink: 0, marginRight: -8 }}
          />
        </Box>
      </Container>

    </Box>
    </Paper>
    </div>
  );
};

export default AboutMe;