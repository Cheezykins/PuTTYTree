using Microsoft.Win32;
using System.Collections;
using System.Collections.Generic;

namespace PuTTYTree
{
    public class RegistryManager
    {
        public static RegistryKey getKey(RegistryKey hive, string regPath)
        {
            return hive.OpenSubKey(regPath);
        }

        public static Hashtable getValues(RegistryKey registryKey)
        {
            Hashtable ret = new Hashtable();

            if (registryKey != null)
            {

                string[] valueKeys = registryKey.GetValueNames();

                foreach (string key in valueKeys)
                {
                    RegistryValue value = new RegistryValue()
                    {
                        kind = registryKey.GetValueKind(key),
                        value = (string)registryKey.GetValue(key)
                    };

                    ret.Add(key, value);
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