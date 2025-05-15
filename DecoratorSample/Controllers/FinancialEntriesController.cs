using DecoratorSample.Commands;
using Microsoft.AspNetCore.Mvc;

namespace DecoratorSample.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FinancialEntriesController(
    ICommandHandler<InsertFinancialEntryCommand> insertHandler,
    ICommandHandler<UpdateFinancialEntryCommand> updateHandler) : ControllerBase
{
    [HttpPost("insert")]
    public async Task<IActionResult> Insert([FromBody] InsertFinancialEntryCommand command)
    {
        await insertHandler.HandleAsync(command);
        return Ok();
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] UpdateFinancialEntryCommand command)
    {
        await updateHandler.HandleAsync(command);
        return Ok();
    }
}

