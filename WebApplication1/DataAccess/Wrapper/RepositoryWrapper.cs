using DataAccess.Interfaces;
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
       

        private IUserRepository _ticket;
        public IUserRepository Ticket
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

        ITicketRepository IRepositoryWrapper.Ticket => throw new NotImplementedException();

        private RepositoryWrapper(RolandContext repositoryContext)
        {
            _repoContext = repositoryContext;   
        }
        public void Save()
        {
            _repoContext.SaveChanges();
        }
    


    }
}
