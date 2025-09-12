using CollegeManagementSystem.Models;
using CollegeManagementSystem.Models.RequestModels;

namespace CollegeManagementSystem.Services.Interfaces
{
    public interface ICollegeService
    {
        Task<List<College>> GetAllCollegesAsync();
        Task<College?> GetCollegeByIdAsync(string id);
        Task<College> CreateCollegeAsync(CreateCollegeRequest request);
        Task<College?> UpdateCollegeAsync(string id, UpdateCollegeRequest request);
        Task<bool> DeleteCollegeAsync(string id);
        Task<List<College>> SearchCollegesByNameAsync(string name);
    }

    public interface ICourseService
    {
        Task<List<Course>> GetAllCoursesAsync();
        Task<Course?> GetCourseByIdAsync(string id);
        Task<Course> CreateCourseAsync(CreateCourseRequest request);
        Task<List<Course>> GetCoursesByCollegeIdAsync(string collegeId);
        Task<bool> DeleteCourseAsync(string id);
    }

    public interface IBranchService
    {
        Task<List<Branch>> GetAllBranchesAsync();
        Task<Branch?> GetBranchByIdAsync(string id);
        Task<Branch> CreateBranchAsync(CreateBranchRequest request);
        Task<List<Branch>> GetBranchesByCourseIdAsync(string courseId);
        Task<bool> DeleteBranchAsync(string id);
    }

    public interface IStudentService
    {
        Task<List<Student>> GetAllStudentsAsync();
        Task<Student?> GetStudentByIdAsync(string id);
        Task<Student> CreateStudentAsync(CreateStudentRequest request);
        Task<Student?> UpdateStudentAsync(string id, UpdateStudentRequest request);
        Task<bool> DeleteStudentAsync(string id);
        Task<List<Student>> GetStudentsByCollegeIdAsync(string collegeId);
        Task<List<Student>> GetStudentsByBranchIdAsync(string branchId);
        Task<Student?> GetStudentByStudentIdAsync(string studentId);
    }
}