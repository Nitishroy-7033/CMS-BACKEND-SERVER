using MongoDB.Driver;
using CollegeManagementSystem.Models;
using CollegeManagementSystem.Repository.Interfaces;
using CollegeManagementSystem.Db;

namespace CollegeManagementSystem.Repository
{
    public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(IDbContext dbContext) : base(dbContext.Subjects)
        {
        }

        public async Task<List<Subject>> GetSubjectsByBranchIdAsync(string branchId)
        {
            var filter = Builders<Subject>.Filter.Eq("branch_id", branchId);
            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<List<Subject>> GetSubjectsByYearAndSemesterAsync(string branchId, int year, int semester)
        {
            var filter = Builders<Subject>.Filter.And(
                Builders<Subject>.Filter.Eq("branch_id", branchId),
                Builders<Subject>.Filter.Eq("year", year),
                Builders<Subject>.Filter.Eq("semester", semester)
            );
            return await _collection.Find(filter).ToListAsync();
        }
    }

    public class FeeStructureRepository : GenericRepository<FeeStructure>, IFeeStructureRepository
    {
        public FeeStructureRepository(IDbContext dbContext) : base(dbContext.FeeStructures)
        {
        }

        public async Task<FeeStructure?> GetFeeStructureByBranchIdAsync(string branchId)
        {
            var filter = Builders<FeeStructure>.Filter.Eq("branch_id", branchId);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }
    }

    public class ExamRepository : GenericRepository<Exam>, IExamRepository
    {
        public ExamRepository(IDbContext dbContext) : base(dbContext.Exams)
        {
        }

        public async Task<List<Exam>> GetExamsByBranchIdAsync(string branchId)
        {
            var filter = Builders<Exam>.Filter.Eq("branch_id", branchId);
            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<List<Exam>> GetExamsBySubjectIdAsync(string subjectId)
        {
            var filter = Builders<Exam>.Filter.Eq("subject_id", subjectId);
            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<List<Exam>> GetExamsByYearAndSemesterAsync(string branchId, int year, int semester)
        {
            var filter = Builders<Exam>.Filter.And(
                Builders<Exam>.Filter.Eq("branch_id", branchId),
                Builders<Exam>.Filter.Eq("year", year),
                Builders<Exam>.Filter.Eq("semester", semester)
            );
            return await _collection.Find(filter).ToListAsync();
        }
    }
}