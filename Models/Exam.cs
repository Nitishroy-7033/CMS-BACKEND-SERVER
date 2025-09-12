using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CollegeManagementSystem.Models
{
    public class Exam
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("type")]
        public string Type { get; set; } = string.Empty; // Mid-term, Final, etc.

        [BsonElement("branch_id")]
        public string BranchId { get; set; } = string.Empty;

        [BsonElement("subject_id")]
        public string SubjectId { get; set; } = string.Empty;

        [BsonElement("year")]
        public int Year { get; set; }

        [BsonElement("semester")]
        public int Semester { get; set; }

        [BsonElement("exam_date")]
        public DateTime ExamDate { get; set; }

        [BsonElement("duration_minutes")]
        public int DurationMinutes { get; set; }

        [BsonElement("max_marks")]
        public int MaxMarks { get; set; } = 100;

        [BsonElement("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [BsonElement("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}