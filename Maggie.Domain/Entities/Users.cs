namespace Maggie.Domain.Entities;

public enum UserRole
{
    Admin,
    Default
}

public class Users
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Cpf { get; set; }
    public string Email { get; private set; }
    public DateTime BirthDate { get; set; }
    public bool Status { get; set; }
    public UserRole Role { get; set; }
    public string? Cep { get; set; } = null;


    public Users(string name, string email, DateTime birthdate, bool status, UserRole role, string? cep)
    {
        Name = name;
        SetEmail(email);
        BirthDate = birthdate;
        Status = status;
        Role = role;
        Cep = cep;
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