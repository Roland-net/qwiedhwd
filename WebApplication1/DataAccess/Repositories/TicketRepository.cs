using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    internal class TicketRepository : RepositoryBase<User>, ITicketRepository
    {
        public TicketRepository(RolandContext repositoryContext)
            : base(repositoryContext)
        {

        }
    }
}
