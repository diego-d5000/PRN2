using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PRN2_DAPL
{
    public class RegisteredUser : LibUser
    {
        private List<Fine> fines = new List<Fine>();

        public RegisteredUser(string firstName, string lastName, string username) : base(firstName, lastName, username)
        {
        }

        public List<Fine> Fines
        {
            get => fines;
        }

        public void AddFine(Fine fine) {
            this.fines.Add(fine);
        }

        public void RemoveFine(int index) {
            this.fines.RemoveAt(index);
        }

        public decimal TotalFines => this.fines.Select(fine => fine.Ammount).Aggregate(0m, (a, b) => a + b);

        public override Privilege Privilege => Privilege.DOM_LOAN;

        public override string GeneralInfo => String.Format("Numero de Cuenta: {0} \n" +
                "Nombre de usuario: {1} \n" +
                "Nombre: {2} \n" +
                "Privilegios: {3} \n" + 
                "Total Multas: {4}", this.AccountNumber, this.Username, this.FullName, this.Rights, this.TotalFines);
    }
}
