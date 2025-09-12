using MongoDB.Driver;
using CollegeManagementSystem.Models;
using CollegeManagementSystem.Repository.Interfaces;
using CollegeManagementSystem.Db;

namespace CollegeManagementSystem.Repository
{
    public class CollegeRepository : GenericRepository<College>, ICollegeRepository
    {
        public CollegeRepository(IDbContext dbContext) : base(dbContext.Colleges)
        {
        }

        public async Task<List<College>> GetCollegesByNameAsync(string name)
        {
            var filter = Builders<College>.Filter.Regex("name", new MongoDB.Bson.BsonRegularExpression(name, "i"));
            return await _collection.Find(filter).ToListAsync();
        }
    }

    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(IDbContext dbContext) : base(dbContext.Courses)
        {
        }

        public async Task<List<Course>> GetCoursesByCollegeIdAsync(string collegeId)
        {
            var filter = Builders<Course>.Filter.Eq("college_id", collegeId);
            return await _collection.Find(filter).ToListAsync();
        }
    }

    public class BranchRepository : GenericRepository<Branch>, IBranchRepository
    {
        public BranchRepository(IDbContext dbContext) : base(dbContext.Branches)
        {
        }

        public async Task<List<Branch>> GetBranchesByCourseIdAsync(string courseId)
        {
            var filter = Builders<Branch>.Filter.Eq("course_id", courseId);
            return await _collection.Find(filter).ToListAsync();
        }
    }

    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(IDbContext dbContext) : base(dbContext.Students)
        {
        }

        public async Task<List<Student>> GetStudentsByCollegeIdAsync(string collegeId)
        {
            var filter = Builders<Student>.Filter.Eq("college_id", collegeId);
            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<List<Student>> GetStudentsByBranchIdAsync(string branchId)
        {
            var filter = Builders<Student>.Filter.Eq("branch_id", branchId);
            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<Student?> GetStudentByStudentIdAsync(string studentId)
        {
            var filter = Builders<Student>.Filter.Eq("student_id", studentId);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }
    }
}