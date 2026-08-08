const API_URL = "http://localhost:5116/api";

export interface User {
  id: number;
  name: string;
  age: number;
  currentSalary: number;
}

export interface Projection {
  id: number;
  userId: number;
  currentAge: number;
  retirementAge: number;
  currentSavings: number;
  annualContribution: number;
  annualReturnRate: number;
  projectedSavings: number;
}

export async function getUsers(): Promise<User[]> {
  const res = await fetch(`${API_URL}/Users`);
  return res.json();
}

export async function getUserById(id: number): Promise<User> {
  const res = await fetch(`${API_URL}/Users/${id}`);
  return res.json();
}

export async function getUserProjections(id: number): Promise<Projection[]> {
  const res = await fetch(`${API_URL}/Users/${id}/projections`);
  return res.json();
}

export async function createUser(user: Partial<User>): Promise<User> {
  const res = await fetch(`${API_URL}/Users`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(user),
  });
  return res.json();
}

export async function createProjection(projection: Partial<Projection>): Promise<Projection> {
  const res = await fetch(`${API_URL}/RetirementProjections`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(projection),
  });
  return res.json();
}
