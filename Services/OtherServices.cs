using CollegeManagementSystem.Models;
using CollegeManagementSystem.Models.RequestModels;
using CollegeManagementSystem.Repository.Interfaces;
using CollegeManagementSystem.Services.Interfaces;

namespace CollegeManagementSystem.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public async Task<List<Subject>> GetAllSubjectsAsync()
        {
            return await _subjectRepository.GetAllAsync();
        }

        public async Task<Subject?> GetSubjectByIdAsync(string id)
        {
            return await _subjectRepository.GetByIdAsync(id);
        }

        public async Task<Subject> CreateSubjectAsync(CreateSubjectRequest request)
        {
            var subject = new Subject
            {
                Name = request.Name,
                Code = request.Code,
                BranchId = request.BranchId,
                Year = request.Year,
                Semester = request.Semester,
                Credits = request.Credits,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            return await _subjectRepository.CreateAsync(subject);
        }

        public async Task<List<Subject>> GetSubjectsByBranchIdAsync(string branchId)
        {
            return await _subjectRepository.GetSubjectsByBranchIdAsync(branchId);
        }

        public async Task<List<Subject>> GetSubjectsByYearAndSemesterAsync(string branchId, int year, int semester)
        {
            return await _subjectRepository.GetSubjectsByYearAndSemesterAsync(branchId, year, semester);
        }

        public async Task<bool> DeleteSubjectAsync(string id)
        {
            return await _subjectRepository.DeleteAsync(id);
        }
    }

    public class FeeStructureService : IFeeStructureService
    {
        private readonly IFeeStructureRepository _feeStructureRepository;

        public FeeStructureService(IFeeStructureRepository feeStructureRepository)
        {
            _feeStructureRepository = feeStructureRepository;
        }

        public async Task<List<FeeStructure>> GetAllFeeStructuresAsync()
        {
            return await _feeStructureRepository.GetAllAsync();
        }

        public async Task<FeeStructure?> GetFeeStructureByIdAsync(string id)
        {
            return await _feeStructureRepository.GetByIdAsync(id);
        }

        public async Task<FeeStructure> CreateFeeStructureAsync(CreateFeeStructureRequest request)
        {
            var feeStructure = new FeeStructure
            {
                BranchId = request.BranchId,
                TotalFee = request.TotalFee,
                YearlyFee = request.YearlyFee,
                SemesterFee = request.SemesterFee,
                Currency = request.Currency,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            return await _feeStructureRepository.CreateAsync(feeStructure);
        }

        public async Task<FeeStructure?> GetFeeStructureByBranchIdAsync(string branchId)
        {
            return await _feeStructureRepository.GetFeeStructureByBranchIdAsync(branchId);
        }

        public async Task<bool> DeleteFeeStructureAsync(string id)
        {
            return await _feeStructureRepository.DeleteAsync(id);
        }
    }

    public class ExamService : IExamService
    {
        private readonly IExamRepository _examRepository;

        public ExamService(IExamRepository examRepository)
        {
            _examRepository = examRepository;
        }

        public async Task<List<Exam>> GetAllExamsAsync()
        {
            return await _examRepository.GetAllAsync();
        }

        public async Task<Exam?> GetExamByIdAsync(string id)
        {
            return await _examRepository.GetByIdAsync(id);
        }

        public async Task<Exam> CreateExamAsync(CreateExamRequest request)
        {
            var exam = new Exam
            {
                Name = request.Name,
                Type = request.Type,
                BranchId = request.BranchId,
                SubjectId = request.SubjectId,
                Year = request.Year,
                Semester = request.Semester,
                ExamDate = request.ExamDate,
                DurationMinutes = request.DurationMinutes,
                MaxMarks = request.MaxMarks,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            return await _examRepository.CreateAsync(exam);
        }

        public async Task<List<Exam>> GetExamsByBranchIdAsync(string branchId)
        {
            return await _examRepository.GetExamsByBranchIdAsync(branchId);
        }

        public async Task<List<Exam>> GetExamsBySubjectIdAsync(string subjectId)
        {
            return await _examRepository.GetExamsBySubjectIdAsync(subjectId);
        }

        public async Task<List<Exam>> GetExamsByYearAndSemesterAsync(string branchId, int year, int semester)
        {
            return await _examRepository.GetExamsByYearAndSemesterAsync(branchId, year, semester);
        }

        public async Task<bool> DeleteExamAsync(string id)
        {
            return await _examRepository.DeleteAsync(id);
        }
    }
}