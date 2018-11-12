using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ULL
{
    public class LocalizationText
    {
        public string Id { get; private set; }
        public string Text { get; private set; }

        public LocalizationText(string id, string text)
        {
            this.Id = id;
            this.Text = text;
        }
    }
}
