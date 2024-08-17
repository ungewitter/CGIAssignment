using CGIAssignment.Models;

namespace CGIAssignment.Services
{
    public interface IBusinessCardService
    {
        Task<IEnumerable<BusinessCard>> GetAsync();

        Task<BusinessCard> GetByIdAsync(string id);

        Task<BusinessCard> CreateAsync(AddBusinessCardRequest request);

        Task<BusinessCard> UpdateAsync(BusinessCard id, AddBusinessCardRequest updatedCard);

        Task<BusinessCard> RemoveAsync(BusinessCard id);
    }
}
