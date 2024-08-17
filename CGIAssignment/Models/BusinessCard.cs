using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CGIAssignment.Models
{
    public class BusinessCard
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber {  get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? ImageFilePath { get; set; }
    }
}
