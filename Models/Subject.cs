using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CollegeManagementSystem.Models
{
    public class Subject
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("code")]
        public string Code { get; set; } = string.Empty;

        [BsonElement("branch_id")]
        public string BranchId { get; set; } = string.Empty;

        [BsonElement("year")]
        public int Year { get; set; } = 1;

        [BsonElement("semester")]
        public int Semester { get; set; } = 1;

        [BsonElement("credits")]
        public int Credits { get; set; } = 3;

        [BsonElement("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [BsonElement("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}