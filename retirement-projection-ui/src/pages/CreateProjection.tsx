import { useState } from "react";
import { useParams, useNavigate, Link } from "react-router-dom";
import { createProjection } from "../apis/projectionApi";

export default function CreateProjection() {
  const { id } = useParams();
  const navigate = useNavigate();

  const [retirementAge, setRetirementAge] = useState(65);
  const [annualContribution, setAnnualContribution] = useState(5000);
  const [expectedReturnRate, setExpectedReturnRate] = useState(0.07);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setLoading(true);

    try {
      await createProjection({
        userId: Number(id),
        retirementAge,
        annualContribution,
        expectedReturnRate,
      });

      navigate(`/users/${id}`);
    } catch (err) {
      console.error(err);
      setError("Failed to create projection.");
    } finally {
      setLoading(false);
    }
  };

  return (
    <div style={{ padding: "2rem" }}>
      <Link to={`/users/${id}`} style={{ textDecoration: "none" }}>
        ← Back to User
      </Link>

      <h1>Create Projection</h1>

      {error && <p style={{ color: "red" }}>{error}</p>}

      <form
        onSubmit={handleSubmit}
        style={{
          marginTop: "2rem",
          display: "flex",
          flexDirection: "column",
          gap: "1rem",
          maxWidth: "400px",
        }}
      >
        <label>
          Retirement Age:
          <input
            type="number"
            value={retirementAge}
            onChange={(e) => setRetirementAge(Number(e.target.value))}
            min={40}
            max={80}
            required
          />
        </label>

        <label>
          Annual Contribution:
          <input
            type="number"
            value={annualContribution}
            onChange={(e) => setAnnualContribution(Number(e.target.value))}
            min={0}
            required
          />
        </label>

        <label>
          Expected Return Rate (e.g., 0.07):
          <input
            type="number"
            step="0.01"
            value={expectedReturnRate}
            onChange={(e) => setExpectedReturnRate(Number(e.target.value))}
            min={0}
            max={0.20}
            required
          />
        </label>

        <button
          type="submit"
          disabled={loading}
          style={{
            padding: "0.75rem",
            background: "#007bff",
            color: "white",
            borderRadius: "6px",
            border: "none",
            cursor: "pointer",
          }}
        >
          {loading ? "Saving..." : "Create Projection"}
        </button>
      </form>
    </div>
  );
}
