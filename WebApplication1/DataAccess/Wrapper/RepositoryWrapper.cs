﻿using DataAccess.Interfaces;
using DataAccess.Models;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RolandContext _repoContext;
        private IUserRepository _user;
        private ITicketRepository _ticket;
        private RepositoryWrapper(RolandContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_repoContext);
                }
                return _user;
            }
        }
       

       
        public ITicketRepository Ticket
        {
            get
            {
                if (_ticket == null)
                {
                    _ticket = new TicketRepository(_repoContext);
                }
                return _ticket;
            }
        }
        private ISpecialRepository _special;
        public ISpecialRepository Special
        {
            get
            {
                if (_special == null)
                {
                    _special = new SpecialRepository(_repoContext);
                }
                return _special;
            }
        }
        private IRoleRepository _role;
        public IRoleRepository Role
        {
            get
            {
                if (_role == null)
                {
                    _role = new RoleRepository(_repoContext);
                }
                return _role;
            }
        }
        private IReviewRepository _review;
        public IReviewRepository Review
        {
            get
            {
                if (_review == null)
                {
                    _review = new ReviewRepository(_repoContext);
                }
                return _review;
            }
        }
        private IPassengerRepository _passenger;
        public IPassengerRepository Passenger
        {
            get
            {
                if (_passenger == null)
                {
                    _passenger = new    PassengerRepository(_repoContext);
                }
                return _passenger;
            }
        }
        private INotificationRepository _notification;
        public INotificationRepository Notification
        {
            get
            {
                if (_notification == null)
                {
                    _notification = new NotificationRepository(_repoContext);
                }
                return _notification;
            }
        }
        private IFlightRepository _flight;
        public IFlightRepository Flight
        {
            get
            {
                if (_flight == null)
                {
                    _flight = new FlightRepository(_repoContext);
                }
                return _flight;
            }
        }




        public void Save()
        {
            _repoContext.SaveChanges();
        }
    


    }
}
