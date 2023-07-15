using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SipayBootcamp.HW1.Model;
using System.Numerics;
using System.Xml.Linq;
using static SipayBootcamp.HW1.Controllers.PersonController;

namespace SipayBootcamp.HW1.Controllers;

[Route("api/[controller]s")]
[ApiController]
public class PersonController : ControllerBase
{
    // Defined list property for user data
    private List<Person> list;

    // Dummy Data added in Constructor
    public PersonController()
    {
        list = new();
        list.Add(new Person { Name = "Doğan", Lastname = "Turhan", Phone = "541 322 67 89", AccessLevel = 2, Salary = 6000 });
        list.Add(new Person { Name = "Doğan", Lastname = "Turhan", Phone = "541 322 67 89", AccessLevel = 2, Salary = 6000 });
        list.Add(new Person { Name = "Doğan", Lastname = "Turhan", Phone = "541 322 67 89", AccessLevel = 2, Salary = 6000 });
    }

    // Action Methods added and Service operations done inside them.

    // GET: api/<PersonController>s
    [HttpGet]
    public ApiResponse<List<Person>> Get()
    {
        return new ApiResponse<List<Person>>(list);             // Returns list that I created on constructor.
    }

    // POST api/<PersonController>s
    [HttpPost]
    public ApiResponse<List<Person>> Post([FromBody] Person person)
    {
        list.Add(person);                                       // Entered User data is added to the list.
        return new ApiResponse<List<Person>>(list);             // Returns list.
    }

    // Also created a Response Class.
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
