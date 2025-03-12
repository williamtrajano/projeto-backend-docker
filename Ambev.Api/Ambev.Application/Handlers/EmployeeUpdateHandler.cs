using Ambev.Application.Commands;
using Ambev.Domain.Repositories;
using Ambev.Infrastructure.Shared;
using MediatR;

namespace Ambev.Application.Handlers;

public class EmployeeUpdateHandler : IRequestHandler<EmployeeUpdateCommand, Unit>
{
    private readonly IEmployeeRepository _repository;

    public EmployeeUpdateHandler(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(EmployeeUpdateCommand request, CancellationToken cancellationToken)
    {
        var employee = await _repository.GetByIdAsync(request.Id);

        if (employee == null)
            throw new Exception("Funcionário não encontrado");

        employee.Nome = request.Nome;
        employee.Sobrenome = request.Sobrenome;
        employee.Email = request.Email;
        employee.Documento = request.Documento;
        employee.Telefone = request.Telefone;
        employee.NomeDoGestor = request.NomeDoGestor;
        employee.Senha = !string.IsNullOrEmpty(request.Senha) ? HashHelper.StringToHash(request.Senha) : employee.Senha;
        employee.DataAlteracao = DateTimeHelper.GetSqlServerSafeDateTime(DateTime.Now);

        await _repository.UpdateAsync(employee);
        return Unit.Value;
    }
}
