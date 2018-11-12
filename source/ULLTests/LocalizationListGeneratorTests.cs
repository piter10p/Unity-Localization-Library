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
    public class LocalizationListGeneratorTests
    {
        [TestMethod()]
        public void GenerateLocalizationListTest()
        {
            try
            {
                List<Localization> localizationsList;

                LocalizationListGenerator localizationListGenerator = new LocalizationListGenerator();
                localizationsList = localizationListGenerator.GenerateLocalizationList("Localizations");

                Assert.AreEqual(1, localizationsList.Count);

                Localization localization = localizationsList[0];

                Assert.AreEqual("text-text", localization.Tag);
                Assert.AreEqual("Test Language", localization.Name);
            }
            catch(Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}