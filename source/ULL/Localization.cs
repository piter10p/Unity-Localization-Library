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

        /// <summary>
        /// Returns count of Localization Texts.
        /// </summary>
        public int EntriesCount
        {
            get
            {
                return localizationTextsList.Count;
            }
        }

        private List<LocalizationText> localizationTextsList;
        private string fileFullPath;
        private bool loaded = false;

        public Localization(string tag, string name, string fileFullPath)
        {
            this.Tag = tag;
            this.Name = name;
            this.fileFullPath = fileFullPath;
        }

        /// <summary>
        /// Finds and returns Localization Text with specified id. Throws Exception when no text was found, or Localization is unloaded.
        /// </summary>
        /// <param name="id">Id of Localization Text to looking for.</param>
        /// <returns></returns>
        public LocalizationText GetLocalizationText(string id)
        {
            if (loaded)
            {
                foreach (LocalizationText text in localizationTextsList)
                {
                    if (text.Id == id)
                        return text;
                }

                throw new Exception("Localization text not found.");
            }
            else
                throw new Exception("Localization file is not loaded.");
        }

        /// <summary>
        /// Method loads localization file.
        /// </summary>
        public void Load()
        {
            try
            {
                localizationTextsList = LangFileReader.LoadLocalizationText(fileFullPath);
                loaded = true;
            }
            catch(Exception e)
            {
                throw new Exception("Problem with loading localization.", e);
            }
        }
    }
}
