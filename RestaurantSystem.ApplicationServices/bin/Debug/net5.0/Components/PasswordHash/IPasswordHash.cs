using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.ApplicationServices.Components.PasswordHash
{
    public interface IPasswordHash
    {
        public string[] Hash(string password);
        public string HashToCheck(string password, string hashedSalt);
    }
}
