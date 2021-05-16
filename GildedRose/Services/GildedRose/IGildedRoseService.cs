using csharpcore;
using GildedRose.Models;
using System.Collections.Generic;

namespace GildedRose.Services.GildedRose
{
    public interface IGildedRoseService
    {
        public void UpdateQuality(IList<SuperItem> Items);
    }
}
