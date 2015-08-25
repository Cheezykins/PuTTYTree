using Microsoft.Win32;
using NUnit.Framework;
using System.Collections;
using System.Linq;

namespace PuTTYTree.Test
{
    [TestFixture]
    public class RegistryManagerTests
    {
        private static string badPath = @"MyFakeSubClass017895E2-973E-4A13-B9F7-CFF31E187E32";
        private static string goodPath = @"software\\Microsoft\\Windows\\CurrentVersion";

        [Test]
        public void GetKeyReturnsKeyOnSuccess()
        {
            RegistryKey regHive = Registry.LocalMachine;

            using (RegistryKey regKey = RegistryManager.getKey(regHive, goodPath))
            {
                Assert.IsNotNull(regKey);
                Assert.IsInstanceOf<RegistryKey>(regKey);
            }
        }

        [Test]
        public void GetKeyReturnsNullOnFailure()
        {
            RegistryKey regHive = Registry.LocalMachine;

            using (RegistryKey regKey = RegistryManager.getKey(regHive, badPath))
            {
                Assert.IsNull(regKey);
            }
        }

        [Test]
        public void GetValuesReturnsEmptyOnFail()
        {
            RegistryKey hive = Registry.LocalMachine;

            using (RegistryKey regKey = RegistryManager.getKey(hive, badPath))
            {
                Hashtable values = RegistryManager.getValues(regKey);
                Assert.IsEmpty(values);
            }
        }

        [Test]
        public void GetValuesReturnsData()
        {
            RegistryKey hive = Registry.LocalMachine;

            using (RegistryKey regKey = RegistryManager.getKey(hive, goodPath))
            {
                Hashtable values = RegistryManager.getValues(regKey);

                Assert.IsNotEmpty(values);

                RegistryValue value = (RegistryValue)values["ProgramFilesDir"];

                Assert.IsInstanceOf<RegistryValue>(value);
                Assert.IsInstanceOf<string>(value.value);
                Assert.IsInstanceOf<RegistryValueKind>(value.kind);
            }
        }

        [Test]
        public void GetSubKeysReturnsEmptyOnFail()
        {
            RegistryKey hive = Registry.LocalMachine;

            using (RegistryKey regKey = RegistryManager.getKey(hive, badPath))
            {
                string[] subkeys = RegistryManager.getSubKeys(regKey);

                Assert.IsEmpty(subkeys);
            }
        }

        [SetUp]
        public void SetUp()
        {
        }
    }
}