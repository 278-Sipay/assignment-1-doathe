using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SipayBootcamp.HW1.Model;
using System.Numerics;
using System.Xml.Linq;
using static SipayBootcamp.HW1.Controllers.PersonController;

namespace SipayBootcamp.HW1.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private List<Person> list;

        public PersonController()
        {
            list = new();
            list.Add(new Person { Name = "Doğan", Lastname = "Turhan", Phone = "541 322 67 89", AccessLevel = 2, Salary = 6000 });
            list.Add(new Person { Name = "Doğan", Lastname = "Turhan", Phone = "541 322 67 89", AccessLevel = 2, Salary = 6000 });
            list.Add(new Person { Name = "Doğan", Lastname = "Turhan", Phone = "541 322 67 89", AccessLevel = 2, Salary = 6000 });
        }

        // GET: api/<PersonController>
        [HttpGet]
        public ApiResponse<List<Person>> Get()
        {
            return new ApiResponse<List<Person>>(list);
        }

        // POST api/<PersonController>
        [HttpPost]
        public ApiResponse<List<Person>> Post([FromBody] Person person)
        {
            list.Add(person);
            return new ApiResponse<List<Person>>(list);
        }

        public class ApiResponse<T>
        {
            public T Data { get; set; }
            public bool Success { get; set; }
            public string Message { get; set; }

            public ApiResponse(T Data)
            {
                this.Data = Data;
                this.Success = true;
                this.Message = string.Empty;
            }
        }
    }
}
