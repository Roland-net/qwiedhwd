using Domain.Interfaces;
using Domain.Models;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    internal class BaggageRepository : RepositoryBase<Baggage>, IBaggageRepository
    {
        public BaggageRepository(RolandContext repositoryContext)
            : base(repositoryContext)
        {

        }
    }
}
