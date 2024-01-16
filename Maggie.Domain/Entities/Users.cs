namespace Maggie.Domain.Entities;

public class Users
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public bool Status { get; set; }


    public Users(string id, string name, string email, DateTime birthdate, bool status)
    {
        Id = id;
        Name = name;
        Email = email;
        BirthDate = birthdate;
        Status = status;
    }
}   