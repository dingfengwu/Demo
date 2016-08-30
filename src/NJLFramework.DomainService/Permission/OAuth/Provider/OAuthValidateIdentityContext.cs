// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace NJLFramework.DomainService.Permission
{
    /// <summary>
    /// Contains the authentication ticket data from an OAuth bearer token.
    /// </summary>
    public class OAuthValidateIdentityContext : BaseValidatingTicketContext<OAuthBearerAuthenticationOptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OAuthValidateIdentityContext"/> class
        /// </summary>
        /// <param name="context"></param>
        /// <param name="options"></param>
        /// <param name="ticket"></param>
        public OAuthValidateIdentityContext(
            HttpContext context,
            OAuthBearerAuthenticationOptions options,
            AuthenticationTicket ticket) : base(context, options, ticket)
        {
        }
    }
}
