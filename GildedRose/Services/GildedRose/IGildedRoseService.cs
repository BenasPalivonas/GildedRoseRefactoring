using csharpcore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Services.GildedRose
{
    public interface IGildedRoseService
    {
        public void UpdateQuality(IList<Item> Items);
    }
}
