import { useEffect, useState } from "react";
import { useParams, Link } from "react-router-dom";
import { getUserById } from "../apis/userApi";
import { getProjectionsForUser } from "../apis/projectionApi";
import type { User } from "../apis/userApi";
import ProjectionChart from "../components/ProjectionChart";

export default function UserDetail() {
  const { id } = useParams();

  const [user, setUser] = useState<User | null>(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  const [projections, setProjections] = useState<any[]>([]);
  const [projLoading, setProjLoading] = useState(true);

  // Load user
  useEffect(() => {
    if (!id) return;

    getUserById(Number(id))
      .then((data) => {
        setUser(data);
        setLoading(false);
      })
      .catch((err) => {
        console.error("User Detail Error:", err);
        setError("Unable to load user.");
        setLoading(false);
      });
  }, [id]);

  // Load projections
  useEffect(() => {
    if (!id) return;

    getProjectionsForUser(Number(id))
      .then((data) => {
        setProjections(data);
        setProjLoading(false);
      })
      .catch((err) => {
        console.error("Projection Load Error:", err);
        setProjLoading(false);
      });
  }, [id]);

  if (loading) return <p>Loading user...</p>;
  if (error) return <p>{error}</p>;
  if (!user) return <p>No user found.</p>;

  return (
    <div style={{ padding: "2rem" }}>
      <Link to="/" style={{ textDecoration: "none" }}>
        ← Back to Dashboard
      </Link>

      <h1>{user.name}</h1>

      <div style={{ marginTop: "1rem" }}>
        <p><strong>Age:</strong> {user.age}</p>
        <p><strong>Current Salary:</strong> ${user.currentSalary.toLocaleString()}</p>
      </div>

      <hr style={{ margin: "2rem 0" }} />

      <h2>Retirement Projections</h2>
      {!projLoading && projections.length > 0 && (
        <div style={{ marginTop: "1rem" }}>
          {projections.map((p) => (
            <div key={p.id} style={{ marginBottom: "2rem", minHeight: "300px" }}>
              <h3>Projection #{p.id}</h3>
              <ProjectionChart years={p.years} balances={p.balances} />
            </div>
          ))}
        </div>
      )}

      <Link
        to={`/users/${user.id}/projections/new`}
        style={{
          display: "inline-block",
          marginTop: "1rem",
          padding: "0.75rem 1rem",
          background: "#007bff",
          color: "white",
          borderRadius: "6px",
          textDecoration: "none",
        }}
      >
        Create New Projection
      </Link>
    </div>
  );
}
