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
                UpdateQuality_TMP(Items[i]);

                DecreaseSellInIfNotSulfuras(Items[i]);

                HandleSellInExpired(Items[i]);
            }
        }

        private static void HandleSellInExpired(Item item)
        {
            if (item.SellIn < 0)
            {
                if (item.Name != "Aged Brie")
                {
                    DecreaseQualityIfNotBackStagePasses(item);
                }
                else
                {
                    IncreaseQuality(item);
                }
            }
        }

        private static void UpdateQuality_TMP(Item item)
        {
            if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                DecreaseQualityIfNotSulfuras(item);
            }
            else
            {
                IncreaseQualityIncludingBackstagePasses(item);
            }
        }

        private static void DecreaseSellInIfNotSulfuras(Item item)
        {
            if (item.Name != "Sulfuras, Hand of Ragnaros")
            {
                item.SellIn -= 1;
            }
        }

        private static void IncreaseIfBackStagePasses(Item item)
        {
            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                IncreaseIfReachingExpiry(item);
                IncreaseIfCloseToExpiry(item);
            }
        }

        private static void IncreaseIfCloseToExpiry(Item item)
        {
            if (item.SellIn < 6)
            {
                IncreaseQuality(item);
            }
        }

        private static void IncreaseIfReachingExpiry(Item item)
        {
            if (item.SellIn < 11)
            {
                IncreaseQuality(item);
            }
        }

        private static void DecreaseQualityIfNotBackStagePasses(Item item)
        {
            if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                    DecreaseQualityIfNotSulfuras(item);
            }
            else
            {
                item.Quality = 0;
            }
        }

        private static void IncreaseQuality(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality += 1;
            }
        }

        private static void IncreaseQualityIncludingBackstagePasses(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality += 1;
                IncreaseIfBackStagePasses(item);
            }
        }

        private static void DecreaseQualityIfNotSulfuras(Item item)
        {
            if (item.Quality > 0)
            {
                if (item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    item.Quality -= 1;
                }
            }
        }
    }
}
