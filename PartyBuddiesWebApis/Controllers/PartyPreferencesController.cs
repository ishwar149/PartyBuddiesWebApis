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
    public class PartyPreferencesController : Controller
    {
        // Add Otp
        [AllowAnonymous]
        [Route("PartyPreferences/Add")]
        public void Add(PartyPreferences PartyPreferences)
        {
            PartyPreferences pref = PartyPreferencesDA.GetSingleByEmail(PartyPreferences.Email);
            if (pref != null)
            {
                PartyPreferences.ID = pref.ID;
                PartyPreferencesDA.Update(pref.ID, PartyPreferences);
            }
            else
                PartyPreferencesDA.Add(PartyPreferences);
        }


        // Add Otp
        [AllowAnonymous]
        [Route("PartyPreferences/GetUserPreferences")]
        public string GetUserPreferences(string Email)
        {
            return JsonConvert.SerializeObject(PartyPreferencesDA.GetSingleByEmail(Email));
        }

    }
}