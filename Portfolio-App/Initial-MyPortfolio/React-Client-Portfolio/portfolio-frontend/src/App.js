import React from "react";
import { Routes, Route } from "react-router-dom"; // Import routing tools
import HomePage from "./Assets/Pages/HomePage"; // Import HomePage
import TestPage from "./Assets/Pages/TestPage"; // Import HomePage

const App = ({ darkMode, setDarkMode }) => {
  return (
    <div>
      <main>
        {/* Define routes for different pages */}
        <Routes>
          <Route path="/" element={<HomePage darkMode={darkMode} setDarkMode={setDarkMode} />} /> {/* Home page route */}
          <Route path="/test" element={<TestPage />} /> {/* Route for Test Page (TestPage.js) no clickable link / TBD */}
        </Routes>
      </main>
    </div>
  );
};

export default App;
