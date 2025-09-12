using MongoDB.Driver;
using CollegeManagementSystem.Models;

namespace CollegeManagementSystem.Db
{
    public interface IDbContext
    {
        IMongoCollection<College> Colleges { get; }
        IMongoCollection<Course> Courses { get; }
        IMongoCollection<Branch> Branches { get; }
        IMongoCollection<Student> Students { get; }
        IMongoCollection<Subject> Subjects { get; }
        IMongoCollection<FeeStructure> FeeStructures { get; }
        IMongoCollection<Exam> Exams { get; }
    }

    public class DbContext : IDbContext
    {
        private readonly IMongoDatabase _database;

        public DbContext(IMongoClient mongoClient, DbConfigs dbConfigs)
        {
            _database = mongoClient.GetDatabase(dbConfigs.DatabaseName);
        }

        public IMongoCollection<College> Colleges =>
            _database.GetCollection<College>(CollectionNames.Colleges);

        public IMongoCollection<Course> Courses =>
            _database.GetCollection<Course>(CollectionNames.Courses);

        public IMongoCollection<Branch> Branches =>
            _database.GetCollection<Branch>(CollectionNames.Branches);

        public IMongoCollection<Student> Students =>
            _database.GetCollection<Student>(CollectionNames.Students);

        public IMongoCollection<Subject> Subjects =>
            _database.GetCollection<Subject>(CollectionNames.Subjects);

        public IMongoCollection<FeeStructure> FeeStructures =>
            _database.GetCollection<FeeStructure>(CollectionNames.FeeStructures);

        public IMongoCollection<Exam> Exams =>
            _database.GetCollection<Exam>(CollectionNames.Exams);
    }
}