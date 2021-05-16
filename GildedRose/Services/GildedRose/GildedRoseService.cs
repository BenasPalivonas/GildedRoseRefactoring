using csharpcore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
