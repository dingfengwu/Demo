using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NJLFramework.Base
{
    public class KeyValue
    {
        public string Value { get; set; }
        public string Key { get; set; }

        public override int GetHashCode()
        {
            return $"{Key}={Value}".GetHashCode();
        }
    }
}
