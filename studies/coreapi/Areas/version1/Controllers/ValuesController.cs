using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace coreapi.Areas.version1.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            //return id.ToString();
            var lst = new 
            {
                Id = id,
                Name = "Item 1",
                Date = DateTime.Now
            };

            return Content(JsonConvert.SerializeObject(lst));
        }
    }
}