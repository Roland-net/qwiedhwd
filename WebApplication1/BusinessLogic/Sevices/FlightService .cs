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
    internal class FlightService : IFlightService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public FlightService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Flight>> GetAll()
        {
            return await _repositoryWrapper.Flight.FindAll();
        }

        public async Task<Flight> GetById(int id)
        {
            var flight = await _repositoryWrapper.Flight
                .FindByCondition(x => x.FlightId == id);
            return flight.First();
        }

        public async Task Create(Flight model)
        {
            await _repositoryWrapper.Flight.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Flight model)
        {
            _repositoryWrapper.Flight.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var flight = await _repositoryWrapper.Flight
                .FindByCondition(x => x.FlightId == id);

            _repositoryWrapper.Flight.Delete(flight.First());
            _repositoryWrapper.Save();
        }
    }
}
