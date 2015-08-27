using Microsoft.Win32;

namespace PuTTYTree
{
    public class RegistryValue
    {
        public string key { get; set; }
        public RegistryValueKind kind { get; set; }
        public string value { get; set; }
    }
}