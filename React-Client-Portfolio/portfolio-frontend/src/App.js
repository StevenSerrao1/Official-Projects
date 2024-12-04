import React from "react";
import { Routes, Route, Link } from "react-router-dom"; // Import routing tools
import TestPage from "./Assets/Pages/TestPage"; // Import TestPage or other pages if needed
import HomePage from "./Assets/Pages/HomePage";

const App = () => {
  return (
    <div>
      <main>
        {/* Define routes for different pages */}
        <Routes>
          <Route path="/" element={<HomePage />} /> {/* Serve HomePage.js content as home */}
          <Route path="/test" element={<TestPage />} /> {/* Route for Test Page (TestPage.js) no clickable link / TBD */}
        </Routes>
      </main>
    </div>
  );
};

export default App;
