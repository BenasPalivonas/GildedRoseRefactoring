using csharpcore;
using System.Collections.Generic;

namespace GildedRose.Services.GildedRose
{
    public interface IGildedRoseService
    {
        public void UpdateQuality(IList<Item> Items);
    }
}
