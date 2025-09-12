using Microsoft.AspNetCore.Mvc;
using CollegeManagementSystem.Models;
using CollegeManagementSystem.Models.RequestModels;
using CollegeManagementSystem.Services.Interfaces;

namespace CollegeManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Subject>>> GetAllSubjects()
        {
            var subjects = await _subjectService.GetAllSubjectsAsync();
            return Ok(subjects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Subject>> GetSubjectById(string id)
        {
            var subject = await _subjectService.GetSubjectByIdAsync(id);
            if (subject == null)
                return NotFound($"Subject with ID {id} not found");

            return Ok(subject);
        }

        [HttpPost]
        public async Task<ActionResult<Subject>> CreateSubject([FromBody] CreateSubjectRequest request)
        {
            var subject = await _subjectService.CreateSubjectAsync(request);
            return CreatedAtAction(nameof(GetSubjectById), new { id = subject.Id }, subject);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSubject(string id)
        {
            var result = await _subjectService.DeleteSubjectAsync(id);
            if (!result)
                return NotFound($"Subject with ID {id} not found");

            return NoContent();
        }

        [HttpGet("branch/{branchId}")]
        public async Task<ActionResult<List<Subject>>> GetSubjectsByBranchId(string branchId)
        {
            var subjects = await _subjectService.GetSubjectsByBranchIdAsync(branchId);
            return Ok(subjects);
        }

        [HttpGet("branch/{branchId}/year/{year}/semester/{semester}")]
        public async Task<ActionResult<List<Subject>>> GetSubjectsByYearAndSemester(string branchId, int year, int semester)
        {
            var subjects = await _subjectService.GetSubjectsByYearAndSemesterAsync(branchId, year, semester);
            return Ok(subjects);
        }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class FeeStructureController : ControllerBase
    {
        private readonly IFeeStructureService _feeStructureService;

        public FeeStructureController(IFeeStructureService feeStructureService)
        {
            _feeStructureService = feeStructureService;
        }

        [HttpGet]
        public async Task<ActionResult<List<FeeStructure>>> GetAllFeeStructures()
        {
            var feeStructures = await _feeStructureService.GetAllFeeStructuresAsync();
            return Ok(feeStructures);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FeeStructure>> GetFeeStructureById(string id)
        {
            var feeStructure = await _feeStructureService.GetFeeStructureByIdAsync(id);
            if (feeStructure == null)
                return NotFound($"Fee Structure with ID {id} not found");

            return Ok(feeStructure);
        }

        [HttpPost]
        public async Task<ActionResult<FeeStructure>> CreateFeeStructure([FromBody] CreateFeeStructureRequest request)
        {
            var feeStructure = await _feeStructureService.CreateFeeStructureAsync(request);
            return CreatedAtAction(nameof(GetFeeStructureById), new { id = feeStructure.Id }, feeStructure);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFeeStructure(string id)
        {
            var result = await _feeStructureService.DeleteFeeStructureAsync(id);
            if (!result)
                return NotFound($"Fee Structure with ID {id} not found");

            return NoContent();
        }

        [HttpGet("branch/{branchId}")]
        public async Task<ActionResult<FeeStructure>> GetFeeStructureByBranchId(string branchId)
        {
            var feeStructure = await _feeStructureService.GetFeeStructureByBranchIdAsync(branchId);
            if (feeStructure == null)
                return NotFound($"Fee Structure for Branch ID {branchId} not found");

            return Ok(feeStructure);
        }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class ExamController : ControllerBase
    {
        private readonly IExamService _examService;

        public ExamController(IExamService examService)
        {
            _examService = examService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Exam>>> GetAllExams()
        {
            var exams = await _examService.GetAllExamsAsync();
            return Ok(exams);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Exam>> GetExamById(string id)
        {
            var exam = await _examService.GetExamByIdAsync(id);
            if (exam == null)
                return NotFound($"Exam with ID {id} not found");

            return Ok(exam);
        }

        [HttpPost]
        public async Task<ActionResult<Exam>> CreateExam([FromBody] CreateExamRequest request)
        {
            var exam = await _examService.CreateExamAsync(request);
            return CreatedAtAction(nameof(GetExamById), new { id = exam.Id }, exam);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteExam(string id)
        {
            var result = await _examService.DeleteExamAsync(id);
            if (!result)
                return NotFound($"Exam with ID {id} not found");

            return NoContent();
        }

        [HttpGet("branch/{branchId}")]
        public async Task<ActionResult<List<Exam>>> GetExamsByBranchId(string branchId)
        {
            var exams = await _examService.GetExamsByBranchIdAsync(branchId);
            return Ok(exams);
        }

        [HttpGet("subject/{subjectId}")]
        public async Task<ActionResult<List<Exam>>> GetExamsBySubjectId(string subjectId)
        {
            var exams = await _examService.GetExamsBySubjectIdAsync(subjectId);
            return Ok(exams);
        }

        [HttpGet("branch/{branchId}/year/{year}/semester/{semester}")]
        public async Task<ActionResult<List<Exam>>> GetExamsByYearAndSemester(string branchId, int year, int semester)
        {
            var exams = await _examService.GetExamsByYearAndSemesterAsync(branchId, year, semester);
            return Ok(exams);
        }
    }
}