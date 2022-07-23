using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;

public class UserNewsletter
{
    public ObjectId Id { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    public string Lastname { get; set; }
    [Required]
    public string Email { get; set; }
    public DateTimeOffset CreationDate { get; set; }

    public UserNewsletter(
        ObjectId id,
        string username,
        string lastname,
        string email,
        DateTimeOffset creationDate)
    {
        Id = id;
        Username = username;
        Lastname = lastname;
        Email = email;
        CreationDate = creationDate;
    }
}