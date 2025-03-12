using Ambev.Application.Commands;
using Ambev.Domain.Entities;
using Ambev.Domain.Repositories;
using Ambev.Infrastructure.Shared;
using MediatR;

namespace Ambev.Application.Handlers;

public class EmployeeCreateHandler : IRequestHandler<EmployeeCreateCommand, int>
{
    private readonly IEmployeeRepository _repository;

    public EmployeeCreateHandler(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(EmployeeCreateCommand request, CancellationToken cancellationToken)
    {
        var employee = new Employee
        {
            Nome = request.Nome,
            Sobrenome = request.Sobrenome,
            Email = request.Email,
            Documento = request.Documento,
            Telefone = request.Telefone,
            NomeDoGestor = request.NomeDoGestor,
            Senha = HashHelper.StringToHash(request.Senha),
            DataCriacao = DateTimeHelper.GetSqlServerSafeDateTime(DateTime.Now),
            Excluido = false
        };


        var id =  await _repository.AddAsync(employee);

        request.Id = id;
        employee.Id = id;

        return id;
    }
}
