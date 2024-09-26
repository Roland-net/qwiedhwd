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
    internal class BaggageService : IBaggageService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public BaggageService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Baggage>> GetAll()
        {
            return await _repositoryWrapper.Baggage.FindAll();
        }

        public async Task<Baggage> GetById(int id)
        {
            var baggage = await _repositoryWrapper.Baggage
                .FindByCondition(x => x.BaggageId == id);
            return baggage.First();
        }

        public async Task Create(Baggage model)
        {
            await _repositoryWrapper.Baggage.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Baggage model)
        {
            _repositoryWrapper.Baggage.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var baggage = await _repositoryWrapper.Baggage
                .FindByCondition(x => x.BaggageId == id);

            _repositoryWrapper.Baggage.Delete(baggage.First());
            _repositoryWrapper.Save();
        }
    }
}
