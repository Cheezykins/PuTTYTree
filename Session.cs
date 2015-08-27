using System;
using System.Collections.Generic;

namespace PuTTYTree
{
    public class Session : List<RegistryValue>
    {
        public string name { get; set; }

        public string cleanName()
        {
            return Uri.UnescapeDataString(name);
        }
    }
}