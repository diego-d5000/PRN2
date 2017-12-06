using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PRN2_DAPL
{
    // Clase que representa almacenamiento general durante el programa
    // Se utiliza el patron Singleton para obtener una unica instancia de almacenamiento
    class InMemoryDB
    {
        private Dictionary<string, Dictionary<Guid, object>> db;

        private static readonly InMemoryDB instance = new InMemoryDB();

        // El unico constructor, privado, inicializa el diccionario que representa el almacenamiento
        // y agrega un sub diccionario con la clave User
        private InMemoryDB()
        {
            this.db = new Dictionary<string, Dictionary<Guid, object>>();
            this.db.Add("User", new Dictionary<Guid, object>());
            this.db.Add("Fine", new Dictionary<Guid, object>());
        }

        ~InMemoryDB()
        {
            this.db.Remove("User");
            this.db.Remove("Fine");
            this.db = null;
        }

        public static InMemoryDB Instance
        {
            get => instance;
        }

        public void LoadDatabase(Dictionary<Guid, object> UserDb, Dictionary<Guid, object> FineDb)
        {
            this.db["User"] = UserDb;
            this.db["Fine"] = FineDb;
        }

        public Dictionary<Guid, object> GetAllUsers()
        {
            return this.db["User"];
        }

        // Metodo para obtener un usuario por su id (GUID)
        public LibUser GetUserByGuid(Guid userGuid)
        {
            Dictionary<Guid, Object> userTable = this.db["User"];

            if (userTable.ContainsKey(userGuid))
            {
                return (LibUser)this.db["User"][userGuid];
            }
            else return null;
        }

        // Se busca al usuario por su nombre de usuario
        public LibUser GetUserByUsername(string username)
        {
            Dictionary<Guid, Object> userTable = this.db["User"];

            foreach(LibUser user in userTable.Values)
            {
                if(user.Username == username)
                {
                    return user;
                }
            }

            return null;
        }

        // Se guarda al usuario en el almacenamiento
        public void SaveUser(LibUser user)
        {
            Dictionary<Guid, Object> userTable = this.db["User"];

            if (!userTable.ContainsKey(user.AccountNumber))
            {
                userTable.Add(user.AccountNumber, user);
            }
            else
            {
                userTable[user.AccountNumber] = user;
            };
        }

        public void SaveFine(Fine fine)
        {
            Dictionary<Guid, Object> fineTable = this.db["Fine"];
            fineTable.Add(fine.Id, fine);
        }

        public List<Fine> GetUserFines(RegisteredUser user)
        {
            Dictionary<Guid, object> finesTable = this.db["Fine"];

            return finesTable.Values.Where((fine) => (fine as Fine).UserGuid == user.AccountNumber).Select(f => (Fine)f).ToList();
        }

        public void DeleteFine(Fine fine)
        {
            Dictionary<Guid, object> finesTable = this.db["Fine"];
            finesTable.Remove(fine.Id);
        }
    }
}
