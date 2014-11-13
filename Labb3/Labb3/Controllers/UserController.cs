using Labb3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace Labb3.Controllers
{
    [RoutePrefix("users")]
    public class UserController : ApiController
    {
        private static Dictionary<int, User> _users;

        public UserController()
        {
            if (_users == null)
                _users = new Dictionary<int, User>();
        }

        // GET: users
        [Route]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _users.Values.ToList());
        }

        // GET: users/5
        [Route("{id:int}")]
        public HttpResponseMessage Get(int id)
        {
            if (_users.ContainsKey(id))
                return Request.CreateResponse<User>(HttpStatusCode.OK, _users[id]);
            else
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "User not found");
        }

        // POST: users
        [Route]
        public HttpResponseMessage Post([FromBody]User user)
        {
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            
            SetId(user);
            _users.Add(user.ID, user);

            var response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri, user.ID.ToString());
            return response;
        }
        
        private void SetId(User user)
        {
            if (user.ID > 0 && !_users.ContainsKey(user.ID))
                return;

            user.ID = (_users.Any() ? _users.Max(x => x.Key) + 1 : 1);
        }

        // PUT: users/5
        [HttpPut]
        [Route("{id:int}")]
        public HttpResponseMessage Put(int id, [FromBody]User user)
        {
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);

            if (!_users.ContainsKey(id))
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "User not found");

            user.ID = id;
            _users[id] = user;

            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Headers.Location = new Uri(Request.RequestUri, id.ToString());
            return response;
        }

        // DELETE: users/5
        [Route("{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            _users.Remove(id);

            return Request.CreateResponse(HttpStatusCode.OK, "User deleted");
        }
    }
}
