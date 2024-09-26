using Domain.Interfaces;
using DataAccess.Models;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace DataAccess.Repositories
{
    internal class BookingRepository : RepositoryBase<Booking>, IBookingRepository
    {
        public BookingRepository(RolandContext repositoryContext)
            : base(repositoryContext)
        {

        }
    }
}
