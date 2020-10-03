using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstApp.ViewModel
{
    public class AuthenticateResult
    {
        public string Token { get; set; }
        public DateTime? Expiration { get; set; } 
        public string FullName { get; set; }
    }
}
