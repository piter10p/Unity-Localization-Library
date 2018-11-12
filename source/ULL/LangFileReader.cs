using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ULL
{
    static class LangFileReader
    {
        public static string LoadLanguageName(string fullFilePath)
        {
            try
            {
                StreamReader streamReader = new StreamReader(fullFilePath);
                return streamReader.ReadLine();
            }
            catch(Exception e)
            {
                throw new Exception("Problem with reading language name.", e);
            }
        }

        public static List<LocalizationEntry> LoadLocalizationText(string fullFilePath)
        {
            List<LocalizationEntry> localizationTextsList = new List<LocalizationEntry>();

            try
            {
                StreamReader streamReader = new StreamReader(fullFilePath);
                streamReader.ReadLine();//skip name line

                while(!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();

                    if(!IsLineEmpty(line) && !IsLineAComment(line))
                    {
                        try
                        {
                            LocalizationEntry text = ReadLine(line);
                            localizationTextsList.Add(text);
                        }
                        catch { }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Problem with reading language file entries.", e);
            }

            return localizationTextsList;
        }

        private static bool IsLineEmpty(string line)
        {
            foreach(char c in line)
            {
                if (c != ' ')
                    return false;
            }

            return true;
        }

        private static bool IsLineAComment(string line)
        {
            foreach (char c in line)
            {
                if(c != ' ')
                {
                    if (c == '#')
                        return true;
                    return false;
                }
            }

            return false;
        }

        private static LocalizationEntry ReadLine(string line)
        {
            try
            {
                string[] lineSplitted = line.Split('=');
                string id = lineSplitted[0];
                string text = lineSplitted[1];

                return new LocalizationEntry(id, text);
            }
            catch(Exception e)
            {
                throw new Exception("Problem with reading localization file entry.", e);
            }
        }
    }
}
