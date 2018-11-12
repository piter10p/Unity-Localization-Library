using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ULL
{
    class LocalizationEntry
    {
        public string Id { get; private set; }
        public string Text { get; private set; }

        public LocalizationEntry(string id, string text)
        {
            this.Id = id;
            this.Text = text;
        }
    }
}
