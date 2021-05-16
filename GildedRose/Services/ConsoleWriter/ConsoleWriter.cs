using csharpcore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Services.ConsoleWriter
{
    class ConsoleWriter : IConsoleWriter
    {
        public void WriteWelcomeMessage()
        {
            Console.WriteLine("OMGHAI!");
        }
        public void WriteItemsToConsole(IList<Item> Items, int day)
        {
            Console.WriteLine("-------- day " + day + " --------");
            Console.WriteLine("name, sellIn, quality");
            for (var j = 0; j < Items.Count; j++)
            {
                System.Console.WriteLine(Items[j].Name + ", " + Items[j].SellIn + ", " + Items[j].Quality);
            }
            Console.WriteLine("");
        }
    }
}
