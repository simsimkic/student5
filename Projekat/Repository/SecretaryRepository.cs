using Model;
using System;

namespace Repository
{
    public class SecretaryRepository : GenericRepository<Secretary>
    {
        internal Secretary GetByEmailAndPassword(string email, string password)
        {
            Secretary secretaryFound = null;
            foreach (Secretary secretary in GetAll())
                if (secretary.Email.Equals(email) & secretary.Password.Equals(password))
                    secretaryFound = secretary;
            return secretaryFound;
        }
    }
}