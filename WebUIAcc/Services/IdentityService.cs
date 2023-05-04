using Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUIAcc.Services
{
    public class IdentityService : IIdentityService
    {
     
        public async Task<string> GetUserNameAsync(int userId)
        {
            return "Nil";
        }
    }
}
