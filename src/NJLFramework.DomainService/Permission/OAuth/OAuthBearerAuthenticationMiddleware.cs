// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;

namespace NJLFramework.DomainService.Permission
{
    /// <summary>
    /// Bearer authentication middleware component which is added to an OWIN pipeline. This class is not
    /// created by application code directly, instead it is added by calling the the IAppBuilder UseOAuthBearerAuthentication
    /// extension method.
    /// </summary>
    public class OAuthBearerAuthenticationMiddleware : AuthenticationMiddleware<OAuthBearerAuthenticationOptions>
    {
        private readonly string _challenge;

        /// <summary>
        /// Bearer authentication component which is added to an OWIN pipeline. This constructor is not
        /// called by application code directly, instead it is added by calling the the IAppBuilder UseOAuthBearerAuthentication 
        /// extension method.
        /// </summary>
        public OAuthBearerAuthenticationMiddleware(
            RequestDelegate next,
            IOptions<OAuthBearerAuthenticationOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            IDataProtectionProvider dataProtectionProvider)
            : base(next, options,logger,encoder)
        {
            if (!string.IsNullOrWhiteSpace(Options.Challenge))
            {
                _challenge = Options.Challenge;
            }
            else if (string.IsNullOrWhiteSpace(Options.Realm))
            {
                _challenge = "Bearer";
            }
            else
            {
                _challenge = "Bearer realm=\"" + Options.Realm + "\"";
            }

            if (Options.Provider == null)
            {
                Options.Provider = new OAuthBearerAuthenticationProvider();
            }

            if (Options.AccessTokenFormat == null)
            {
                IDataProtector dataProtecter = dataProtectionProvider.CreateProtector("Access_Token");
                Options.AccessTokenFormat = new TicketDataFormat(dataProtecter);
            }

            if (Options.AccessTokenProvider == null)
            {
                Options.AccessTokenProvider = new AuthenticationTokenProvider();
            }
        }

        /// <summary>
        /// Called by the AuthenticationMiddleware base class to create a per-request handler. 
        /// </summary>
        /// <returns>A new instance of the request handler</returns>
        protected override AuthenticationHandler<OAuthBearerAuthenticationOptions> CreateHandler()
        {
            return new OAuthBearerAuthenticationHandler(_challenge);
        }
    }
}
