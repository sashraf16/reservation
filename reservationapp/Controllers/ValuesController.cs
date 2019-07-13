using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using reservationapp.models;
using reservationapp.services;

namespace reservationapp.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase {
        private manageBookings _manager = new manageBookings ();
        private updateBookings _updater = new updateBookings();
        // GET api/values
        [HttpGet]
        public ActionResult<List<string>> Get () {

            List<string> openCamps = new List<string> ();
            fullsearch testobj4;
            
            using (StreamReader r = new StreamReader (@"./bookings/test-case2.json")) {
                string json = r.ReadToEnd ();
                testobj4 = JsonConvert.DeserializeObject<fullsearch> (json);
            }
            openCamps = _manager.findCampgrounds (testobj4);

            System.Console.WriteLine ("printing results");
            foreach (string c in openCamps) {
                System.Console.WriteLine (c);
            }
            return openCamps;
        }

        // GET api/values/5
        [HttpGet ("{id}")]
        public ActionResult<string> Get (int id) {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post ([FromBody] search value) {
            System.Console.WriteLine ("angular?");

            _updater.updateBooking(value);
        }

        // PUT api/values/5
        [HttpPut ("{id}")]
        public void Put (int id, [FromBody] string value) { }

        // DELETE api/values/5
        [HttpDelete ("{id}")]
        public void Delete (int id) { }
    }
}