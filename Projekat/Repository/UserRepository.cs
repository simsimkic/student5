using Model;
using System;

namespace Repository
{
   public class UserRepository : GenericRepository<User>
   {
      public User GetUserByEmailAndPassword(String email, String password)
      {
         throw new NotImplementedException();
      }
   
   }
}