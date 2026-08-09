import { Routes, Route } from "react-router-dom";
import UserDashboard from "./pages/UserDashboard";
import UserDetail from "./pages/UserDetail";

function App() {
  return (
    <Routes>
      <Route path="/" element={<UserDashboard />} />
      <Route path="/users/:id" element={<UserDetail />} />
    </Routes>
  );
}

export default App;
