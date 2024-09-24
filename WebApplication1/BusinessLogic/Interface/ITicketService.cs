﻿using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface ITicketService
    {
        Task<List<Ticket>> GetAll();
        Task<Ticket> GetById(int id);
        Task Create(Ticket model);

        Task Update(Ticket model);
        Task Delete(int id);
    }
}
