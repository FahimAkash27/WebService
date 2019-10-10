using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LibaryWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private IServiceBookAdd _serviceBookAdd;

        public BookController(IServiceBookAdd serviceBookAdd)
        {
            _serviceBookAdd = serviceBookAdd;
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
        [ActionName("AddBook")]
        public void PostStudent([FromBody] string[] values)
        {
            _serviceBookAdd.AddBook(values);
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
