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
    public class ProjectController : ApiController
    {
        public List<Project> projects = new List<Project>
        {
            new Project { Id=1,Name="Webshop",AuthorId=1,CustomerId=2},
            new Project { Id=2,Name="Art Shop",AuthorId=1,CustomerId=1},
            new Project { Id=3,Name="Art Galery",AuthorId=2,CustomerId=3},
            new Project { Id=4,Name="Candy shop",AuthorId=3,CustomerId=1},
            new Project { Id=5,Name="Repair site",AuthorId=4,CustomerId=4}
        };
        private static Logger logger = LogManager.GetCurrentClassLogger();
        // GET: api/Project
        public IEnumerable<Project> Get()
        {
            logger.Trace("Projects returned {0}", projects);
            return projects;
        }

        // GET: api/Project/5

        public IEnumerable<Project> GetbyCustomer(int id)
        {
            logger.Trace("Projects bu customer returned {0}", projects.Where(p => p.CustomerId == id));
            return projects.Where(p => p.CustomerId==id);
        }

        // POST: api/Project
        public void Post([FromBody]Project value)
        {
            logger.Trace("Project added {0}", value);
            projects.Add(value);
        }

        // PUT: api/Project/5
        public void Put(int id, [FromBody]Project project)
        {
            if (project == null)
                logger.Error("project not specified");
            project.Id = id;
            int index = projects.FindIndex(p => p.Id == project.Id);
            if (index != -1)
            {
                projects.RemoveAt(index);
                projects.Add(project);
            }
            else
                logger.Error("project not found");
        }

        // DELETE: api/Project/5
        public void Delete(int id)
        {
            logger.Trace("Project {0} removed.", projects.FirstOrDefault(p => p.Id == id));
            projects.RemoveAll(p => p.Id == id);
        }

        public void DeleteByCustomer(int id)
        {
            logger.Trace("Project deleated {0}", projects.FirstOrDefault(p => p.Id == id));
            projects.RemoveAll(p => p.CustomerId == id);
        }
    }
}
