using csharpcore;
using GildedRose.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Services.ItemsService
{
    public class ItemsService : IItemsService
    {
        public List<SuperItem> GetItems()
        {
            return new List<SuperItem>{
                new SuperItem {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new SuperItem {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new SuperItem {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new SuperItem {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new SuperItem {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                new SuperItem
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new SuperItem
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new SuperItem
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
				new SuperItem {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };
        }
    }
}
