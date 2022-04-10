using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;
using Owin;
using PartyBuddiesWebApis.Signalr;

[assembly: OwinStartup(typeof(PartyBuddiesWebApis.Startup))]

namespace PartyBuddiesWebApis
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.Map("/raw-connection", map =>
            {
                // Turns cors support on allowing everything
                // In real applications, the origins should be locked down
                map.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll)
                   .RunSignalR<RawConnection>();
            });

            app.Map("/signalr", map =>
            {
                var config = new HubConfiguration
                {
                    // You can enable JSONP by uncommenting this line
                    // JSONP requests are insecure but some older browsers (and some
                    // versions of IE) require JSONP to work cross domain
                    // EnableJSONP = true
                };

                // Turns cors support on allowing everything
                // In real applications, the origins should be locked down
                map.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll)
                   .RunSignalR(config);
            });

        }

    }
}
