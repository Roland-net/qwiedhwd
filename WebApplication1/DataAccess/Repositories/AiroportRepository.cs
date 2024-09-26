using DataAccess.Models;
using Domain.Interfaces;
using Domain.Models;

namespace DataAccess.Repositories
{
    internal class AiroportRepository : RepositoryBase<Airport>, IAirportRepository
    {
        public AiroportRepository(RolandContext repositoryContext)
            : base(repositoryContext)
        {

        }
    }
}
