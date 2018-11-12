using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ULL
{
    public class LocalizationListGenerator
    {
        /// <summary>
        /// True if there's any excpetion left.
        /// </summary>
        public bool ExceptionExists
        {
            get
            {
                if (readingExceptionsQueue.Count > 0)
                    return true;
                return false;
            }
        }

        /// <summary>
        /// Returns next exception and deletes it.
        /// </summary>
        public Exception GetNextException
        {
            get
            {
                return readingExceptionsQueue.Dequeue();
            }
        }

        private Queue<Exception> readingExceptionsQueue = new Queue<Exception>();

        /// <summary>
        /// Method generates list of localization files, based on localization files.
        /// </summary>
        /// <param name="localizationsPath">Path where class needs to looking for localization files.</param>
        /// <returns>List of UNLOADED localization files.</returns>
        public List<Localization> GenerateLocalizationList(string localizationsPath)
        {
            List<Localization> localizationsList = new List<Localization>();

            try
            {
                DirectoryInfo mainDirectory = new DirectoryInfo(localizationsPath);

                foreach (FileInfo file in mainDirectory.GetFiles("*.lang"))
                {
                    try
                    {
                        Localization localization = ReadLocalizationFile(file.FullName, file.Name);
                        localizationsList.Add(localization);
                    }
                    catch(Exception e)
                    {

                    }
                }

                return localizationsList;
            }
            catch(Exception e)
            {
                throw new Exception("Problem with generating localizations list.", e);
            }
        }

        private Localization ReadLocalizationFile(string fileFullPath, string fileName)
        {
            try
            {
                string languageTag = fileName.Split('.')[0];//get filename without extension
                string languageName;

                StreamReader streamReader = new StreamReader(fileFullPath);
                languageName = streamReader.ReadLine();

                return new Localization(languageTag, languageName);
            }
            catch(Exception e)
            {
                throw new Exception("Problem with reading localization file: " + fileName, e);
            }
        }
    }
}
