using DataAccess;
using DataAccess.EF;
using Microsoft.AspNet.SignalR;
using PartyBuddiesWebApis.Signalr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartyBuddiesWebApis.Controllers
{
    public class UserMessageController : Controller
    {
        private readonly IHubContext<ChatHub> _hubContext;


        public UserMessageController(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        // Add Otp
        [AllowAnonymous]
        [Route("UserMessage/Add")]
        public void Add(UserMessage userMessage)
        {
            userMessage.MessageDate = System.DateTime.Now;
            userMessage.IsRead = false;
            UserMessageDA.Add(userMessage);
            // Send Message using Signalr
            _hubContext.Clients.Client(userMessage.MessageTo).SendChatMessage(userMessage.MessageTo, userMessage.MessageText, userMessage.MessageFrom);
        }
    }
}