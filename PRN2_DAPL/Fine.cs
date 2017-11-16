using System;
namespace PRN2_DAPL
{
    public class Fine
    {
        public Fine(DateTime creationDate, decimal ammount)
        {
            CreationDate = creationDate;
            Ammount = ammount;
        }

        public DateTime CreationDate 
        {
            get;
        }

        public decimal Ammount 
        {
            get;
        }
    }
}
