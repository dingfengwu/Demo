using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using Microsoft.AspNetCore.Localization;

namespace NJLFramework.Base.Model
{
    public class LocalDisplayNameAttribute: DisplayNameAttribute
    {
        string _sourceName;

        public LocalDisplayNameAttribute(string sourceName)
        {
            if (string.IsNullOrWhiteSpace(sourceName))
                throw new ArgumentNullException(nameof(sourceName));


            _sourceName = sourceName;
        }

        public override string DisplayName
        {
            get
            {
                return Resource.ResourceManager.GetString(_sourceName);
            }
        }
    }
}
