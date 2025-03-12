using Ambev.Application.Commands;
using Ambev.Application.Queries;
using Ambev.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.api.Controllers;

/// <summary>
/// Controlador de funcionários
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class EmployeeController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Construtor da classe
    /// </summary>
    /// <param name="mediator"></param>
    public EmployeeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Lista todos os registros
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Employee>>> GetAll()
    {
        return Ok(await _mediator.Send(new GetAllEmployeesQuery()));
    }

    /// <summary>
    /// Busca um registro por ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Employee>> GetById(int id)
    {
        var employee = await _mediator.Send(new GetEmployeeByIdQuery { Id = id });
        return employee == null ? NotFound() : Ok(employee);
    }

    /// <summary>
    /// Cria um novo registro
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] EmployeeCreateCommand command)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = command.Id }, command);
    }

    /// <summary>
    /// Altera os dados de um registro
    /// </summary>
    /// <param name="id"></param>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] EmployeeUpdateCommand command)
    {
        if (id != command.Id) return BadRequest();
        if (!ModelState.IsValid) return BadRequest(ModelState);

        await _mediator.Send(command);
        return NoContent();
    }

    /// <summary>
    /// Deleta um registro
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new EmployeeDeleteCommand { Id = id });
        return NoContent();
    }
}