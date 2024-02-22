namespace Maggie.Domain.Entities;

public enum UserRole
{
    Admin,
    Default
}

public class Users
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Cpf { get; set; }
    public string Email { get; private set; }
    public bool Status { get; set; }


    public Users(Guid id, string name, string email, bool status)
    {
        Id = id;
        Name = name;
        SetEmail(email);
        Status = status;
    }
    
    private void SetEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
        {
            throw new Exception("Invalid Email");
        }

        Email = email;
    }
}   