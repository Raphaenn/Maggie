namespace Maggie.Dto;

public class PersonalBudgetDto
{
    public decimal Luz { get; set; } 
    public decimal Agua { get; set; } 
    public decimal Internet { get; set; } 
    public decimal CestaBasica { get; set; } 
    public decimal Saude { get; set; } 
    public decimal Lazer { get; set; } 
    public decimal Roupas { get; set; }
    public decimal? Transporte { get; set; }
    public decimal? Aluguel { get; set; }
    public decimal? Condominio { get; set; }
    public decimal? FinanciamentoCasa { get; private set; }
    public decimal? ImpostosCarro { get; private set; }
    public decimal? FinanciamentoCaroo { get; private set; }
    public decimal? Gas { get; private set; }
    public decimal? Medicamentos { get; private set; }
    public decimal? Educacao { get; private set; }
    public decimal? DespesasCasa { get; private set; }
    
    public decimal Salario { get; set; }
}