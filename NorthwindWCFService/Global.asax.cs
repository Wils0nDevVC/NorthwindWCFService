using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthwindWCFService
{
    public class Global : HttpApplication
    {

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var context = HttpContext.Current;

            // Lógica para manejar solicitudes OPTIONS
            if (context.Request.HttpMethod == "OPTIONS")
            {
                CorsHelper.HandlePreflightRequest(context);
            }
            else
            {
                // Agregar encabezados básicos para solicitudes no OPTIONS
                context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            }
        }
    }

    public static class CorsHelper
    {
        public static void HandlePreflightRequest(HttpContext context)
        {
            context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            context.Response.AddHeader("Access-Control-Allow-Methods", "POST, PUT, DELETE");
            context.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept");
            context.Response.AddHeader("Access-Control-Max-Age", "1728000");
            context.Response.End();

            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                HttpContext.Current.Response.StatusCode = 200;
                HttpContext.Current.Response.End();
            }

        }
    }
}