using csharpcore;
using System.Collections.Generic;
namespace GildedRose.Services.GildedRose
{
    public class GildedRoseService : IGildedRoseService
    {
        public void UpdateQuality(IList<Item> Items)
        {
            for (var i = 0; i < Items.Count; i++)
            {
                Items[i].UpdateQuality();

                Items[i].Sulfuras.DecreaseSellInIfNotSulfuras(Items[i]);

                Items[i].HandleSellInExpired();
            }
        }
    }
}
