using CollegeManagementSystem.Models;

namespace CollegeManagementSystem.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(string id);
        Task<T> CreateAsync(T entity);
        Task<T?> UpdateAsync(string id, T entity);
        Task<bool> DeleteAsync(string id);
    }

    public interface ICollegeRepository : IGenericRepository<College>
    {
        Task<List<College>> GetCollegesByNameAsync(string name);
    }

    public interface ICourseRepository : IGenericRepository<Course>
    {
        Task<List<Course>> GetCoursesByCollegeIdAsync(string collegeId);
    }

    public interface IBranchRepository : IGenericRepository<Branch>
    {
        Task<List<Branch>> GetBranchesByCourseIdAsync(string courseId);
    }

    public interface IStudentRepository : IGenericRepository<Student>
    {
        Task<List<Student>> GetStudentsByCollegeIdAsync(string collegeId);
        Task<List<Student>> GetStudentsByBranchIdAsync(string branchId);
        Task<Student?> GetStudentByStudentIdAsync(string studentId);
    }

    public interface ISubjectRepository : IGenericRepository<Subject>
    {
        Task<List<Subject>> GetSubjectsByBranchIdAsync(string branchId);
        Task<List<Subject>> GetSubjectsByYearAndSemesterAsync(string branchId, int year, int semester);
    }

    public interface IFeeStructureRepository : IGenericRepository<FeeStructure>
    {
        Task<FeeStructure?> GetFeeStructureByBranchIdAsync(string branchId);
    }

    public interface IExamRepository : IGenericRepository<Exam>
    {
        Task<List<Exam>> GetExamsByBranchIdAsync(string branchId);
        Task<List<Exam>> GetExamsBySubjectIdAsync(string subjectId);
        Task<List<Exam>> GetExamsByYearAndSemesterAsync(string branchId, int year, int semester);
    }
}