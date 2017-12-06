using System;
using System.Collections.Generic;
namespace PRN2_DAPL
{
    public abstract class LibUser : IPerson, IUser
    {
        private string firstName;
        private string lastName;
        private string username;
        private Guid accountNumber;

        public LibUser(string firstName, string lastName, string username)
        {
            this.accountNumber = Guid.NewGuid();
            this.firstName = firstName;
            this.lastName = lastName;
            this.username = username;
        }

        public LibUser(Guid accountNumber, string firstName, string lastName, string username)
        {
            this.accountNumber = accountNumber;
            this.firstName = firstName;
            this.lastName = lastName;
            this.username = username;
        }

        public virtual Privilege Privilege => Privilege.NO_LOAN;

        public string Rights
        {
            get
            {
                string rights = "devolucion, pago de multas";
                switch (this.Privilege)
                {
                    case Privilege.NO_LOAN:
                        rights = "Sin privilegios";
                        break;

                    case Privilege.LOCAL_LOAN:
                        rights += ", prestamo local";
                        break;

                    case Privilege.DOM_LOAN:
                        rights += ", prestamo local, prestamo a domicilio";
                        break;
                    default:
                        rights = "Sin privilegios";
                        break;
                }
                return rights;
            }
        }

        public abstract string GeneralInfo
        {
            get;
        }

        public string FirstName => firstName;

        public string LastName => lastName;

        public string FullName => this.firstName + " " + this.lastName;

        public string Username => username;

        public Guid AccountNumber => accountNumber;
    }
}
