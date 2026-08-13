import { Routes, Route } from "react-router-dom";
import UserDashboard from "./pages/UserDashboard";
import UserDetail from "./pages/UserDetail";
import CreateProjection from "./pages/CreateProjection";
import CreateUser from "./pages/CreateUser";

function App() {
  return (
    <Routes>
      <Route path="/" element={<UserDashboard />} />
      <Route path="/users/:id" element={<UserDetail />} />
      <Route path="/users/:id/projections/new" element={<CreateProjection />} />
      <Route path="/users/new" element={<CreateUser />} />
    </Routes>
  );
}

export default App;
