using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PRN2_DAPL
{
    public class RegisteredUser : LibUser
    {
        public RegisteredUser(string firstName, string lastName, string username) : base(firstName, lastName, username)
        {
        }

        public RegisteredUser(Guid accountNumber, string firstName, string lastName, string username) : base(accountNumber, firstName, lastName, username)
        {
        }

        public override Privilege Privilege => Privilege.DOM_LOAN;

        public override string GeneralInfo => String.Format("Numero de Cuenta: {0} \n" +
                "Nombre de usuario: {1} \n" +
                "Nombre: {2} \n" +
                "Privilegios: {3} \n", this.AccountNumber, this.Username, this.FullName, this.Rights);
    }
}
