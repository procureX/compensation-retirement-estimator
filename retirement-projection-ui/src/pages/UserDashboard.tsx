import { useEffect, useState } from "react";
import { getUsers } from "../apis/userApi";
import type { User } from "../apis/userApi";
import { Link } from "react-router-dom";

export default function UserDashboard() {
  const [users, setUsers] = useState<User[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    getUsers()
      .then((data) => {
        setUsers(data);
        setLoading(false);
      })
      .catch((err) => {
        console.error("Dashboard Error:", err);
        setLoading(false);
      });
  }, []);

  if (loading) return <p>Loading users...</p>;

  return (
    <div style={{ padding: "2rem" }}>
      <h1>User Dashboard</h1>
      <p>Select a user to view retirement projections.</p>

      <Link to="/users/new">
        <button>Create User</button>
      </Link>

      <div
        style={{
          marginTop: "2rem",
          display: "grid",
          gap: "1rem",
          gridTemplateColumns: "repeat(auto-fill, minmax(250px, 1fr))",
        }}
      >
        {users.map((u) => (
          <Link
            key={u.id}
            to={`/users/${u.id}`}
            style={{
              padding: "1rem",
              border: "1px solid #ccc",
              borderRadius: "8px",
              textDecoration: "none",
              color: "black",
              background: "#f9f9f9",
            }}
          >
            <h3>{u.name}</h3>
            <p>Age: {u.age}</p>
            <p>Salary: ${u.currentSalary.toLocaleString()}</p>
          </Link>
        ))}
      </div>
    </div>
  );
}
