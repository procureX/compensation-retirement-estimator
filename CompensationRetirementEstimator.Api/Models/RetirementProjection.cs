namespace CompensationRetirementEstimator.Api.Models;

public class RetirementProjection {
    public int Id { get; set; }

    // Foreign key to User
    public int UserId { get; set; }
    public User? User { get; set; }

    // Projection inputs
    public decimal ContributionRate { get; set; }
    public decimal EmployerMatchRate { get; set; }
    public decimal InvestmentGrowthRate { get; set; }
    public int RetirementAge { get; set; }

    // Projection outputs
    public decimal ProjectedMonthlyIncome { get; set; }
    public decimal RetirementSalary { get; set; }
}
