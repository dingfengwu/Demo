// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http;

namespace NJLFramework.DomainService.Permission
{
    /// <summary>
    /// Provides context information used in validating an OAuth token request.
    /// </summary>
    public class OAuthValidateTokenRequestContext : BaseValidatingContext<OAuthAuthorizationServerOptions>
    {
        private Microsoft.AspNetCore.Http.HttpContext context;
        private OAuthAuthorizationServerOptions options;
        private TokenEndpointRequest tokenEndpointRequest;

        /// <summary>
        /// Initializes a new instance of the <see cref="OAuthValidateTokenRequestContext"/> class
        /// </summary>
        /// <param name="context"></param>
        /// <param name="options"></param>
        /// <param name="tokenRequest"></param>
        /// <param name="clientContext"></param>
        public OAuthValidateTokenRequestContext(
            HttpContext context,
            OAuthAuthorizationServerOptions options,
            TokenEndpointRequest tokenRequest,
            BaseValidatingClientContext clientContext) : base(context, options)
        {
            TokenRequest = tokenRequest;
            ClientContext = clientContext;
        }

        /// <summary>
        /// Gets the token request data.
        /// </summary>
        public TokenEndpointRequest TokenRequest { get; private set; }

        /// <summary>
        /// Gets information about the client.
        /// </summary>
        public BaseValidatingClientContext ClientContext { get; private set; }
    }
}
