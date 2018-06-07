using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using nodaserializeation.Controllers.ApiResources;
using nodaserializeation.model;
using NodaTime;

namespace nodaserializeation.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase {

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetNoda () {
            await Task.Delay (10);
            NodaModel nodaModel = new NodaModel ();
            ApiResource apiResource = new ApiResource ();
            Response res = new Response ();

            res.NodaLocalDate = nodaModel.NodaLocalDate = new LocalDate (2018, 06, 06);

            res.NodaLocalDateString = apiResource.NodaLocalDate = nodaModel.NodaLocalDate.ToString ();

            return Ok (res);
        }

        // GET api/values/5
        [HttpGet ("{id}")]
        public ActionResult<string> Get (int id) {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post ([FromBody] string value) { }

        // PUT api/values/5
        [HttpPut ("{id}")]
        public void Put (int id, [FromBody] string value) { }

        // DELETE api/values/5
        [HttpDelete ("{id}")]
        public void Delete (int id) { }

    }
}