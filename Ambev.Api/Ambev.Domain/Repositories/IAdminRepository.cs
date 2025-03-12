using Ambev.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Domain.Repositories
{
    public interface IAdminRepository
    {
        Task<Admin> GetByEmailAsync(string email);
        Task AddAsync(Admin admin);
        Task UpdateAsync(Admin admin);
        Task DeleteAsync(int id);
    }
}
