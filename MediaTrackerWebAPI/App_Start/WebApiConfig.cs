﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
//using Core;
using System.Data.Entity;
using System.Web.Http.Cors;
using System.Threading.Tasks;
using System.Threading;
using System.Net;

namespace MediaTrackerWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            //var cors = new EnableCorsAttribute("*", "*", "*");
            //config.EnableCors(cors);
            config.MessageHandlers.Add(new PreflightRequestsHandler());

            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }

    public class PreflightRequestsHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.Headers.Contains("Origin") && request.Method.Method == "OPTIONS")
            {
                var response = new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
                response.Headers.Add("Access-Control-Allow-Origin", "*");
                response.Headers.Add("Access-Control-Allow-Headers", "Origin, Content-Type, Accept, Authorization");
                response.Headers.Add("Access-Control-Allow-Methods", "*");
                var tsc = new TaskCompletionSource<HttpResponseMessage>();
                tsc.SetResult(response);
                return tsc.Task;
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}
