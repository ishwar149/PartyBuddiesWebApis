using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess.EF;
using DataAccess;
using System.Web.Mvc;

namespace PartyBuddiesWebApis.Controllers
{
    public class OtpController : Controller
    {
        // Add Otp
        [AllowAnonymous]
        [Route("Otp/VerifyOtp")]
        public bool VerifyOtp(Otp requestotp)
        {
            Otp dbotp = DataAccess.OtpDA.GetSingleByEmail(requestotp.Email);
            if (requestotp.GeneratedOtp == dbotp.GeneratedOtp)
            {
                UserProfile userprofile = UserProfileDA.GetSingleByEmail(requestotp.Email);
                userprofile.IsOtpVerified = true;
                UserProfileDA.Update(userprofile.ID, userprofile);
                return true;
            }
            else
                return false;

        }

    }
}