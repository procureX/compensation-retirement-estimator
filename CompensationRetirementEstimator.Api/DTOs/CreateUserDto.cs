namespace CompensationRetirementEstimator.Api.DTOs {
    public class CreateUserDto {
        public required string Name { get; set; }
        public required int Age { get; set; }
        public required decimal CurrentSalary { get; set; }
    }
}
