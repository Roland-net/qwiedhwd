using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    internal interface IFlightService
    {
        Task<List<Flight>> GetAll();
        Task<Flight> GetById(int id);
        Task Create(Flight model);

        Task Update(Flight model);
        Task Delete(int id);
    }
}
