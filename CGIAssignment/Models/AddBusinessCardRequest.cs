﻿namespace CGIAssignment.Models
{
    public class AddBusinessCardRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public IFormFile? ImageFilePath { get; set; }
    }
}
