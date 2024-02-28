namespace Maggie.Domain.Entities;

public class PersonalBudget
{
	public Guid Id { get; set; }
	public decimal Light { get; private set; }
	public decimal Water { get; private set; } 
	public decimal Internet { get; private set; } 
	public decimal BasicFood { get; private set; }
	public decimal Health { get; private set; } 
	public decimal Leisure { get; private set; } 
	public decimal Clothes { get; private set; }
	public decimal? Transport { get; private set; }
	public decimal? HomeRent { get; private set; }
	public decimal? HomeTax { get; private set; }
	public decimal? HomeFinancing { get; private set; }
	public decimal? CarTax { get; private set; }
	public decimal? CarFinancing { get; private set; }
	public decimal? Gas { get; private set; }
	public decimal? Medicines { get; private set; }
	public decimal? Education { get; private set; }
	public decimal? HomeSpends { get; private set; }
	
	
	public decimal Salary { get; private set; }

	public PersonalBudget(
		Guid id,
		decimal salary,
		decimal light,
		decimal water,
		decimal internet, 
		decimal basicFood, 
		decimal health, 
		decimal leisure, 
		decimal clothes,
		
		decimal? transport = null, 
		decimal? gas = null,
		decimal? medicines = null,
		decimal? education = null,
		decimal? homeSpends = null,
		
		decimal? homeRent = null,
		decimal? homeTax = null,
		decimal? homeFinancing = null,
		
		decimal? carTax = null,
		decimal? carFinancing = null
		)
	{
		
		if (salary < 1)
		{
			Console.WriteLine("Salary wrong");
			throw new ArgumentException("Salary must be positive");
		}

		Id = id;
		Salary = salary;
		Light = light;
		Water = water;
		Internet = internet;
		BasicFood = basicFood;
		Health = health;
		Leisure = leisure;
		Transport = transport;
		HomeRent = homeRent;
		Clothes = clothes;
		HomeTax = homeTax;
		HomeFinancing = homeFinancing;
		CarTax = carTax;
		CarFinancing = carFinancing;
		Gas = gas;
		Medicines = medicines;
		Education = education;
		HomeSpends = homeSpends;
	}
}

/*
 # Contas a parar
	Luz	R$ 100
	Condomínio (IPTU/Gás/Água)	R$ 200
	Internet	R$ 150
	Aluguel (residência com 45m²)	R$1.725,75
	Cesta básica	R$ 791,82
	Transporte (levando em consideração apenas o uso do transporte público)	R$ 264
	Saúde	R$ 300
	Lazer	R$ 750
	Reserva de emergência	R$ 856, 31
	
# Salário ideal
	Salário ideal	R$ 5.137,88
	
	
# Cesta básica por cidade
   São Paulo: R$ 782,68
   Porto Alegre: R$ 781,52
   Florianópolis: R$ 776,14
   Rio de Janeiro: R$ 749,25
   Campo Grande: R$ 738,53
   Outras capitais R$ 511,97
   
 */