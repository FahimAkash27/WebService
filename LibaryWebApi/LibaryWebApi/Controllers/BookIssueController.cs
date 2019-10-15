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
    public class BookIssueController : ControllerBase
    {
        private IServiceBookIssue _serviceBookIssue;
        private IServiceReturnBook _ServiceReturnBook;

        public BookIssueController(IServiceBookIssue serviceBookIssue, IServiceReturnBook serviceReturnBook)
        {
            _serviceBookIssue = serviceBookIssue;
            _ServiceReturnBook = serviceReturnBook;
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
        [ActionName("PostIssueBook")]
        public void PostIssueBook([FromBody] string[] values)
        {
            _serviceBookIssue.IssueBook(values);
        }

        //[HttpPost]
        //[ActionName("ReturnBook")]
        //public void PostReturnBook([FromBody] string[] values)
        //{
        //    _ServiceReturnBook.ReturnBook(values);
        //}

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpPut]
        [ActionName("PutReturnBook")]
        public void PutReturnBook([FromBody] string[] values)
        {
            _ServiceReturnBook.ReturnBook(values);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
