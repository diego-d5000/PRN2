using System;
using System.Collections.Generic;
using System.Text;

namespace PRN2_DAPL
{
    // clase que representa a un usuario
    class User
    {

        // Tiene campos solicitados, numero de cuenta, nombre y privilegios
        // tambien se le agrega nombre de usuario para que sea facil buscarlo

        private Guid accountNumber;
        private string firstName;
        private string lastName;
        private string username;
        private Privilege privilege;


        // en caso de que el constructor no reciba argumentos crea un usuario anonimo
        public User()
        {
            Guid guid = Guid.NewGuid();
            this.accountNumber = guid;
            this.firstName = "Anonym";
            this.lastName = guid.ToString();
            this.privilege = Privilege.NO_LOAN;
        }

        // sobrecarga de constructor, que crea un usuario a partir de los datos basicos
        // el id y los privilegios se asignan automaticamente
        public User(string firstName, string lastName, string username)
        {
            this.accountNumber = Guid.NewGuid();
            this.firstName = firstName;
            this.lastName = lastName;
            this.username = username;
            this.privilege = Privilege.LOCAL_LOAN;
        }

        // propiedad, para solo leer el nombre de usuario
        public string UserName
        {
            get => username;
        }

        // propiedad para solo leer el numero de cuenta
        public Guid AccountNumber
        {
            get => accountNumber;
        }

        // propiedad para solo leer el nombre completo concatenando el nombre y apellido
        public string FullName
        {
            get => this.firstName + " " + this.lastName;
        }

        // propiedad para obtener la lista (string) de privilegios segun su campo de privilegios
        public string Rights
        {
            get
            {
                string rights = "devolucion, pago de multas";
                switch (this.privilege)
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
                }
                return rights;
            }
        }

        // propiedad para obtener un string con los datos generales del usuario
        public string GeneralInfo
        {
            get => String.Format("Numero de Cuenta: {0} \n" +
                "Nombre de usuario: {1} \n" +
                "Nombre: {2} \n" +
                "Privilegios: {3}", this.accountNumber, this.username, this.FullName, this.Rights);
        }
    }
}
