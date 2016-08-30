// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;

namespace NJLFramework.DomainService.Permission
{
    /// <summary>
    /// Base class used for certain event contexts
    /// </summary>
    public abstract class BaseContext<TOptions>:BaseContext
    {
        protected BaseContext(HttpContext context, TOptions options):base(context)
        {
            Options = options;
        }

        public TOptions Options { get; private set; }
    }
}
