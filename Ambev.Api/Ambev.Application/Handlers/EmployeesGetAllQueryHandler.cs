using Ambev.Application.Queries;
using Ambev.Domain.Entities;
using Ambev.Domain.Repositories;
using MediatR;
using System;


namespace Ambev.Application.Handlers
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, IEnumerable<Employee>>
    {
        private readonly IEmployeeRepository _repository;

        public GetAllEmployeesQueryHandler(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Employee>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync(e => !e.Excluido);
        }
    }
}
