import { API_URL } from "./config";

export interface ProjectionInput {
  userId: number;
  retirementAge: number;
  annualContribution: number;
  expectedReturnRate: number;
}

export async function createProjection(input: ProjectionInput) {
  const res = await fetch(`${API_URL}/Projections`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(input),
  });

  if (!res.ok) throw new Error("Failed to create projection");
  return res.json();
}
