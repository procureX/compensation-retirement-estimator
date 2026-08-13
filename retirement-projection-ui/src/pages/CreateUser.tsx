import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { createUser } from "../apis/userApi";

export default function CreateUser() {
  const navigate = useNavigate();

  const [name, setName] = useState("");
  const [age, setAge] = useState(18);
  const [currentSalary, setSalary] = useState(50000);
  const [error, setError] = useState<string | null>(null);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    try {
      const user = await createUser({ name, age, currentSalary });
      navigate(`/users/${user.id}`);
    } catch {
      setError("Failed to create user.");
    }
  };

  return (
    <div style={{ padding: "2rem" }}>
      <h1>Create User</h1>
      {error && <p style={{ color: "red" }}>{error}</p>}

      <form onSubmit={handleSubmit} style={{ display: "flex", flexDirection: "column", gap: "1rem", maxWidth: "400px" }}>
        <label>
          Name:
          <input value={name} onChange={(e) => setName(e.target.value)} required />
        </label>

        <label>
          Age:
          <input type="number" value={age} onChange={(e) => setAge(Number(e.target.value))} required />
        </label>

        <label>
          Current Salary:
          <input type="number" value={currentSalary} onChange={(e) => setSalary(Number(e.target.value))} required />
        </label>

        <button type="submit">Create User</button>
      </form>
    </div>
  );
}
