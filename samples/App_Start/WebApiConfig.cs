﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace samples.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.Clear();

            config.Routes.MapHttpRoute(
               name: "HomePageApi",
               routeTemplate: "api/{controller}/{action}/{id}",
               defaults: new{ id = RouteParameter.Optional, controller="Car" }
            );

		}
    }
}