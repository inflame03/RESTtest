using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

using Common.Models;
using RESTTest.Services;

namespace RESTTest.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        private UserRepository userRep;

        public UserController()
        {
            this.userRep = new UserRepository();
        }

        // GET: api/User
        public IEnumerable<User> Get()
        {
            return this.userRep.GetAllUsers();
        }

        // GET: api/User/5
        public User Get(int id)
        {
            return this.userRep.GetUser(id);
        }

        // POST: api/User
        public HttpResponseMessage Post(User userInfo)
        {
            Common.Models.User savedUser = this.userRep.SaveUser(userInfo);

            var response = Request.CreateResponse<User>(System.Net.HttpStatusCode.Created, savedUser);

            return response;
        }

        // PUT: api/User/5
        public HttpResponseMessage Put(User userInfo)
        {
            Common.Models.User savedUser = this.userRep.SaveUser(userInfo);

            var response = Request.CreateResponse<User>(System.Net.HttpStatusCode.Created, savedUser);

            return response;
        }

        // DELETE: api/User/5
        public HttpResponseMessage Delete(int id)
        {
            bool result = this.userRep.DeleteUser(id);

            HttpResponseMessage response = null;

            if ( result )
                response = Request.CreateResponse<int>(System.Net.HttpStatusCode.Accepted, id);
            else
                response = Request.CreateResponse<bool>(System.Net.HttpStatusCode.Accepted, result);

            return response;
        }
    }
}
