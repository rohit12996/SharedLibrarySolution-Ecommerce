using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.SharedLibrary.Middleware
{
    public class ListenToOnlyApiGateway(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            //Extrct specific header from the request  
            var signedHeader = context.Request.Headers["Api-Gateway"];

            // Null means , the request is not coming from api gateway
            if(signedHeader.FirstOrDefault() is null)
            {
                context.Response.StatusCode = StatusCodes.Status503ServiceUnavailable;
                await context.Response.WriteAsync("Sorry , Services is unavailable");
                return;
            }
            else
            {
                await next(context);
            }
        }
    }
    
}
