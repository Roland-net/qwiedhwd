using Domain.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace DataAccess.Repositories
{
    internal class TicketRepository : RepositoryBase<Ticket>, ITicketRepository
    {
        public TicketRepository(RolandContext repositoryContext)
            : base(repositoryContext)
        {

        }
    }
}
