using Amazon.Runtime.Internal;
using CGIAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CGIAssignment.Helpers
{
    public class BusinessCardMapper
    {
        public async Task<BusinessCard> MapToBusinessCardFromRequestAsync(AddBusinessCardRequest request)
        {
            return new BusinessCard
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                ImageFilePath = await MapImageFilePathAsync(request.FirstName, request.ImageFilePath)
            };
        }

        public async Task<BusinessCard> MapToBusinessCardFromRequestAsync(AddBusinessCardRequest request, BusinessCard originalBusinessCard)
        {
            return new BusinessCard
            {
                FirstName = request.FirstName ?? originalBusinessCard.FirstName,
                LastName = request.LastName ?? originalBusinessCard.LastName,
                Email = request.Email ?? originalBusinessCard.Email,
                PhoneNumber = request.PhoneNumber ?? originalBusinessCard.PhoneNumber,
                ImageFilePath = request.ImageFilePath != null ? await MapImageFilePathAsync(request.FirstName ?? originalBusinessCard.FirstName, request.ImageFilePath) : originalBusinessCard.ImageFilePath
            };
        }

        public async Task<string> MapImageFilePathAsync(string firstName, IFormFile image)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
            var fileExtension = Path.GetExtension(image.FileName).ToLower();

            if (!allowedExtensions.Contains(fileExtension))
            {
                throw new InvalidOperationException("Bara .jpg och .png tillåtet.");
            }

            string uploadsDirectory = "uploads";
            if (!Directory.Exists(uploadsDirectory))
            {
                Directory.CreateDirectory(uploadsDirectory);
            }

            string fileName = $"{firstName}_{Path.GetFileName(image.FileName)}";
            string filePath = Path.Combine(uploadsDirectory, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            return filePath.Replace("\\", "/");
        }
    }
}
