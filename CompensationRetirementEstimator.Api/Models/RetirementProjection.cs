namespace CompensationRetirementEstimator.Api.Models;

public class RetirementProjection {
    public int Id { get; set; }

    public int UserId { get; set; }
    public User? User { get; set; }

    // Projection inputs
    public decimal AnnualContribution { get; set; }
    public decimal ExpectedReturnRate { get; set; }
    public int RetirementAge { get; set; }

    // Projection outputs
    public List<int> Years { get; set; } = new();
    public List<decimal> Balances { get; set; } = new();
}
