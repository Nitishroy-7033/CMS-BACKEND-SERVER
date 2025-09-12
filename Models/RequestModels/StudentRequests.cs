namespace CollegeManagementSystem.Models.RequestModels
{
    public class CreateStudentRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string CollegeId { get; set; } = string.Empty;
        public string CourseId { get; set; } = string.Empty;
        public string BranchId { get; set; } = string.Empty;
        public string StudentId { get; set; } = string.Empty;
        public int Year { get; set; } = 1;
    }

    public class UpdateStudentRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string CollegeId { get; set; } = string.Empty;
        public string CourseId { get; set; } = string.Empty;
        public string BranchId { get; set; } = string.Empty;
        public int Year { get; set; } = 1;
    }
}