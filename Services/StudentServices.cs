using CollegeManagementSystem.Models;
using CollegeManagementSystem.Models.RequestModels;
using CollegeManagementSystem.Repository.Interfaces;
using CollegeManagementSystem.Services.Interfaces;

namespace CollegeManagementSystem.Services
{
    public class BranchService : IBranchService
    {
        private readonly IBranchRepository _branchRepository;

        public BranchService(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public async Task<List<Branch>> GetAllBranchesAsync()
        {
            return await _branchRepository.GetAllAsync();
        }

        public async Task<Branch?> GetBranchByIdAsync(string id)
        {
            return await _branchRepository.GetByIdAsync(id);
        }

        public async Task<Branch> CreateBranchAsync(CreateBranchRequest request)
        {
            var branch = new Branch
            {
                Name = request.Name,
                CourseId = request.CourseId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            return await _branchRepository.CreateAsync(branch);
        }

        public async Task<List<Branch>> GetBranchesByCourseIdAsync(string courseId)
        {
            return await _branchRepository.GetBranchesByCourseIdAsync(courseId);
        }

        public async Task<bool> DeleteBranchAsync(string id)
        {
            return await _branchRepository.DeleteAsync(id);
        }
    }

    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _studentRepository.GetAllAsync();
        }

        public async Task<Student?> GetStudentByIdAsync(string id)
        {
            return await _studentRepository.GetByIdAsync(id);
        }

        public async Task<Student> CreateStudentAsync(CreateStudentRequest request)
        {
            var student = new Student
            {
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
                Address = request.Address,
                CollegeId = request.CollegeId,
                CourseId = request.CourseId,
                BranchId = request.BranchId,
                StudentId = request.StudentId,
                Year = request.Year,
                EnrollmentDate = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            return await _studentRepository.CreateAsync(student);
        }

        public async Task<Student?> UpdateStudentAsync(string id, UpdateStudentRequest request)
        {
            var existingStudent = await _studentRepository.GetByIdAsync(id);
            if (existingStudent == null) return null;

            existingStudent.Name = request.Name;
            existingStudent.Email = request.Email;
            existingStudent.Phone = request.Phone;
            existingStudent.Address = request.Address;
            existingStudent.CollegeId = request.CollegeId;
            existingStudent.CourseId = request.CourseId;
            existingStudent.BranchId = request.BranchId;
            existingStudent.Year = request.Year;
            existingStudent.UpdatedAt = DateTime.UtcNow;

            return await _studentRepository.UpdateAsync(id, existingStudent);
        }

        public async Task<bool> DeleteStudentAsync(string id)
        {
            return await _studentRepository.DeleteAsync(id);
        }

        public async Task<List<Student>> GetStudentsByCollegeIdAsync(string collegeId)
        {
            return await _studentRepository.GetStudentsByCollegeIdAsync(collegeId);
        }

        public async Task<List<Student>> GetStudentsByBranchIdAsync(string branchId)
        {
            return await _studentRepository.GetStudentsByBranchIdAsync(branchId);
        }

        public async Task<Student?> GetStudentByStudentIdAsync(string studentId)
        {
            return await _studentRepository.GetStudentByStudentIdAsync(studentId);
        }
    }
}