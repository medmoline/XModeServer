using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

[ApiController]
[Route("[controller]")]

public class UserController : ControllerBase
{
    private readonly UserNewsLetterService _userNewsLetterService;

    public UserController()
    {
        var connectionString = "mongodb://localhost:27017";
        var mongoClient = new MongoClient(connectionString);
        var database = mongoClient.GetDatabase("xmodeServer");
        var collection = database.GetCollection<UserNewsletter>("newsletter_collection");
        _userNewsLetterService = new UserNewsLetterService(collection);
    }

    [HttpGet(Name = "GetUsers")]
    public async Task<JsonResult> Get()
    {
        var list = await _userNewsLetterService.GetAsync();

        return new JsonResult(list);
    }

    [HttpPost]
    public async Task<JsonResult> Post(string username, string lastname, string email)
    {
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(lastname) || string.IsNullOrWhiteSpace(email))
            return new JsonResult("Dati non corretti");

        var id = ObjectId.GenerateNewId();
        var user = new UserNewsletter(id, username, lastname, email, DateTimeOffset.Now);

        await _userNewsLetterService.InsertOneAsync(user);

        return new JsonResult("Added Successfully");
    }
}