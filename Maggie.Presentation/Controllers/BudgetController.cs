using App.Dto;
using Maggie.Dto;
using Maggie.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Maggie.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BudgetController : ControllerBase
{
    private readonly IBudgetAppService _budgetAppService;

    public BudgetController(IBudgetAppService budgetAppService)
    {
        _budgetAppService = budgetAppService;
    }

    [HttpPost("/create/{id}")]
    public async Task<ActionResult<PersonalBudgetDto>> CreateBudget([FromRoute] string id, [FromBody] PersonalBudgetDto budget)
    {
        var response = await _budgetAppService.CreatePersonalBudget(budget, id);
        return Ok(response);
    }

    [HttpGet("/user/{id}")]
    public async Task<ActionResult<PersonalBudgetDto>> GetBudgetByUserId([FromRoute] string id)
    {
        var response = await _budgetAppService.GetBudgetByUser(id);
        return Ok(response);
    }

    [HttpGet("/list/by-year/{id}")]
    public async Task<ActionResult<PersonalBudgetDto>> GetYearBudget([FromRoute] string id, [FromQuery] int year)
    {
        PersonalBudgetDto response = await _budgetAppService.GetBudgetByYear(id, year);
        return Ok(response);
    }
}