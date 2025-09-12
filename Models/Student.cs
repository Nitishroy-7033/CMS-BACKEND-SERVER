using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CollegeManagementSystem.Models
{
    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("email")]
        public string Email { get; set; } = string.Empty;

        [BsonElement("phone")]
        public string Phone { get; set; } = string.Empty;

        [BsonElement("address")]
        public string Address { get; set; } = string.Empty;

        [BsonElement("college_id")]
        public string CollegeId { get; set; } = string.Empty;

        [BsonElement("course_id")]
        public string CourseId { get; set; } = string.Empty;

        [BsonElement("branch_id")]
        public string BranchId { get; set; } = string.Empty;

        [BsonElement("enrollment_date")]
        public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;

        [BsonElement("student_id")]
        public string StudentId { get; set; } = string.Empty;

        [BsonElement("year")]
        public int Year { get; set; } = 1;

        [BsonElement("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [BsonElement("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}