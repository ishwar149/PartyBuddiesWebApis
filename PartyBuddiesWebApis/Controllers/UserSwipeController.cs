using DataAccess;
using DataAccess.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartyBuddiesWebApis.Controllers
{
    public class UserSwipeController : Controller
    {
        // Add Otp
        [AllowAnonymous]
        [Route("UserSwipe/Add")]
        public void Add(UserSwipe userSwipe)
        {
            userSwipe.IsAcceptedNotificationRead = userSwipe.IsAcceptedNotificationSent = userSwipe.IsSwipeNotificationRead = userSwipe.IsSwipeNotificationSent = false;
            userSwipe.OrganiserAction = "None";
            UserSwipeDA.Add(userSwipe);
            DataAccess.FireBaseNotifications.SendPushNotification("Party Buddies", "Ishwar", $"you have got a new Party Request", userSwipe.FireBaseToken, true, false);
        }
    }
}