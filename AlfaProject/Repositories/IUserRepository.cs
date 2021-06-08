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
        void Create(User model);
        void Update(User model);
        User GetById(string id);
        List<User> GetAll();
    }
}