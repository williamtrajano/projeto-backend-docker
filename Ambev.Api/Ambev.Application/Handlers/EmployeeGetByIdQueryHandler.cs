using Ambev.Application.Queries;
using Ambev.Domain.Entities;
using Ambev.Domain.Repositories;
using MediatR;

namespace Ambev.Application.Handlers
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, Employee>
    {
        private readonly IEmployeeRepository _repository;

        public GetEmployeeByIdQueryHandler(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Employee> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Id);
        }
    }
}
