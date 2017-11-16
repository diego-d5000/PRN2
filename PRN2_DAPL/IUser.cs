using System;
namespace PRN2_DAPL
{
    public interface IUser
    {
        string Username 
        {
            get;
        }

        Guid AccountNumber
        {
            get;
        }
    }
}
