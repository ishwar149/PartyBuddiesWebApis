using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartyBuddiesWebApis.Controllers
{
    public class UserProfileController : Controller
    {
        // GET: UserProfile
        // Add Otp
        [Authorize]
        [Route("api/UserProfile/AddProfile")]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [Route("UserProfile/IsOtpVerified")]
        public bool? IsOtpVerified(DataAccess.EF.UserProfile userProfile)
        {
            return DataAccess.UserProfileDA.GetSingleByEmail(userProfile.Email).IsOtpVerified;
        }


        [AllowAnonymous]
        [Route("UserProfile/GetUserProfile")]
        public string GetUserProfile(string Email)
        {
            return JsonConvert.SerializeObject(DataAccess.UserProfileDA.GetSingleByEmail(Email));

        }
        [AllowAnonymous]
        [Route("UserProfile/UpdateFireBaseToken")]
        public void UpdateFireBaseToken(DataAccess.EF.UserProfile userProfile)
        {
            DataAccess.UserProfileDA.UpdateFireBaseToken(userProfile);

        }
    }
}