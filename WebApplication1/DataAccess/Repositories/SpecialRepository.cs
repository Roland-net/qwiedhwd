using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    internal class SpecialRepository : RepositoryBase<SpecialService>,ISpecialRepository
    {
        public SpecialRepository(RolandContext repositoryContext)
            : base(repositoryContext) 
        {

        }


    }
}
