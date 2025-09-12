using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CollegeManagementSystem.Models
{
    public class Branch
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("course_id")]
        public string CourseId { get; set; } = string.Empty;

        [BsonElement("subjects")]
        public List<string> SubjectIds { get; set; } = new List<string>();

        [BsonElement("fee_structure_id")]
        public string FeeStructureId { get; set; } = string.Empty;

        [BsonElement("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [BsonElement("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}