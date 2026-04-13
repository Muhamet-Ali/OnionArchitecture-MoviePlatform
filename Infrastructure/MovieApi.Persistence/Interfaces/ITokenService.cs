using MovieApi.Persistence.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Persistence.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user, IList<string> roles);

        public interface ITokenService
        {
            string CreateToken(AppUser user, IList<string> roles);
        }
    }
}
