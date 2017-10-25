using AutoMax.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMax.Models.Interfaces
{
    public interface IUser
    {
        User GetUser(string email, string password);
        List<User> GetAll();
    }
}
