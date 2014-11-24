using NHibernate;
using NHibernateLabb.Entities;
using NHibernateLabb.NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NHibernateLabb.Controllers
{
    [RoutePrefix("users/{username}/orders")]
    public class OrderController : ApiController
    {
        private ISession _session;

        public OrderController()
        {
            _session = SessionFactory.Instance.OpenSession();
        }

        [Route]
        public IEnumerable<Order> Get(string username)
        {
            User userAlias = null;
            Order orderAlias = null;

            return _session.QueryOver(() => orderAlias)
                           .JoinAlias(() => orderAlias.User, () => userAlias)
                           .Where(() => userAlias.Name == username)
                           .List();
        }

        [Route("{id:guid}")]
        public Order Get(string username, Guid id)
        {
            return GetOrderBy(username, id);
        }

        [Route]
        public void Post(string username, Order order)
        {
            var user = _session.QueryOver<User>()
                               .Where(x => x.Name == username)
                               .SingleOrDefault();

            if (user == null)
                return;

            using (var trans = _session.BeginTransaction())
            {
                order.User = user;
                _session.Save(order);
                trans.Commit();
            }
        }

        [Route("{id:guid}")]
        public void Put(string username, Guid id, [FromBody]Order order)
        {
            var orderToUpdate = GetOrderBy(username, id);

            if (orderToUpdate != null)
            {
                using (var trans = _session.BeginTransaction())
                {
                    order.User = orderToUpdate.User;
                    order.Id = id;
                    _session.Merge(order);
                    trans.Commit();
                }
            }
        }

        [Route("{id:guid}")]
        public void Delete(string username, Guid id)
        {
            var orderToDelete = GetOrderBy(username, id);

            if (orderToDelete != null)
                _session.Delete(orderToDelete);
        }

        private Order GetOrderBy(string username, Guid id)
        {
            User userAlias = null;
            Order orderAlias = null;

            return _session.QueryOver(() => orderAlias)
                           .JoinAlias(() => orderAlias.User, () => userAlias)
                           .Where(() => userAlias.Name == username)
                           .And(() => orderAlias.Id == id)
                           .SingleOrDefault();
        }
    }
}
