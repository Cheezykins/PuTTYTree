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
            Session ret = new Session();

            if (registryKey != null)
            {
                string[] valueKeys = registryKey.GetValueNames();

                foreach (string key in valueKeys)
                {
                    RegistryValue value = new RegistryValue()
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
            string[] subKeys = new string[] { };

            if (registryKey != null)
            {
                subKeys = registryKey.GetSubKeyNames();
            }

            return subKeys;
        }
    }
}