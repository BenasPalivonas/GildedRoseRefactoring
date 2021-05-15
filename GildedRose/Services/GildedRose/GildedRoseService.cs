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
                if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                        DecreaseQualityIfNotSulfuras(Items[i]);
                }
                else
                {
                    if (Items[i].Quality < 50)
                    {
                        Items[i].Quality = Items[i].Quality + 1;

                        if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].SellIn < 11)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }

                            if (Items[i].SellIn < 6)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }

                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name != "Aged Brie")
                    {
                        DecreaseQualityIfNotBackStagePasses(Items[i]);
                    }
                    else
                    {
                        IncreaseQuality(Items[i]);
                    }
                }
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
                item.Quality = item.Quality - item.Quality;
            }
        }

        private static void IncreaseQuality(Item Item)
        {
            if (Item.Quality < 50)
            {
                Item.Quality += 1;
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
