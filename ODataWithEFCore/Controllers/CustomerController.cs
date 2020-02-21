using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using ODataWithEFCore.Entity;
using ODataWithEFCore.Infra;
using System.Linq;

namespace ODataWithEFCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ODataController
    {
        protected DataContext _context;

        public CustomerController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Save(Customer customer)
        {
            if (customer != null)
            {
                _context.Add(customer);
                _context.SaveChanges();
                return Created("/api/book/" + customer.Id, customer);
            }

            return BadRequest();
        }

        [EnableQuery]
        public IQueryable<Customer> Get()
        {
            return _context.Customers.AsQueryable();
        }
    }
}
