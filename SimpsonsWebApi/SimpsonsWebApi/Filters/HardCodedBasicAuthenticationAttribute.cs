using SimpsonsWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;

namespace SimpsonsWebApi.Filters
{
    public class HardCodedBasicAuthenticationAttribute : BasicAuthenticationAttribute
    {
        private IList<GenericPrincipal> _authorizedUsers;

        public HardCodedBasicAuthenticationAttribute()
        {
            var parentRoles = new [] { "Parent" };
            var kidRoles = new [] { "Kid" };

            _authorizedUsers = new List<GenericPrincipal>
            {
                new GenericPrincipal(new UserIdentity("Homer", "bear"), parentRoles),
                new GenericPrincipal(new UserIdentity("Bart", "Ay,Caramba"), kidRoles),
                new GenericPrincipal(new UserIdentity("Lisa", "saxamaphone"), kidRoles),
                new GenericPrincipal(new UserIdentity("Maggie", "pacifier"), kidRoles)
            };
        }

        protected override Task<IPrincipal> AuthenticateAsync(string userName, string password, System.Threading.CancellationToken cancellationToken)
        {
            return Task.Run<IPrincipal>(() =>
                    _authorizedUsers.FirstOrDefault(x => x.Identity.Name.Equals(userName, StringComparison.InvariantCultureIgnoreCase) && 
                                                        (x.Identity as UserIdentity).Password == password));
        }
    }
}