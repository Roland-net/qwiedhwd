using Domain.Interfaces;
using DataAccess.Models;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    internal class CharterRepository : RepositoryBase<Charter>, ICharterRepository
    {
        public CharterRepository(RolandContext repositoryContext)
            : base(repositoryContext)
        {

        }
    }
}
