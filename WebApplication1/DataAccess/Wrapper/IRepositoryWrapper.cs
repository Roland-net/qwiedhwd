using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Wrapper
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        ITicketRepository Ticket { get; }
        ISpecialRepository Special { get; }
        IReviewRepository Review { get; }
        IRoleRepository Role { get; }
        IPassengerRepository Passenger { get; }
        INotificationRepository Notification { get; }
        IFlightRepository Flight { get; }
        void Save();
    }
}
