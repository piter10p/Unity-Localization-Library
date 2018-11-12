using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ULL
{
    public class Localization
    {
        /// <summary>
        /// Language tag e.g. "en-US".
        /// </summary>
        public string Tag { get; private set; }

        /// <summary>
        /// Language name e.g. "English (United States)".
        /// </summary>
        public string Name { get; private set; }

        private List<LocalizationText> localizationTextsList;

        public Localization(string tag, string name, List<LocalizationText> localizationTextsList)
        {
            this.Tag = tag;
            this.Name = name;
            this.localizationTextsList = localizationTextsList;
        }

        /// <summary>
        /// Finds and returns Localization Text with specified id. In none found, throws Exception.
        /// </summary>
        /// <param name="id">Id of Localization Text to looking for.</param>
        /// <returns></returns>
        public LocalizationText GetLocalizationText(string id)
        {
            foreach(LocalizationText text in localizationTextsList)
            {
                if (text.Id == id)
                    return text;
            }

            throw new Exception("Localization text not found.");
        }
    }
}
