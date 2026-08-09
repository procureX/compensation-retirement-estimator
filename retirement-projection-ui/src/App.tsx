import { Routes, Route } from "react-router-dom";
import UserDashboard from "./pages/UserDashboard";
import UserDetail from "./pages/UserDetail";
import CreateProjection from "./pages/CreateProjection";

function App() {
  return (
    <Routes>
      <Route path="/" element={<UserDashboard />} />
      <Route path="/users/:id" element={<UserDetail />} />
      <Route path="/users/:id/projections/new" element={<CreateProjection />} />
    </Routes>
  );
}

export default App;
