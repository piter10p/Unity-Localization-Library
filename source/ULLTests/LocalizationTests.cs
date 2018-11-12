using Microsoft.VisualStudio.TestTools.UnitTesting;
using ULL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ULL.Tests
{
    [TestClass()]
    public class LocalizationTests
    {
        [TestMethod()]
        public void LoadTest()
        {
            try
            {
                LocalizationListGenerator localizationListGenerator = new LocalizationListGenerator();
                Localization localization = localizationListGenerator.GenerateLocalizationList("Localizations")[0];

                localization.Load();
                Assert.AreEqual(2, localization.EntriesCount);

                string entry1 = localization.GetLocalizationEntry("entry1");
                string entry2 = localization.GetLocalizationEntry("entry2");

                Assert.AreEqual("Entry 1 test text.", entry1);
                Assert.AreEqual("More  test text, but for entry 2.", entry2);
            }
            catch(Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}