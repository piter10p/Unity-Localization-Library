using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ULL
{
    class LocalizationEntry
    {
        public string Key { get; private set; }
        public string Text { get; private set; }

        public LocalizationEntry(string key, string text)
        {
            this.Key = key;
            this.Text = text;
        }
    }
}
