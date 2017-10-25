using AutoMax.Models;
using AutoMax.Models.Entities;
using AutoMax.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMax.Repository.Repository
{
    public class UserRepository : IRepository<User>, IDisposable
    {
        private readonly AutoMaxContext _db;
        public UserRepository()
        {
            _db = new AutoMaxContext();
        }
        public IEnumerable<User> List()
        {
            try
            {
                return _db.Users;
            }
            catch (Exception)
            {
                return new List<User>();
            }
        }

        public void Add(User entity)
        {
            try
            {
                _db.Users.Add(entity);
            }
            catch (Exception)
            {
                //
            }
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }

        public User FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
