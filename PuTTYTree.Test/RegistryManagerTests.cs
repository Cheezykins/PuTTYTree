using System.Collections.Generic;
using System.Linq;
using Microsoft.Win32;
using NUnit.Framework;

namespace PuTTYTree.Test
{
    [TestFixture]
    public class RegistryManagerTests
    {
        [SetUp]
        public void SetUp()
        {
        }

        private static readonly string badPath = @"MyFakeSubClass017895E2-973E-4A13-B9F7-CFF31E187E32";
        private static readonly string goodPath = @"software\\Microsoft\\Windows\\CurrentVersion";

        [Test]
        public void GetKeyReturnsKeyOnSuccess()
        {
            var regHive = Registry.LocalMachine;

            using (var regKey = RegistryManager.getKey(regHive, goodPath))
            {
                Assert.IsNotNull(regKey);
                Assert.IsInstanceOf<RegistryKey>(regKey);
            }
        }

        [Test]
        public void GetKeyReturnsNullOnFailure()
        {
            var regHive = Registry.LocalMachine;

            using (var regKey = RegistryManager.getKey(regHive, badPath))
            {
                Assert.IsNull(regKey);
            }
        }

        [Test]
        public void GetSessionsReturnsData()
        {
            var hive = Registry.LocalMachine;

            using (var regKey = RegistryManager.getKey(hive, goodPath))
            {
                List<RegistryValue> values = RegistryManager.getSession(regKey);

                Assert.IsNotEmpty(values);

                var value = values.Where(r => r.key.Equals("ProgramFilesDir")).Single();

                Assert.IsInstanceOf<RegistryValue>(value);
                Assert.IsInstanceOf<string>(value.value);
                Assert.IsInstanceOf<RegistryValueKind>(value.kind);
            }
        }

        [Test]
        public void GetSessionsReturnsEmptyOnFail()
        {
            var hive = Registry.LocalMachine;

            using (var regKey = RegistryManager.getKey(hive, badPath))
            {
                List<RegistryValue> values = RegistryManager.getSession(regKey);
                Assert.IsEmpty(values);
            }
        }

        [Test]
        public void GetSubKeysReturnsEmptyOnFail()
        {
            var hive = Registry.LocalMachine;

            using (var regKey = RegistryManager.getKey(hive, badPath))
            {
                var subkeys = RegistryManager.getSubKeys(regKey);

                Assert.IsEmpty(subkeys);
            }
        }
    }
}