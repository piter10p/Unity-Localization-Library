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
        public void GetLocalizationTextTest()
        {
            try
            {
                Localization localization = CreateLocalizationFile();
                Assert.AreEqual("test-test", localization.Tag);
                Assert.AreEqual("Test", localization.Name);

                LocalizationText text = localization.GetLocalizationText("textId");
                Assert.AreEqual("textId", text.Id);
                Assert.AreEqual("text", text.Text);

                //Try GetLocalizationText() for bad id value.
                try
                {
                    localization.GetLocalizationText("badId");
                }
                catch(Exception e)
                {
                    Assert.AreEqual("Localization text not found.", e.Message);
                }
            }
            catch(Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        private Localization CreateLocalizationFile()
        {
            List<LocalizationText> localizationTexts = new List<LocalizationText>();
            localizationTexts.Add(new LocalizationText("textId", "text"));

            return new Localization("test-test", "Test", localizationTexts);
        }
    }
}