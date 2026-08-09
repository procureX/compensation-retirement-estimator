import { Routes, Route } from "react-router-dom";
import UserDashboard from "./pages/UserDashboard";

function App() {
  return (
    <Routes>
      <Route path="/" element={<UserDashboard />} />
      <Route path="/users/:id" element={<div>User Detail Page Coming Soon</div>} />
    </Routes>
  );
}

export default App;
