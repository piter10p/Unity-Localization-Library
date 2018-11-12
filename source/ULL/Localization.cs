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
        /// Returns count of Localization entries.
        /// </summary>
        public int EntriesCount
        {
            get
            {
                return localizationEntriesList.Count;
            }
        }

        private List<LocalizationEntry> localizationEntriesList;
        private string fileFullPath;
        private bool loaded = false;

        public Localization(string tag, string name, string fileFullPath)
        {
            this.Tag = tag;
            this.Name = name;
            this.fileFullPath = fileFullPath;
        }

        /// <summary>
        /// Finds and returns text of Localization Entry with specified id. Throws Exception when no text was found, or Localization is unloaded.
        /// </summary>
        /// <param name="id">Id of Localization Entry to looking for.</param>
        /// <returns></returns>
        public string GetLocalizationEntry(string id)
        {
            if (loaded)
            {
                foreach (LocalizationEntry text in localizationEntriesList)
                {
                    if (text.Id == id)
                        return text.Text;
                }

                throw new Exception("Localization enrty not found.");
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
                localizationEntriesList = LangFileReader.LoadLocalizationText(fileFullPath);
                loaded = true;
            }
            catch(Exception e)
            {
                throw new Exception("Problem with loading localization.", e);
            }
        }
    }
}
