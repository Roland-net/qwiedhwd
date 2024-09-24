using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    internal class ReviewRepository : RepositoryBase<Review>, IReviewRepository
    {
        public ReviewRepository(RolandContext repositoryContext)
            : base(repositoryContext)
        {

        }
    }
}
