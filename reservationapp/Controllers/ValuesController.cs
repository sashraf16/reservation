using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using reservationapp.models;
using reservationapp.services;

namespace reservationapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private manageBookings _manager = new manageBookings();
        // GET api/values
        [HttpGet]
        public ActionResult<fullsearch> Get()
        {
            List<string> hellolist = new List<string>();
            fullsearch testobj4;
            System.Console.WriteLine("hello world");
            using (StreamReader r = new StreamReader(@"./bookings/test-case.json"))
            {
                string json = r.ReadToEnd();
                fullsearch testobj3 = JsonConvert.DeserializeObject<fullsearch>(json);
                // System.Console.WriteLine(json);
                // System.Console.WriteLine(r);
                // System.Console.WriteLine(JsonConvert.SerializeObject(testobj3));
                testobj4 = testobj3;
            }
                // System.Console.WriteLine(JsonConvert.SerializeObject(testobj4));

                hellolist = _manager.findCampgrounds(testobj4);


            // return new string[] { "value1", "value2" };

            // JsonSerializer serializer = new JsonSerializer();

            // fullsearch testobj = serializer.Deserialize<fullsearch>(File.ReadAllText(@"../bookings/test-case.json"));

            // using (StreamReader file = File.OpenText(@"../bookings/test-case.json"))
            // using (JsonTextReader reader = new JsonTextReader(file))
            // {
            //     fullsearch testobj2 = (fullsearch) JToken.ReadFrom(reader);   
            // }

            // fullsearch o1 = JObject.Parse(File.ReadAllText("../bookings/test-case.json"));

            foreach (string c in hellolist)
            {
                System.Console.WriteLine(c);
            }
            return testobj4;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
            System.Console.WriteLine(value);
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
