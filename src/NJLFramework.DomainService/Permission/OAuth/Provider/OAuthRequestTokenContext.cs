// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace NJLFramework.DomainService.Permission
{
    /// <summary>
    /// Specifies the HTTP request header for the bearer authentication scheme.
    /// </summary>
    public class OAuthRequestTokenContext : BaseContext
    {
        /// <summary>
        /// Initializes a new <see cref="OAuthRequestTokenContext"/>
        /// </summary>
        /// <param name="context">OWIN environment</param>
        /// <param name="token">The authorization header value.</param>
        public OAuthRequestTokenContext(
            HttpContext context,
            string token)
            : base(context)
        {
            Token = token;
        }

        /// <summary>
        /// The authorization header value
        /// </summary>
        public string Token { get; set; }
    }
}
