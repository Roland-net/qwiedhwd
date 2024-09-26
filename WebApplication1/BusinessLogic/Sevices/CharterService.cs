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
    internal class CharterService : ICharterService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public CharterService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Charter>> GetAll()
        {
            return await _repositoryWrapper.Charter.FindAll();
        }

        public async Task<Charter> GetById(int id)
        {
            var charter = await _repositoryWrapper.Charter
                .FindByCondition(x => x.CharterId == id);
            return charter.First();
        }

        public async Task Create(Charter model)
        {
            await _repositoryWrapper.Charter.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Charter model)
        {
            _repositoryWrapper.Charter.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var charter = await _repositoryWrapper.Charter
                .FindByCondition(x => x.CharterId == id);

            _repositoryWrapper.Charter.Delete(charter.First());
            _repositoryWrapper.Save();
        }
    }
}
