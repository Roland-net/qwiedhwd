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
    internal class PassengerService : IPassengerService
    {
        private IRepositoryWrapper _repositoryWrapper;
        public PassengerService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<Passenger>> GetAll()
        {
            return _repositoryWrapper.Passenger.FindAll().ToListAsync();
        }
        public Task<Passenger> GetById(int id)
        {
            var passenger = _repositoryWrapper.Passenger
                .FindByCondition(x => x.PassengerId == id).First();
            return Task.FromResult(passenger);
        }
        public Task Create(Passenger model)
        {
            _repositoryWrapper.Passenger.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
        public Task Update(Passenger model)
        {
            _repositoryWrapper.Passenger.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
        public Task Delete(int id)
        {
            var passenger = _repositoryWrapper.Passenger
                .FindByCondition(x => x.PassengerId == id).First();

            _repositoryWrapper.Passenger.Delete(passenger);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}
