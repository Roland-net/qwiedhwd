using Domain.Interface;
using Domain.Models;
using System;
using Domain.Wrapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Sevices
{
    internal class ChangerService : IChangerService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public ChangerService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<ChangeHistory>> GetAll()
        {
            return await _repositoryWrapper.Changer.FindAll();
        }

        public async Task<ChangeHistory> GetById(int id)
        {
            var change = await _repositoryWrapper.Changer
                .FindByCondition(x => x.ChangeId == id);
            return change.First();
        }

        public async Task Create(ChangeHistory model)
        {
            await _repositoryWrapper.Changer.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(ChangeHistory model)
        {
            _repositoryWrapper.Changer.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var cange = await _repositoryWrapper.Changer
                .FindByCondition(x => x.ChangeId == id);

            _repositoryWrapper.Changer.Delete(cange.First());
            _repositoryWrapper.Save();
        }
    }
}
