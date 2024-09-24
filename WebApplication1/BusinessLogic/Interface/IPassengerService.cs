﻿using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IPassengerService
    {
        Task<List<Passenger>> GetAll();
        Task<Passenger> GetById(int id);
        Task Create(Passenger model);

        Task Update(Passenger model);
        Task Delete(int id);
    }
}
