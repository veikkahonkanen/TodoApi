using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizationAttribute : Attribute, IResourceFilter
    {
        private const string AuthorizationHeaderKey = "Authorization";
        private const string AuthorizationKeyValue = "salainenAvain";
        private readonly string conditionalKey;

        /// <summary>
        /// Uses default authorization
        /// </summary>
        public AuthorizationAttribute()
        {

        }

        /// <summary>
        /// Override default authorization and give your own authorization key to validate access
        /// </summary>
        /// <param name="conditionalKey"></param>
        public AuthorizationAttribute(string conditionalKey)
        {
            this.conditionalKey = conditionalKey;
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            // throw new NotImplementedException();
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            // throw new NotImplementedException();

            /* The code below is the same as the code in comments
             * var token2 = new object();

            if (!context.HttpContext.Request.Headers.ContainsKey("Authorization"))
            {
                token2 = context.HttpContext.Request.Headers.Single(x => x.Key == "Authorization").Value;
            }
            else
            {
                context.Result = new UnauthorizedResult();
            }*/

            if (!context.HttpContext.Request.Headers.TryGetValue(AuthorizationHeaderKey, out var secretKey))
            {
                context.Result = new UnauthorizedResult();
            }

            /* string.IsNullOrEmpty
            if (conditionalKey != null && conditionalKey != "" && conditionalKey.Length > 0)
            {

            }*/

            if (!string.IsNullOrEmpty(conditionalKey))
            {
                if (secretKey != conditionalKey)
                {
                    context.Result = new UnauthorizedResult();
                }
            }

            else
            {
                if (secretKey != AuthorizationKeyValue)
                {
                    context.Result = new UnauthorizedResult();
                }
            }

            
        }
    }
}
