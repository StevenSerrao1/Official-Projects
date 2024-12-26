import React from "react";
import { Routes, Route } from "react-router-dom"; // Import routing tools
import HomePage from "./Assets/Pages/HomePage"; // Import HomePage

const App = ({ darkMode, setDarkMode }) => {
  return (
    <div>
      <main>
        {/* Define routes for different pages */}
        <Routes>
          <Route path="/" element={<HomePage darkMode={darkMode} setDarkMode={setDarkMode} />} /> {/* Home page route */}
        </Routes>
      </main>
    </div>
  );
};

export default App;
