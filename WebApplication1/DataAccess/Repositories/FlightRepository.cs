﻿using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    internal class FlightRepository : RepositoryBase<Flight>, IFlightRepository
    {
        public FlightRepository(RolandContext repositoryContext)
            : base(repositoryContext)
        {

        }
    }
}
