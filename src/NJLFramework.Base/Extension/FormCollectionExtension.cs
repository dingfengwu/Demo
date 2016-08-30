using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NJLFramework.Base
{
    public static class FormCollectionExtension
    {
        /// <summary>
        /// 将IFormCollection转化为IQueryCollection
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static IQueryCollection AsQueryCollection(this IFormCollection @this)
        {
            if (@this == null)
                throw new ArgumentNullException(nameof(@this));

            QueryCollection queryCollection = new QueryCollection();

            foreach (var item in @this)
            {
                queryCollection.Append(item);
            }

            return queryCollection;
        }
    }
}
