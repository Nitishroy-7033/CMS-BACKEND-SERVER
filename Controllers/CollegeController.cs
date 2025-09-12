using Microsoft.AspNetCore.Mvc;
using CollegeManagementSystem.Models;
using CollegeManagementSystem.Models.RequestModels;
using CollegeManagementSystem.Services.Interfaces;

namespace CollegeManagementSystem.Controllers
{
    /// <summary>
    /// College management operations
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CollegeController : ControllerBase
    {
        private readonly ICollegeService _collegeService;

        public CollegeController(ICollegeService collegeService)
        {
            _collegeService = collegeService;
        }

        /// <summary>
        /// Get all colleges
        /// </summary>
        /// <returns>List of all colleges</returns>
        /// <response code="200">Returns the list of colleges</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<College>), 200)]
        public async Task<ActionResult<List<College>>> GetAllColleges()
        {
            var colleges = await _collegeService.GetAllCollegesAsync();
            return Ok(colleges);
        }

        /// <summary>
        /// Get a specific college by ID
        /// </summary>
        /// <param name="id">College ID</param>
        /// <returns>College details</returns>
        /// <response code="200">Returns the college details</response>
        /// <response code="404">If the college is not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(College), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<College>> GetCollegeById(string id)
        {
            var college = await _collegeService.GetCollegeByIdAsync(id);
            if (college == null)
                return NotFound($"College with ID {id} not found");

            return Ok(college);
        }

        /// <summary>
        /// Create a new college
        /// </summary>
        /// <param name="request">College creation details</param>
        /// <returns>Created college</returns>
        /// <response code="201">Returns the newly created college</response>
        /// <response code="400">If the request is invalid</response>
        [HttpPost]
        [ProducesResponseType(typeof(College), 201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<College>> CreateCollege([FromBody] CreateCollegeRequest request)
        {
            var college = await _collegeService.CreateCollegeAsync(request);
            return CreatedAtAction(nameof(GetCollegeById), new { id = college.Id }, college);
        }

        /// <summary>
        /// Update an existing college
        /// </summary>
        /// <param name="id">College ID</param>
        /// <param name="request">Updated college details</param>
        /// <returns>Updated college</returns>
        /// <response code="200">Returns the updated college</response>
        /// <response code="404">If the college is not found</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(College), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<College>> UpdateCollege(string id, [FromBody] UpdateCollegeRequest request)
        {
            var updatedCollege = await _collegeService.UpdateCollegeAsync(id, request);
            if (updatedCollege == null)
                return NotFound($"College with ID {id} not found");

            return Ok(updatedCollege);
        }

        /// <summary>
        /// Delete a college
        /// </summary>
        /// <param name="id">College ID</param>
        /// <returns>No content</returns>
        /// <response code="204">College successfully deleted</response>
        /// <response code="404">If the college is not found</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> DeleteCollege(string id)
        {
            var result = await _collegeService.DeleteCollegeAsync(id);
            if (!result)
                return NotFound($"College with ID {id} not found");

            return NoContent();
        }

        /// <summary>
        /// Search colleges by name
        /// </summary>
        /// <param name="name">College name to search for</param>
        /// <returns>List of matching colleges</returns>
        /// <response code="200">Returns the list of matching colleges</response>
        [HttpGet("search")]
        [ProducesResponseType(typeof(List<College>), 200)]
        public async Task<ActionResult<List<College>>> SearchColleges([FromQuery] string name)
        {
            var colleges = await _collegeService.SearchCollegesByNameAsync(name);
            return Ok(colleges);
        }
    }
}