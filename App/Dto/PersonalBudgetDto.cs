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
    public decimal? FinanciamentoCasa { get; set; }
    public decimal? ImpostosCarro { get; set; }
    public decimal? FinanciamentoCarro { get; set; }
    public decimal? Medicamentos { get; set; }
    public decimal? Educacao { get; set; }
    public decimal? DespesasCasa { get; set; }
    public DateTime BudgetData { get; set; }
    
    public decimal Salario { get; set; }
    public decimal Saldo { get; private set; }
    
    public void Balance()
    {
        this.Saldo = Salario - (Luz + Agua + Internet + CestaBasica + Saude + Lazer + Roupas +
                                Transporte.GetValueOrDefault() + Aluguel.GetValueOrDefault() +
                                Condominio.GetValueOrDefault() + FinanciamentoCasa.GetValueOrDefault() +
                                ImpostosCarro.GetValueOrDefault() + FinanciamentoCarro.GetValueOrDefault() +
                                Medicamentos.GetValueOrDefault() +
                                Educacao.GetValueOrDefault() + DespesasCasa.GetValueOrDefault());
    }

    public static PersonalBudgetDto SumBudgets(List<PersonalBudgetDto> budgets)
    {
        PersonalBudgetDto result = new PersonalBudgetDto
        {
            Luz = budgets.Sum(b => b.Luz),
            Agua = budgets.Sum(b => b.Agua),
            Internet = budgets.Sum(b => b.Internet),
            CestaBasica = budgets.Sum(b => b.CestaBasica),
            Saude = budgets.Sum(b => b.Saude),
            Lazer = budgets.Sum(b => b.Lazer),
            Roupas = budgets.Sum(b => b.Roupas),
            Transporte = budgets.Sum(b => b.Transporte ?? 0),
            Aluguel = budgets.Sum(b => b.Aluguel ?? 0),
            Condominio = budgets.Sum(b => b.Condominio ?? 0),
            FinanciamentoCasa = budgets.Sum(b => b.FinanciamentoCasa ?? 0),
            ImpostosCarro = budgets.Sum(b => b.ImpostosCarro ?? 0),
            FinanciamentoCarro = budgets.Sum(b => b.FinanciamentoCarro ?? 0),
            Medicamentos = budgets.Sum(b => b.Medicamentos ?? 0),
            Educacao = budgets.Sum(b => b.Educacao ?? 0),
            DespesasCasa = budgets.Sum(b => b.DespesasCasa ?? 0),
            Salario = budgets.Sum(b => b.Salario)
        };

        return result;
    }
}