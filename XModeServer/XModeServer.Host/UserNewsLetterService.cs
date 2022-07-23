using MongoDB.Driver;

public class UserNewsLetterService
{
    private readonly IMongoCollection<UserNewsletter> _collection;

    public UserNewsLetterService(IMongoCollection<UserNewsletter> collection)
    {
        _collection = collection;
    }

    public async Task InsertOneAsync(UserNewsletter userNewsletter) =>
        await _collection.InsertOneAsync(userNewsletter);

    public async Task<IEnumerable<UserNewsletter>> GetAsync() =>
        (await _collection.FindAsync(FilterDefinition<UserNewsletter>.Empty)).ToList();
}