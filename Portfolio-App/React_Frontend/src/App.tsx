import "./App.css";
import HeaderComponent from "./Components/Header/Header";
import LayoutDynamic from "./Components/LayoutDynamic/LayoutDynamic";
import AdminPanel from "./Routes/AdminRoutes/adminpanel";
import CreateProject from "./Routes/AdminRoutes/create_project";
import DeleteProject from "./Routes/AdminRoutes/delete_project";
import UpdateProject from "./Routes/AdminRoutes/update_project";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Footer from "./Components/Sections/Footer/Footer";
import FetchProjectsJSON from "./Routes/AltRoutes/fetchprojects-json";

function App() {
  return (
    <Router>
      <div className="app-wrapper"> {/* flex wrapper */}
        <HeaderComponent />
        <div className="app-content"> {/* grows to fill space */}
          <Routes> 
            <Route path="/admin" element={<AdminPanel />} />
            <Route path="/admin/createproject" element={<CreateProject />} />
            <Route path="/admin/deleteproject/:id" element={<DeleteProject />} />
            <Route path="/admin/loadadminprojects" element={<FetchProjectsJSON />} />
            <Route path="/admin/updateproject/:id" element={<UpdateProject />} />
            <Route path="/" element={<LayoutDynamic />} />
          </Routes>
        </div>
        <Footer />
      </div>
    </Router>
  );
}


export default App;
