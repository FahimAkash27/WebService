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
    public class FineController : ControllerBase
    {

        private IServiceFine _serviceFine;

        public FineController(IServiceFine serviceFine)
        {
            _serviceFine = serviceFine;
            
        }

        // GET api/values
        [HttpGet]
        [ActionName("Get")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value111", "value222" };
        }

        // GET api/values
        [HttpGet("{id}")]
        [ActionName("GetFineAmount")]
        public ActionResult<double> GetFineAmount(int id)
        {
               double fine = _serviceFine.ShowFine(id);
               return fine;
            
        }

        //// GET api/values/5
        //[HttpGet]
        //public ActionResult<double> GetFineAmount(int id)
        //{
        //    double fine = _serviceFine.ShowFine(id);
        //    return fine;
        //}

        //[HttpGet("{id}")]
        //[ActionName("ShowStudentFine")]
        //public ActionResult<double> GetShowStudentFine(int id)
        //{
        //   double fine =  _serviceFine.ShowFine(id);
        //    return fine;
        //}

        // POST api/values
        [HttpPost]
        [ActionName("Post")]
        public void Post([FromBody] string value)
        {
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
        [ActionName("PutGiveFine")]
        public void PutGiveFine([FromBody] string[] values)
        {
            _serviceFine.GiveFine(values);
        }


        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
