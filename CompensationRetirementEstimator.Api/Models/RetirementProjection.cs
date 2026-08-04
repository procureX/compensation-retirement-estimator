namespace CompensationRetirementEstimator.Api.Models;

public class RetirementProjection
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public decimal ContributionRate { get; set; }
    public decimal EmployerMatchRate { get; set; }
    public decimal InvestmentGrowthRate { get; set; }
    public int RetirementAge { get; set; }
    public decimal ProjectedMonthlyIncome { get; set; }
}
