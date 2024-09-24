﻿using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface ISpecialService
    {
        Task<List<SpecialService>> GetAll();
        Task<SpecialService> GetById(int id);
        Task Create(SpecialService model);

        Task Update(SpecialService model);
        Task Delete(int id);
    }
}
