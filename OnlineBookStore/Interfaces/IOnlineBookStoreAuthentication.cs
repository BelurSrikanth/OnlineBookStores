using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStore.Interfaces
{
    public interface IOnlineBookStoreAuthentication
    {
        bool Authenticate(string username, string password);
    }
}
