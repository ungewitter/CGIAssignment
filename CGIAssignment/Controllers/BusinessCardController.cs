using CGIAssignment.Models;
using CGIAssignment.Services;
using Microsoft.AspNetCore.Mvc;

namespace CGIAssignment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BusinessCardController : ControllerBase
    {
        private readonly ILogger<BusinessCardController> _logger;
        private readonly IBusinessCardService _businessCardService;

        public BusinessCardController(ILogger<BusinessCardController> logger, IBusinessCardService businessCardService)
        {
            _logger = logger;
            _businessCardService = businessCardService;
        }

        [HttpGet(Name = "GetAllBusinessCards")]
        public async Task<IEnumerable<BusinessCard>> GetAsync()
        {
            return await _businessCardService.GetAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BusinessCard>> GetByIdAsync(string id)
        {
            var businessCard = await _businessCardService.GetByIdAsync(id);

            if (businessCard is null)
            {
                return NotFound();
            }

            return businessCard;
        }


        [HttpPost(Name = "CreateBusinessCard")]
        public async Task<BusinessCard> PostAsync(AddBusinessCardRequest request)
        {
            var businessCard = await _businessCardService.CreateAsync(request);

            return businessCard;
        }

        [HttpPut("update/{id}", Name = "UpdateBusinessCard")]
        public async Task<ActionResult<BusinessCard>> UpdateAsync(string id, AddBusinessCardRequest request)
        {
            var businessCard = await _businessCardService.GetByIdAsync(id);
            if (businessCard is null)
            {
                return NotFound();
            }

            return await _businessCardService.UpdateAsync(businessCard, request);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<BusinessCard>> DeleteAsync(string id)
        {
            var businessCard = await _businessCardService.GetByIdAsync(id);
            if (businessCard is null)
            {
                return NotFound();
            }

            return await _businessCardService.RemoveAsync(businessCard);
        }

        //[HttpPost("{id}/upload")]
        //public async Task<string> UploadImageAsync(string id, IFormFile image)
        //{
        //    return await _businessCardService.AddImageToBusinessCardAsync(id, image);
        //}
    }
}
