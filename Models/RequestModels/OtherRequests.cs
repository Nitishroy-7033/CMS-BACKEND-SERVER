namespace CollegeManagementSystem.Models.RequestModels
{
    public class CreateCourseRequest
    {
        public string Name { get; set; } = string.Empty;
        public int DurationYears { get; set; }
        public string CollegeId { get; set; } = string.Empty;
    }

    public class CreateBranchRequest
    {
        public string Name { get; set; } = string.Empty;
        public string CourseId { get; set; } = string.Empty;
    }

    public class CreateSubjectRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string BranchId { get; set; } = string.Empty;
        public int Year { get; set; } = 1;
        public int Semester { get; set; } = 1;
        public int Credits { get; set; } = 3;
    }

    public class CreateFeeStructureRequest
    {
        public string BranchId { get; set; } = string.Empty;
        public decimal TotalFee { get; set; }
        public decimal YearlyFee { get; set; }
        public decimal SemesterFee { get; set; }
        public string Currency { get; set; } = "INR";
    }

    public class CreateExamRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string BranchId { get; set; } = string.Empty;
        public string SubjectId { get; set; } = string.Empty;
        public int Year { get; set; }
        public int Semester { get; set; }
        public DateTime ExamDate { get; set; }
        public int DurationMinutes { get; set; }
        public int MaxMarks { get; set; } = 100;
    }
}