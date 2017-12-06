using System;
namespace PRN2_DAPL
{
    public class Fine
    {
        public Fine(DateTime creationDate, decimal ammount, Guid userGuid)
        {
            Id = Guid.NewGuid();
            CreationDate = creationDate;
            Ammount = ammount;
            UserGuid = userGuid;
        }

        public Fine(Guid id, DateTime creationDate, decimal ammount, Guid userGuid)
        {
            Id = id;
            CreationDate = creationDate;
            Ammount = ammount;
            UserGuid = userGuid;
        }

        public Guid Id
        {
            get;
        }

        public DateTime CreationDate 
        {
            get;
        }

        public decimal Ammount 
        {
            get;
        }

        public Guid UserGuid
        {
            get;
        }
    }
}
