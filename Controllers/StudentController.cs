using Microsoft.AspNetCore.Mvc;
using CollegeManagementSystem.Models;
using CollegeManagementSystem.Models.RequestModels;
using CollegeManagementSystem.Services.Interfaces;

namespace CollegeManagementSystem.Controllers
{
    /// <summary>
    /// Student management operations
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        /// <summary>
        /// Get all students
        /// </summary>
        /// <returns>List of all students</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<Student>), 200)]
        public async Task<ActionResult<List<Student>>> GetAllStudents()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }

        /// <summary>
        /// Get a specific student by ID
        /// </summary>
        /// <param name="id">Student ID</param>
        /// <returns>Student details</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Student), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Student>> GetStudentById(string id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
                return NotFound($"Student with ID {id} not found");

            return Ok(student);
        }

        /// <summary>
        /// Create a new student
        /// </summary>
        /// <param name="request">Student creation details</param>
        /// <returns>Created student</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Student), 201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Student>> CreateStudent([FromBody] CreateStudentRequest request)
        {
            var student = await _studentService.CreateStudentAsync(request);
            return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, student);
        }

        /// <summary>
        /// Update an existing student
        /// </summary>
        /// <param name="id">Student ID</param>
        /// <param name="request">Updated student details</param>
        /// <returns>Updated student</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Student), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Student>> UpdateStudent(string id, [FromBody] UpdateStudentRequest request)
        {
            var updatedStudent = await _studentService.UpdateStudentAsync(id, request);
            if (updatedStudent == null)
                return NotFound($"Student with ID {id} not found");

            return Ok(updatedStudent);
        }

        /// <summary>
        /// Delete a student
        /// </summary>
        /// <param name="id">Student ID</param>
        /// <returns>No content</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> DeleteStudent(string id)
        {
            var result = await _studentService.DeleteStudentAsync(id);
            if (!result)
                return NotFound($"Student with ID {id} not found");

            return NoContent();
        }

        /// <summary>
        /// Get all students in a specific college
        /// </summary>
        /// <param name="collegeId">College ID</param>
        /// <returns>List of students in the college</returns>
        [HttpGet("college/{collegeId}")]
        [ProducesResponseType(typeof(List<Student>), 200)]
        public async Task<ActionResult<List<Student>>> GetStudentsByCollegeId(string collegeId)
        {
            var students = await _studentService.GetStudentsByCollegeIdAsync(collegeId);
            return Ok(students);
        }

        /// <summary>
        /// Get all students in a specific branch
        /// </summary>
        /// <param name="branchId">Branch ID</param>
        /// <returns>List of students in the branch</returns>
        [HttpGet("branch/{branchId}")]
        [ProducesResponseType(typeof(List<Student>), 200)]
        public async Task<ActionResult<List<Student>>> GetStudentsByBranchId(string branchId)
        {
            var students = await _studentService.GetStudentsByBranchIdAsync(branchId);
            return Ok(students);
        }

        /// <summary>
        /// Get student by their student ID (not database ID)
        /// </summary>
        /// <param name="studentId">Student ID (enrollment number)</param>
        /// <returns>Student details</returns>
        [HttpGet("student-id/{studentId}")]
        [ProducesResponseType(typeof(Student), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Student>> GetStudentByStudentId(string studentId)
        {
            var student = await _studentService.GetStudentByStudentIdAsync(studentId);
            if (student == null)
                return NotFound($"Student with Student ID {studentId} not found");

            return Ok(student);
        }
    }
}