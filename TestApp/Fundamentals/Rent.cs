using System;

namespace TestApp
{
    public class Rent
    {
        public User Rentee { get; set; }

        public bool CanReturn(User user)
        {
            if (user == null)
                throw new ArgumentNullException();

            return user.IsAdmin || Rentee == user;            
        }

    }


    public class User
    {
        public bool IsAdmin { get; set; }
    }

}
