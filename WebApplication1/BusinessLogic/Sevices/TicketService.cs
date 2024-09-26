using Domain.Interface;
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
    public class TicketService : ITicketService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public TicketService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Ticket>> GetAll()
        {
            return await _repositoryWrapper.Ticket.FindAll();
        }
        public async Task<Ticket> GetById(int id)
        {
            var ticket = await _repositoryWrapper.Ticket
                .FindByCondition(x => x.TicketId == id);
            return ticket.First();
        }
        public async Task Create(Ticket model)
        {
            await _repositoryWrapper.Ticket.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Ticket model)
        {
            _repositoryWrapper.Ticket.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var ticket = await _repositoryWrapper.Ticket
                .FindByCondition(x => x.TicketId == id);

            _repositoryWrapper.Ticket.Delete(ticket.First());
            _repositoryWrapper.Save();
        }
    }
}
