// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using Microsoft.AspNetCore.Builder;
using System;

namespace NJLFramework.DomainService.Permission
{
    /// <summary>
    /// Extension methods to add OAuth Bearer authentication capabilities to an OWIN application pipeline
    /// </summary>
    public static class OAuthBearerAuthenticationExtensions
    {
        /// <summary>
        /// Adds Bearer token processing to an OWIN application pipeline. This middleware understands appropriately
        /// formatted and secured tokens which appear in the request header. If the Options.AuthenticationMode is Active, the
        /// claims within the bearer token are added to the current request's IPrincipal User. If the Options.AuthenticationMode 
        /// is Passive, then the current request is not modified, but IAuthenticationManager AuthenticateAsync may be used at
        /// any time to obtain the claims from the request's bearer token.
        /// See also http://tools.ietf.org/html/rfc6749
        /// </summary>
        /// <param name="app">The web application builder</param>
        /// <param name="options">Options which control the processing of the bearer header.</param>
        /// <returns>The application builder</returns>
        public static IApplicationBuilder UseOAuthBearerAuthentication(this IApplicationBuilder app, OAuthBearerAuthenticationOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }
            
            app.UseMiddleware<OAuthBearerAuthenticationMiddleware>(options);
            return app;
        }
    }
}
