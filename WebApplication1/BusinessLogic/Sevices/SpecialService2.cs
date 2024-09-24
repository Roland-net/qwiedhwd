using BusinessLogic.Interface;
using DataAccess.Interfaces;
using DataAccess.Models;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Sevices
{
    public class SpecialService2 : ISpecialService
    {
        private IRepositoryWrapper _repositoryWrapper;
        public SpecialService2(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public Task<List< SpecialService>> GetAll()
        {
            return _repositoryWrapper.Special.FindAll().ToListAsync();
        }
        public Task<SpecialService> GetById(int id)
        {
            var specialRepository = _repositoryWrapper.Special
                .FindByCondition(x => x.ServiceId == id).First();
            return Task.FromResult(specialRepository);
        }
        public Task Create(SpecialService model)
        {
            _repositoryWrapper.Special.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(SpecialService model)
        {
            _repositoryWrapper.Special.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var specialRepository = _repositoryWrapper.Special
                .FindByCondition(x => x.ServiceId == id).First();

            _repositoryWrapper.Special.Delete(specialRepository);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}
