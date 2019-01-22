using API.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class UserController : ApiController
    {
        public List<User> users = new List<User>
        {
            new User {Id=1,FirstName="Ivan",LastName="Kazashki",Email="Vankata96@mail.bg",Role="admin"},
            new User {Id=2,FirstName="Plamen",LastName="Nikolov",Email="plamkata92@mail.bg",Role="moderator"},
            new User {Id=3,FirstName="Todor",LastName="Aleksandrov",Email="toshkoshefa94@mail.bg",Role="moderator"},
            new User {Id=4,FirstName="Mariq",LastName="Papazova",Email="mara94@mail.bg",Role="user"},
            new User {Id=5,FirstName="Elena",LastName="Marinova",Email="DeteNaDivataPustinq@mail.bg",Role="user"}

        };

        private static Logger logger = LogManager.GetCurrentClassLogger();
        // GET: api/User
        public IEnumerable<User> Get()
        {
            logger.Trace(users);
            return users;
        }

        // GET: api/User/5
        public User Get(int id)
        {
            logger.Trace("User returned" + users.FirstOrDefault(p => p.Id == id));
            return users.FirstOrDefault(p => p.Id == id);

        }


        // POST: api/User
        public void Post([FromBody]User user)
        {
            logger.Warn("User {0} added.", user);
            users.Add(user);

        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]User user)
        {
            if(user==null)
                throw new ArgumentNullException("user not specified");
            user.Id = id;
            int index = users.FindIndex(p => p.Id == user.Id);
            if (index != -1)
            {
                users.RemoveAt(index);
                users.Add(user);
            }
            else
                logger.Warn("User ID not found");
            

        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
            logger.Trace("User {0} removed.", users.FirstOrDefault(p=>p.Id==id));
            users.RemoveAll(p => p.Id == id);
        }
    }
}
