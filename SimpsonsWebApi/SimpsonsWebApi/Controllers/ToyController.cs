using SimpsonsWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SimpsonsWebApi.Controllers
{
    [Authorize]
    [RoutePrefix("toys")]
    public class ToyController : ApiController
    {
        private static List<Toy> _toys = new List<Toy>();
        
        [AllowAnonymous]
        [Route]
        public IEnumerable<Toy> Get()
        {
            return _toys;
        }

        [Authorize(Roles="Kid")]
        [Route("{name}")]
        public Toy Get(string name)
        {
            return _toys.FirstOrDefault(x => x.Name == name);
        }

        [Authorize(Roles="Kid, Parent")]
        [Route]
        public void Post([FromBody]Toy toy)
        {
            if (User.IsInRole("Parent") || toy.Price < 5)
                _toys.Add(toy);
        }

        [Authorize(Users="Bart")]
        [Route("{name}")]
        public void Delete(string name)
        {
            var toyToDelete =_toys.FirstOrDefault(x => x.Name == name);
            _toys.Remove(toyToDelete);
        }
    }
}
