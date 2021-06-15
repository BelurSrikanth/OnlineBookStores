using Microsoft.Extensions.Options;
using OnlineBookStore.Interfaces;
using OnlineBookStore.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStore.Security
{
   

    public class OnlineBookStoreAuthentication : IOnlineBookStoreAuthentication
    {
        private IOptions<ApiSecuritySettings> Config { get; }

        //IOptions<T> injection
        public OnlineBookStoreAuthentication(IOptions<ApiSecuritySettings> config)
        {
            Config = config;
        }
        public bool Authenticate(string username, string password)
        {
            //ApiSecurity  
            var ApiUserName = Config.Value.ApiUserName;
            var ApiPassword = Config.Value.ApiPassword;

            return username.Equals(ApiUserName) && password.Equals(ApiPassword);

            //return await Task.Run(() => (username.Equals(BeanzApiUserName) && password.Equals(BeanzApiPassword)));            
        }
    }
}
