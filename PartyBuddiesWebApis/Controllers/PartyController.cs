using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess.EF;
using DataAccess;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace PartyBuddiesWebApis.Controllers
{
    public class PartyController : Controller
    {

        [AllowAnonymous]
        [Route("Party/Add")]
        public void Add(Party Party)
        {
            Party.PartyDate = DateTime.ParseExact(Party.PartyDateString.Split(' ')[0], "M/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            Party party = PartyDA.Add(Party);
        }


        // Add Otp
        [AllowAnonymous]
        [Route("Party/GetParties")]
        public string GetParties(string Email)
        {
            return JsonConvert.SerializeObject(DataAccess.PartyDA.GetParties(Email));

        }


        [AllowAnonymous]
        [Route("Party/GetUserParties")]
        public string GetUserParties(string Email)
        {
            return JsonConvert.SerializeObject(DataAccess.PartyDA.GetCustomQuery($"Select * from Party Where Email ='{Email}'"));

        }

    }
}