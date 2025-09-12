namespace CollegeManagementSystem.Db
{
    public class DbConfigs
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }

    public class CollectionNames
    {
        public const string Colleges = "colleges";
        public const string Courses = "courses";
        public const string Branches = "branches";
        public const string Students = "students";
        public const string Subjects = "subjects";
        public const string FeeStructures = "fee_structures";
        public const string Exams = "exams";
    }
}