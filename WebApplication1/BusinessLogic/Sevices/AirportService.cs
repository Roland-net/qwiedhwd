using Domain.Interface;
using Domain.Models;
using Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Sevices
{
    internal class AirportService : IAirportService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public AirportService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Airport>> GetAll()
        {
            return await _repositoryWrapper.Airport.FindAll();
        }

        public async Task<Airport> GetById(int id)
        {
            var airport = await _repositoryWrapper.Airport
                .FindByCondition(x => x.AirportId == id);
            return airport.First();
        }

        public async Task Create(Airport model)
        {
            await _repositoryWrapper.Airport.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Airport model)
        {
            _repositoryWrapper.Airport.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var airport = await _repositoryWrapper.Airport
                .FindByCondition(x => x.AirportId == id);

            _repositoryWrapper.Airport.Delete(airport.First());
            _repositoryWrapper.Save();
        }
    }
}
