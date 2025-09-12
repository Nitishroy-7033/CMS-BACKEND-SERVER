using Microsoft.AspNetCore.Mvc;
using CollegeManagementSystem.Models;
using CollegeManagementSystem.Models.RequestModels;
using CollegeManagementSystem.Services.Interfaces;

namespace CollegeManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Course>>> GetAllCourses()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourseById(string id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null)
                return NotFound($"Course with ID {id} not found");

            return Ok(course);
        }

        [HttpPost]
        public async Task<ActionResult<Course>> CreateCourse([FromBody] CreateCourseRequest request)
        {
            var course = await _courseService.CreateCourseAsync(request);
            return CreatedAtAction(nameof(GetCourseById), new { id = course.Id }, course);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCourse(string id)
        {
            var result = await _courseService.DeleteCourseAsync(id);
            if (!result)
                return NotFound($"Course with ID {id} not found");

            return NoContent();
        }

        [HttpGet("college/{collegeId}")]
        public async Task<ActionResult<List<Course>>> GetCoursesByCollegeId(string collegeId)
        {
            var courses = await _courseService.GetCoursesByCollegeIdAsync(collegeId);
            return Ok(courses);
        }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class BranchController : ControllerBase
    {
        private readonly IBranchService _branchService;

        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Branch>>> GetAllBranches()
        {
            var branches = await _branchService.GetAllBranchesAsync();
            return Ok(branches);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Branch>> GetBranchById(string id)
        {
            var branch = await _branchService.GetBranchByIdAsync(id);
            if (branch == null)
                return NotFound($"Branch with ID {id} not found");

            return Ok(branch);
        }

        [HttpPost]
        public async Task<ActionResult<Branch>> CreateBranch([FromBody] CreateBranchRequest request)
        {
            var branch = await _branchService.CreateBranchAsync(request);
            return CreatedAtAction(nameof(GetBranchById), new { id = branch.Id }, branch);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBranch(string id)
        {
            var result = await _branchService.DeleteBranchAsync(id);
            if (!result)
                return NotFound($"Branch with ID {id} not found");

            return NoContent();
        }

        [HttpGet("course/{courseId}")]
        public async Task<ActionResult<List<Branch>>> GetBranchesByCourseId(string courseId)
        {
            var branches = await _branchService.GetBranchesByCourseIdAsync(courseId);
            return Ok(branches);
        }
    }
}