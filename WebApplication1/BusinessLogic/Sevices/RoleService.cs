using BusinessLogic.Interface;
using DataAccess.Models;
using System;
using DataAccess.Wrapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Sevices
{
    internal class RoleService : IRoleService
    {
        private IRepositoryWrapper _repositoryWrapper;
        public RoleService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<Role>> GetAll()
        {
            return _repositoryWrapper.Role.FindAll().ToListAsync();
        }
        public Task<Role> GetById(int id)
        {
            var role = _repositoryWrapper.Role
                .FindByCondition(x => x.RoleId == id).First();
            return Task.FromResult(role);
        }
        public Task Create(Role model)
        {
            _repositoryWrapper.Role.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
        public Task Update(Role model)
        {
            _repositoryWrapper.Role.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
        public Task Delete(int id)
        {
            var role = _repositoryWrapper.Role
                .FindByCondition(x => x.RoleId == id).First();

            _repositoryWrapper.Role.Delete(role);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}
