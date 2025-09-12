using CollegeManagementSystem.Models;
using CollegeManagementSystem.Models.RequestModels;
using CollegeManagementSystem.Repository.Interfaces;
using CollegeManagementSystem.Services.Interfaces;

namespace CollegeManagementSystem.Services
{
    public class CollegeService : ICollegeService
    {
        private readonly ICollegeRepository _collegeRepository;

        public CollegeService(ICollegeRepository collegeRepository)
        {
            _collegeRepository = collegeRepository;
        }

        public async Task<List<College>> GetAllCollegesAsync()
        {
            return await _collegeRepository.GetAllAsync();
        }

        public async Task<College?> GetCollegeByIdAsync(string id)
        {
            return await _collegeRepository.GetByIdAsync(id);
        }

        public async Task<College> CreateCollegeAsync(CreateCollegeRequest request)
        {
            var college = new College
            {
                Name = request.Name,
                Address = request.Address,
                EstablishedYear = request.EstablishedYear,
                ContactNumber = request.ContactNumber,
                Email = request.Email,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            return await _collegeRepository.CreateAsync(college);
        }

        public async Task<College?> UpdateCollegeAsync(string id, UpdateCollegeRequest request)
        {
            var existingCollege = await _collegeRepository.GetByIdAsync(id);
            if (existingCollege == null) return null;

            existingCollege.Name = request.Name;
            existingCollege.Address = request.Address;
            existingCollege.EstablishedYear = request.EstablishedYear;
            existingCollege.ContactNumber = request.ContactNumber;
            existingCollege.Email = request.Email;
            existingCollege.UpdatedAt = DateTime.UtcNow;

            return await _collegeRepository.UpdateAsync(id, existingCollege);
        }

        public async Task<bool> DeleteCollegeAsync(string id)
        {
            return await _collegeRepository.DeleteAsync(id);
        }

        public async Task<List<College>> SearchCollegesByNameAsync(string name)
        {
            return await _collegeRepository.GetCollegesByNameAsync(name);
        }
    }

    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<List<Course>> GetAllCoursesAsync()
        {
            return await _courseRepository.GetAllAsync();
        }

        public async Task<Course?> GetCourseByIdAsync(string id)
        {
            return await _courseRepository.GetByIdAsync(id);
        }

        public async Task<Course> CreateCourseAsync(CreateCourseRequest request)
        {
            var course = new Course
            {
                Name = request.Name,
                DurationYears = request.DurationYears,
                CollegeId = request.CollegeId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            return await _courseRepository.CreateAsync(course);
        }

        public async Task<List<Course>> GetCoursesByCollegeIdAsync(string collegeId)
        {
            return await _courseRepository.GetCoursesByCollegeIdAsync(collegeId);
        }

        public async Task<bool> DeleteCourseAsync(string id)
        {
            return await _courseRepository.DeleteAsync(id);
        }
    }
}