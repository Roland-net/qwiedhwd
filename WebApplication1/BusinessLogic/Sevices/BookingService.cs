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
    internal class BookingService : IBookingService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public BookingService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Booking>> GetAll()
        {
            return await _repositoryWrapper.Booking.FindAll();
        }

        public async Task<Booking> GetById(int id)
        {
            var booking = await _repositoryWrapper.Booking
                .FindByCondition(x => x.BookingId == id);
            return booking.First();
        }

        public async Task Create(Booking model)
        {
            await _repositoryWrapper.Booking.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Booking model)
        {
            _repositoryWrapper.Booking.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var booking = await _repositoryWrapper.Booking
                .FindByCondition(x => x.BookingId == id);

            _repositoryWrapper.Booking.Delete(booking.First());
            _repositoryWrapper.Save();
        }
    }
}
