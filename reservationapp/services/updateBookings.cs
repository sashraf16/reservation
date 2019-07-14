using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using reservationapp.models;
using reservationapp.services;

namespace reservationapp.services 
{
    public class updateBookings : iUpdatebookings 
    {
        public Boolean updateBooking (search dates) 
        {
            string json = File.ReadAllText (@"./bookings/test-case2.json");
            dynamic fullsearch = Newtonsoft.Json.JsonConvert.DeserializeObject (json);
            fullsearch["search"]["startDate"] = dates.startDate;
            fullsearch["search"]["endDate"] = dates.endDate;
            string output = Newtonsoft.Json.JsonConvert.SerializeObject (fullsearch, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText (@"./bookings/test-case2.json", output);


            return true;
        }
    }
}