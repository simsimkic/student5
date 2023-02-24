using Model;
using System;

namespace Repository
{
    public class WardenRepository : GenericRepository<Warden>
    {
        internal Warden GetByEmailAndPassword(string email, string password)
        {
            Warden wardenFound = null;
            foreach (Warden warden in GetAll())
                if (warden.Email.Equals(email) & warden.Password.Equals(password))
                    wardenFound = warden;
            return wardenFound;
        }
    }
}