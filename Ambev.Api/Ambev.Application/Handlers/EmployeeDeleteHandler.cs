using Ambev.Application.Commands;
using Ambev.Domain.Repositories;
using Ambev.Infrastructure.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Application.Handlers
{
    public class EmployeeDeleteHandler : IRequestHandler<EmployeeDeleteCommand, int>
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeDeleteHandler(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(EmployeeDeleteCommand request, CancellationToken cancellationToken)
        {
            var employee = await _repository.GetByIdAsync(request.Id);

            if (employee == null)
                throw new Exception("Funcionário não encontrado");

            employee.Excluido = true;
            employee.DataExclusao = DateTimeHelper.GetSqlServerSafeDateTime(DateTime.Now);

            await _repository.UpdateAsync(employee);
            return 1;
        }
    }
}
