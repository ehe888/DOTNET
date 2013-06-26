using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPISample.Models;
using WebAPISample.DAO;
using Spring.Transaction.Interceptor;
using WebAPISample.DTO;
using AutoMapper;

namespace WebAPISample.Areas.Admin.Controllers
{
    public class UsersController : ApiController
    {

        private INHibernateDao<User> UserDao { get; set; }

        // GET api/users
        public IEnumerable<string> Get()
        {

            return new string[] { "value1", "value2" };
        }

        // GET api/users/5
        [Transaction(ReadOnly=true)]
        public UserDTO Get(long id)
        {
            User user = UserDao.Get(id);
            Mapper.CreateMap<User, UserDTO>();
            UserDTO userDTO = Mapper.Map<UserDTO>(user);

            return userDTO;
        }

        // POST api/users
        public void Post([FromBody]string value)
        {
        }

        // PUT api/users/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/users/5
        public void Delete(int id)
        {
        }
    }
}
