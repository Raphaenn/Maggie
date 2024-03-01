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
    public string Email { get; private set; } = String.Empty;
    public string Cpf { get; private set; } = String.Empty;
    public int IdAccount { get; set; }
    public bool Status { get; set; }

    public Users(Guid id, string name, string email, string cpf)
    {
        Id = id;
        Name = name;
        SetEmail(email);
        SetCpf(cpf);
        Status = true;
    }
    
    private void SetEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
        {
            throw new Exception("Invalid Email");
        }
        
        Email = email;
    }

    private void SetCpf(string cpf)
    {
        if (string.IsNullOrWhiteSpace(cpf) || (cpf.Length < 11))
        {
            throw new Exception("Invalid Cpf");
        }
        
        Cpf = cpf;
    }
}   