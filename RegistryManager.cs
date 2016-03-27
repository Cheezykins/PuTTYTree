using Microsoft.Win32;

namespace PuTTYTree
{
    public class RegistryManager
    {
        public static RegistryKey getKey(RegistryKey hive, string regPath)
        {
            return hive.OpenSubKey(regPath);
        }

        public static Session getSession(RegistryKey registryKey)
        {
            var ret = new Session();

            if (registryKey != null)
            {
                var valueKeys = registryKey.GetValueNames();

                foreach (var key in valueKeys)
                {
                    var value = new RegistryValue
                    {
                        kind = registryKey.GetValueKind(key),
                        key = key,
                        value = registryKey.GetValue(key).ToString()
                    };

                    ret.Add(value);
                }
            }

            return ret;
        }

        public static string[] getSubKeys(RegistryKey registryKey)
        {
            string[] subKeys = {};

            if (registryKey != null)
            {
                subKeys = registryKey.GetSubKeyNames();
            }

            return subKeys;
        }
    }
}