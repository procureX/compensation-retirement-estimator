namespace RetirementProjectionCalculator.Api.DTOs {
    public class CreateProjectionDto {
        public int UserId { get; set; }
        public int RetirementAge { get; set; }
        public decimal AnnualContribution { get; set; }
        public decimal ExpectedReturnRate { get; set; }
    }
}