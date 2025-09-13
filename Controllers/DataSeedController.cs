using Microsoft.AspNetCore.Mvc;
using CollegeManagementSystem.Data;

namespace CollegeManagementSystem.Controllers
{
    /// <summary>
    /// Data seeding operations for testing and development
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class DataSeedController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;

        public DataSeedController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Seed the database with dummy data including 200 students
        /// </summary>
        /// <returns>Seeding status</returns>
        /// <response code="200">Data seeding completed successfully</response>
        /// <response code="400">Data seeding failed</response>
        [HttpPost("seed")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> SeedData()
        {
            try
            {
                await DataSeeder.SeedDataAsync(_serviceProvider);
                return Ok(new
                {
                    Message = "Data seeding completed successfully!",
                    Details = "Created colleges, courses, branches, subjects, fee structures, 200 students, and exams",
                    Timestamp = DateTime.UtcNow
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = "Data seeding failed",
                    Error = ex.Message,
                    Timestamp = DateTime.UtcNow
                });
            }
        }

        /// <summary>
        /// Get database statistics after seeding
        /// </summary>
        /// <returns>Database statistics</returns>
        [HttpGet("stats")]
        [ProducesResponseType(200)]
        public async Task<ActionResult> GetDatabaseStats()
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();

                var collegeService = scope.ServiceProvider.GetRequiredService<CollegeManagementSystem.Services.Interfaces.ICollegeService>();
                var courseService = scope.ServiceProvider.GetRequiredService<CollegeManagementSystem.Services.Interfaces.ICourseService>();
                var branchService = scope.ServiceProvider.GetRequiredService<CollegeManagementSystem.Services.Interfaces.IBranchService>();
                var studentService = scope.ServiceProvider.GetRequiredService<CollegeManagementSystem.Services.Interfaces.IStudentService>();
                var subjectService = scope.ServiceProvider.GetRequiredService<CollegeManagementSystem.Services.Interfaces.ISubjectService>();
                var feeStructureService = scope.ServiceProvider.GetRequiredService<CollegeManagementSystem.Services.Interfaces.IFeeStructureService>();
                var examService = scope.ServiceProvider.GetRequiredService<CollegeManagementSystem.Services.Interfaces.IExamService>();

                var stats = new
                {
                    Colleges = (await collegeService.GetAllCollegesAsync()).Count,
                    Courses = (await courseService.GetAllCoursesAsync()).Count,
                    Branches = (await branchService.GetAllBranchesAsync()).Count,
                    Students = (await studentService.GetAllStudentsAsync()).Count,
                    Subjects = (await subjectService.GetAllSubjectsAsync()).Count,
                    FeeStructures = (await feeStructureService.GetAllFeeStructuresAsync()).Count,
                    Exams = (await examService.GetAllExamsAsync()).Count,
                    Timestamp = DateTime.UtcNow
                };

                return Ok(stats);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = "Failed to get database statistics",
                    Error = ex.Message
                });
            }
        }
    }
}