using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Controllers;
using NLog;

namespace API.Controllers
{
    
    public class CustomerController : ApiController
    {
        public List<Customer> customers = new List<Customer>
    {
        new Customer {Id=1,Name="Mihail Petrov",CompanyName="Lexoro tech",Address="Veliko Tyrnovo ul.Shipka 7" },
        new Customer {Id=2,Name="Daniel Nikolov",CompanyName="SoftComp",Address="Veliko Tyrnovo ul.Opylchenska 29" },
        new Customer {Id=3,Name="Mihail Petrov",CompanyName="Ubisoft",Address="Veliko Tyrnovo ul.Opylchenska 17" },
        new Customer {Id=4,Name="Mihail Petrov",CompanyName="MarketingSoft",Address="Gabrovo ul.Hristo Botev 8" },
        new Customer {Id=5,Name="Mihail Petrov",CompanyName="PrintSoft",Address="Sofiq ul.Dobrudja 18" }
    };

        private static Logger logger = LogManager.GetCurrentClassLogger();


        // GET: api/Customers
        public IEnumerable<Customer> Get()
        {
            logger.Trace("Customers returned {0}", customers);
            return customers;
        }

        // GET: api/Project/5
        public Customer Get(int id)
        {
            logger.Trace("Customer returned {0}", customers.FirstOrDefault(p => p.Id == id));
            return customers.FirstOrDefault(p => p.Id == id);
        }

        

        // POST: api/Project
        public void Post([FromBody]Customer value)
        {
            logger.Trace("Customer {0} added", value);
            customers.Add(value);
        }

        // PUT: api/Project/5
        public void Put(int id, [FromBody]Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException("Customer not specified");
            customer.Id = id;
            int index = customers.FindIndex(p => p.Id == customer.Id);
            if (index != -1)
            {
                customers.RemoveAt(index);
                customers.Add(customer);
            }
            else
                logger.Trace("Customer not found");
        }

        // DELETE: api/Project/5
        public void Delete(int id)
        {
            logger.Trace("Customer {0} removed.", customers.FirstOrDefault(p => p.Id == id));
            customers.RemoveAll(p => p.Id == id);
        }

        public void DeleteByCustomer(int id)
        {
            logger.Trace("Customer {0} removed.", customers.FirstOrDefault(p => p.Id == id));
            customers.RemoveAll(p => p.Id == id);
        }
    }
}
