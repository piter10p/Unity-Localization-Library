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

                LocalizationText entry1 = localization.GetLocalizationText("entry1");
                LocalizationText entry2 = localization.GetLocalizationText("entry2");

                Assert.AreEqual("entry1", entry1.Id);
                Assert.AreEqual("Entry 1 test text.", entry1.Text);

                Assert.AreEqual("entry2", entry2.Id);
                Assert.AreEqual("More  test text, but for entry 2.", entry2.Text);
            }
            catch(Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}