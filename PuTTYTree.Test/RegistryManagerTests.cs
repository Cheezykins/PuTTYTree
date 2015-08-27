using Microsoft.Win32;
using NUnit.Framework;
using System.Collections.Generic;
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
        public void GetSessionsReturnsData()
        {
            RegistryKey hive = Registry.LocalMachine;

            using (RegistryKey regKey = RegistryManager.getKey(hive, goodPath))
            {
                List<RegistryValue> values = RegistryManager.getSession(regKey);

                Assert.IsNotEmpty(values);

                RegistryValue value = (RegistryValue)values.Where(r => r.key.Equals("ProgramFilesDir")).Single();

                Assert.IsInstanceOf<RegistryValue>(value);
                Assert.IsInstanceOf<string>(value.value);
                Assert.IsInstanceOf<RegistryValueKind>(value.kind);
            }
        }

        [Test]
        public void GetSessionsReturnsEmptyOnFail()
        {
            RegistryKey hive = Registry.LocalMachine;

            using (RegistryKey regKey = RegistryManager.getKey(hive, badPath))
            {
                List<RegistryValue> values = RegistryManager.getSession(regKey);
                Assert.IsEmpty(values);
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