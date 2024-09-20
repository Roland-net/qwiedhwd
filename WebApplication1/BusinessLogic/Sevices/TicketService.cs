using BusinessLogic.Interface;
using DataAccess.Models;
using DataAccess.Wrapper;
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
        public Task<List<Ticket>> GetAll()
        {
            return _repositoryWrapper.Ticket.FindAll().ToListAsync();
        }
        public Task<Ticket> GetById(int id)
        {
            var ticket = _repositoryWrapper.Ticket
                .FindByCondition(x => x.TicketId == id).First();
            return Task.FromResult(ticket);
        }
        public Task Create(Ticket model)
        {
            _repositoryWrapper.Ticket.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(Ticket model)
        {
            _repositoryWrapper.Ticket.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var ticket = _repositoryWrapper.Ticket
                .FindByCondition(x => x.TicketId == id).First();

            _repositoryWrapper.Ticket.Delete(ticket);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}
