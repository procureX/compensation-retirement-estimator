namespace RetirementProjectionCalculator.Api.DTOs {
    public class UpdateUserDto {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required int Age { get; set; }
        public required decimal CurrentSalary { get; set; }
    }
}
