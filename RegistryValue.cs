using Microsoft.Win32;

namespace PuTTYTree
{
    public class RegistryValue
    {
        public RegistryValueKind kind { get; set; }
        public string value { get; set; }
    }
}