using csharpcore;
using GildedRose.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Services.ConsoleWriter
{
    public interface IConsoleWriter
    {
        public void WriteItemsToConsole(IList<SuperItem> Items, int day);
        public void WriteWelcomeMessage();
    }
}
