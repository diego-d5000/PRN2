using System;
namespace PRN2_DAPL
{
    public class GuestUser : LibUser
    {
        public GuestUser(string firstName, string lastName, string username) : base(firstName, lastName, username)
        {
        }

        public override Privilege Privilege => Privilege.LOCAL_LOAN;
        public override string GeneralInfo => String.Format("Usuario Invitado \n" +
                "Privilegios: {0}", this.Rights);
    }
}
