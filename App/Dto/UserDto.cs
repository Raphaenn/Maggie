namespace Maggie.Dto;

public class UserDto
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public DateTime DataNascimento { get; set; }
    public bool Status { get; set; }
    public string Role { get; set; }
    public string Cep { get; set; }
}