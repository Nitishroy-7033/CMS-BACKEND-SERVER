using CollegeManagementSystem.Models;
using CollegeManagementSystem.Models.RequestModels;

namespace CollegeManagementSystem.Services.Interfaces
{
    public interface ISubjectService
    {
        Task<List<Subject>> GetAllSubjectsAsync();
        Task<Subject?> GetSubjectByIdAsync(string id);
        Task<Subject> CreateSubjectAsync(CreateSubjectRequest request);
        Task<List<Subject>> GetSubjectsByBranchIdAsync(string branchId);
        Task<List<Subject>> GetSubjectsByYearAndSemesterAsync(string branchId, int year, int semester);
        Task<bool> DeleteSubjectAsync(string id);
    }

    public interface IFeeStructureService
    {
        Task<List<FeeStructure>> GetAllFeeStructuresAsync();
        Task<FeeStructure?> GetFeeStructureByIdAsync(string id);
        Task<FeeStructure> CreateFeeStructureAsync(CreateFeeStructureRequest request);
        Task<FeeStructure?> GetFeeStructureByBranchIdAsync(string branchId);
        Task<bool> DeleteFeeStructureAsync(string id);
    }

    public interface IExamService
    {
        Task<List<Exam>> GetAllExamsAsync();
        Task<Exam?> GetExamByIdAsync(string id);
        Task<Exam> CreateExamAsync(CreateExamRequest request);
        Task<List<Exam>> GetExamsByBranchIdAsync(string branchId);
        Task<List<Exam>> GetExamsBySubjectIdAsync(string subjectId);
        Task<List<Exam>> GetExamsByYearAndSemesterAsync(string branchId, int year, int semester);
        Task<bool> DeleteExamAsync(string id);
    }
}