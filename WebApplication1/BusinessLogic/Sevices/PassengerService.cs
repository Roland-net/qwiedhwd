using Domain.Interface;
using Domain.Wrapper;
using Microsoft.EntityFrameworkCore;
using Domain.Models;


namespace BusinessLogic.Sevices
{
    internal class PassengerService : IPassengerService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public PassengerService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Passenger>> GetAll()
        {
            return await _repositoryWrapper.Passenger.FindAll();
        }

        public async Task<Passenger> GetById(int id)
        {
            var passenger = await _repositoryWrapper.Passenger
                .FindByCondition(x => x.PassengerId == id);
            return passenger.First();
        }

        public async Task Create(Passenger model)
        {
            await _repositoryWrapper.Passenger.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Passenger model)
        {
            _repositoryWrapper.Passenger.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var passenger = await _repositoryWrapper.Passenger
                .FindByCondition(x => x.PassengerId == id);

            _repositoryWrapper.Passenger.Delete(passenger.First());
            _repositoryWrapper.Save();
        }
    }
}
