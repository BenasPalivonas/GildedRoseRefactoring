﻿using Xunit;
using System.Collections.Generic;
using GildedRose.Services.GildedRose;

namespace csharpcore
{
    public class GildedRoseTest
    {
        private const string Aged_Brie = "Aged Brie";
        private const string Sulfuras_Hand_Of_Ragnaros = "Sulfuras, Hand of Ragnaros";
        private const string Backstage_Passes = "Backstage passes to a TAFKAL80ETC concert";
        [Fact]
        public void foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRoseService app = new GildedRoseService();
            app.UpdateQuality(Items);
            Assert.Equal("foo", Items[0].Name);
        }
        [Fact]
        public void UpdateQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "test", SellIn = 30, Quality = 50 } };
            GildedRoseService app = new GildedRoseService();
            app.UpdateQuality(Items);
            Assert.Equal("test", Items[0].Name);
            Assert.Equal(49, Items[0].Quality);
            Assert.Equal(29, Items[0].SellIn);
        }
        [Fact]
        public void UpdateSulfuras()
        {
            IList<Item> Items = new List<Item> { new Item { Name = Sulfuras_Hand_Of_Ragnaros, SellIn = 25, Quality = 40 } };
            GildedRoseService app = new GildedRoseService();
            app.UpdateQuality(Items);
            Assert.Equal(Sulfuras_Hand_Of_Ragnaros, Items[0].Name);
            Assert.Equal(40, Items[0].Quality);
            Assert.Equal(25, Items[0].SellIn);
        }
        [Fact]
        public void UpdateBackStagePasses()
        {
            IList<Item> Items = new List<Item> { new Item { Name = Backstage_Passes, SellIn = 5, Quality = 40 } };
            GildedRoseService app = new GildedRoseService();
            app.UpdateQuality(Items);
            Assert.Equal(Backstage_Passes, Items[0].Name);
            Assert.Equal(43, Items[0].Quality);
            Assert.Equal(4, Items[0].SellIn);
        }
        [Fact]
        public void UpdateAgedBrie()
        {
            IList<Item> Items = new List<Item> { new Item { Name = Aged_Brie, SellIn = 0, Quality = 41 } };
            GildedRoseService app = new GildedRoseService();
            app.UpdateQuality(Items);
            Assert.Equal(Aged_Brie, Items[0].Name);
            Assert.Equal(43, Items[0].Quality);
            Assert.Equal(-1, Items[0].SellIn);
        }


    }
}