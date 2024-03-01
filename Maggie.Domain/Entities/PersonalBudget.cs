using System.Globalization;

namespace Maggie.Domain.Entities;

public class PersonalBudget
{
	public Guid Id { get; set; }
	public decimal Light { get; set; }
	public decimal Water { get; set; } 
	public decimal Internet { get; set; } 
	public decimal BasicFood { get; set; }
	public decimal Health { get; set; } 
	public decimal Leisure { get; set; } 
	public decimal Clothes { get; set; }
	public decimal? Transport { get; set; }
	public decimal? HomeRent { get; set; }
	public decimal? HomeTax { get; set; }
	public decimal? HomeFinancing { get; set; }
	public decimal? CarTax { get; set; }
	public decimal? CarFinancing { get; set; }
	public decimal? Medicines { get; set; }
	public decimal? Education { get; set; }
	public decimal? HomeSpends { get; set; }
	public DateTime BudgetDate { get; set; }
	
	
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
		DateTime budgetDate,
		
		decimal? transport = null, 
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
		SetBudgetDate(budgetDate);
		
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
		Medicines = medicines;
		Education = education;
		HomeSpends = homeSpends;
	}

	private void SetBudgetDate(DateTime date)
	{
		// Set to the first day of the month
		DateTime firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
		this.BudgetDate = firstDayOfMonth;
	}
}