using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CollegeManagementSystem.Models
{
    public class College
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("address")]
        public string Address { get; set; } = string.Empty;

        [BsonElement("established_year")]
        public int EstablishedYear { get; set; }

        [BsonElement("contact_number")]
        public string ContactNumber { get; set; } = string.Empty;

        [BsonElement("email")]
        public string Email { get; set; } = string.Empty;

        [BsonElement("courses")]
        public List<string> CourseIds { get; set; } = new List<string>();

        [BsonElement("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [BsonElement("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}