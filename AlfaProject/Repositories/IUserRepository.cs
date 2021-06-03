using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AlfaProject.Models;

namespace AlfaProject.Repositories
{
    public interface IUserRepository : IRepository
    {
        Task<string> Insert(User model);
        Task<int> Delete(string id);
        Task<int> Update(User model);
        Task<User> GetById(string id);
        Task<IEnumerable<User>> GetAll();
    }
}