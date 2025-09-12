using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CollegeManagementSystem.Models
{
    public class FeeStructure
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("branch_id")]
        public string BranchId { get; set; } = string.Empty;

        [BsonElement("total_fee")]
        public decimal TotalFee { get; set; }

        [BsonElement("yearly_fee")]
        public decimal YearlyFee { get; set; }

        [BsonElement("semester_fee")]
        public decimal SemesterFee { get; set; }

        [BsonElement("currency")]
        public string Currency { get; set; } = "INR";

        [BsonElement("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [BsonElement("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}