using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CollegeManagementSystem.Models
{
    public class Course
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("duration_years")]
        public int DurationYears { get; set; }

        [BsonElement("college_id")]
        public string CollegeId { get; set; } = string.Empty;

        [BsonElement("branches")]
        public List<string> BranchIds { get; set; } = new List<string>();

        [BsonElement("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [BsonElement("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}