/*function App() {
  return (
    <div>
      <h1>Retirement Estimator UI</h1>
      <p>Frontend initialized successfully.</p>
    </div>
  );
}

export default App;
*/
import { useEffect, useState } from "react";
import { getUsers } from "./api";

function App() {
  const [users, setUsers] = useState<any[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    getUsers()
      .then((data) => {
        console.log("API Response:", data);
        setUsers(data);
        setLoading(false);
      })
      .catch((err) => {
        console.error("API Error:", err);
        setLoading(false);
      });
  }, []);

  if (loading) return <p>Loading...</p>;

  return (
    <div style={{ padding: "2rem" }}>
      <h1>API Test</h1>
      <pre>{JSON.stringify(users, null, 2)}</pre>
    </div>
  );
}

export default App;
