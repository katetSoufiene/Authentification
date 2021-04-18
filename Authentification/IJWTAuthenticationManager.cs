using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentification
{
    public interface IJWTAuthenticationManager
    {
        string Authetificate(string username, string password);
    }
}
