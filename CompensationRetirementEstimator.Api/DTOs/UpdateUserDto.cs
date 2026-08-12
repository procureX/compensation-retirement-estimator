namespace CompensationRetirementEstimator.Api.DTOs {
    public class UpdateUserDto {
        public required string Name { get; set; }
        public required int Age { get; set; }
        public required decimal CurrentSalary { get; set; }
    }
}
