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
    internal class FlightService : IFlightService
    {
        private IRepositoryWrapper _repositoryWrapper;
        public FlightService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<Flight>> GetAll()
        {
            return _repositoryWrapper.Flight.FindAll().ToListAsync();
        }
        public Task<Flight> GetById(int id)
        {
            var flight = _repositoryWrapper.Flight
                .FindByCondition(x => x.FlightId == id).First();
            return Task.FromResult(flight);
        }
        public Task Create(Flight model)
        {
            _repositoryWrapper.Flight.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
        public Task Update(Flight model)
        {
            _repositoryWrapper.Flight.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
        public Task Delete(int id)
        {
            var flight = _repositoryWrapper.Flight
                .FindByCondition(x => x.FlightId == id).First();

            _repositoryWrapper.Flight.Delete(flight);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}
