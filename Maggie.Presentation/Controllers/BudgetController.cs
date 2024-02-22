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

    [HttpPost("/create")]
    public async Task<ActionResult<PersonalBudgetDto>> CreateBudget([FromBody] BudgetCreateDto request)
    {
        var response = await _budgetAppService.CreatePersonalBudget(request.Budget, request.LinkToUser.UserId);
        return Ok(response);
    }
}