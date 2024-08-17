using Amazon.Runtime.Internal;
using CGIAssignment.Helpers;
using CGIAssignment.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CGIAssignment.Services
{
    public class BusinessCardService : IBusinessCardService
    {
        private readonly IMongoCollection<BusinessCard> _businessCardCollection;
        private readonly BusinessCardMapper _businessCardMapper;

        public BusinessCardService(IOptions<BusinessCardDatabaseSettings> businessCardDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                businessCardDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                businessCardDatabaseSettings.Value.DatabaseName);

            _businessCardCollection = mongoDatabase.GetCollection<BusinessCard>(
                businessCardDatabaseSettings.Value.CollectionName);

            _businessCardMapper = new BusinessCardMapper();
        }

        public async Task<IEnumerable<BusinessCard>> GetAsync()
        {
            return await _businessCardCollection.Find(_ => true).ToListAsync();
        }

        public async Task<BusinessCard> GetByIdAsync(string id)
        {
            return await _businessCardCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<BusinessCard> CreateAsync(AddBusinessCardRequest request)
        {
            var businessCard = await _businessCardMapper.MapToBusinessCardFromRequestAsync(request);
            await _businessCardCollection.InsertOneAsync(businessCard);
            return businessCard;
        }

        public async Task<BusinessCard> UpdateAsync(BusinessCard businessCard, AddBusinessCardRequest request)
        {
            var updatedCard = await _businessCardMapper.MapToBusinessCardFromRequestAsync(request, businessCard);
            updatedCard.Id = businessCard.Id;
            await _businessCardCollection.ReplaceOneAsync(x => x.Id == businessCard.Id, updatedCard);
            return updatedCard;
        }

        public async Task<BusinessCard> RemoveAsync(BusinessCard businessCard)
        {
            await _businessCardCollection.DeleteOneAsync(x => x.Id == businessCard.Id);
            return businessCard;
        }
    }
}
