using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibaryApiCodes;
using Microsoft.AspNetCore.Mvc;

namespace LibaryWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private IServiceEntryStudent _serviceEntryStudent;

        public StudentController(IServiceEntryStudent serviceEntryStudent)
        {
            _serviceEntryStudent = serviceEntryStudent;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        [ActionName("Post")]
        public void Post([FromBody] string value)
        {
        }


        [HttpPost]
        [ActionName("PostStudent")]
        public void PostStudent([FromBody] string[] values)
        {
            _serviceEntryStudent.InsertStudent(values);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
