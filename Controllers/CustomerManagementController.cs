using Microsoft.AspNetCore.Mvc;


namespace epayCustomerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerManagementController : ControllerBase
    {
        static List<Customer> customer = new List<Customer>();
        //Declaring the list of first names and last names provided in the appendix to generate Random names
        private static readonly string[] lastnames = new[]
        {
        "Liberty", "Ray", "Harrison", "Ronan", "Drew", "Powell", "Larsen", "Chan", "Anderson", "Lane"
    };
        private static readonly string[] firstnames = new[]
        {
        "Leia", "Saddie", "Jose", "Sara", "Frank", "Dewey", "Tomas", "Joel", "Lukas", "Carlos"
    };
        // GET: api/<CustomerManagementController>
        [HttpGet("/GetAll")]
        public IEnumerable<Customer> GetAll()
        {
            //Using orderby to sort the list of customers.
            customer.OrderBy(user => user.lastname).ThenBy(user => user.firstname).ToList();
            return customer;
        }


        // POST api/<CustomerManagementController>
        [HttpPost]
        public IEnumerable<Customer> Post([FromBody] Customer value)
        {
            List<Customer> list3 = new List<Customer>();
            //Generate random list of upto 2 customers from the  appendix data
            list3 = Enumerable.Range(1, 2).Select(index => new Customer
            {
                lastname = lastnames[Random.Shared.Next(lastnames.Length)],
                firstname = firstnames[Random.Shared.Next(firstnames.Length)],
                age = Random.Shared.Next(18, 90),
                id = 1
            })
         .ToList();
            customer.Add(value);
            return customer.Concat(list3);
        }

        
       
    }
}
