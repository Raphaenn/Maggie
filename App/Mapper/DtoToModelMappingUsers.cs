namespace Maggie.App.Mapper;

public class DtoToModelMappingUsers
{
    public string Id { get; set; }
    public string Cpf { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public DateTime DataNascimento { get; set; }
    public bool Status { get; set; }
}