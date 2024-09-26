using Domain.Interface;
using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
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

        public async Task<List<SpecialService>> GetAll()
        {
            return await _repositoryWrapper.Special.FindAll();
        }
        public async Task<SpecialService> GetById(int id)
        {
            var special = await _repositoryWrapper.Special
                .FindByCondition(x => x.ServiceId == id);
            return special.First();
        }
        public async Task Create(SpecialService model)
        {
            await _repositoryWrapper.Special.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(SpecialService model)
        {
            _repositoryWrapper.Special.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var special = await _repositoryWrapper.Special
                .FindByCondition(x => x.ServiceId == id);

            _repositoryWrapper.Special.Delete(special.First());
            _repositoryWrapper.Save();
        }
    }
}
