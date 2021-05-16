using Xunit;
using System.Collections.Generic;
using GildedRose.Services.GildedRose;
using GildedRose.Models;

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
            IList<SuperItem> SuperItems = new List<SuperItem> { new SuperItem { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRoseService app = new GildedRoseService();
            app.UpdateQuality(SuperItems);
            Assert.Equal("foo", SuperItems[0].Name);
        }
        [Fact]
        public void UpdateQuality()
        {
            IList<SuperItem> SuperItems = new List<SuperItem> { new SuperItem { Name = "test", SellIn = 30, Quality = 50 } };
            GildedRoseService app = new GildedRoseService();
            app.UpdateQuality(SuperItems);
            Assert.Equal("test", SuperItems[0].Name);
            Assert.Equal(49, SuperItems[0].Quality);
            Assert.Equal(29, SuperItems[0].SellIn);
        }
        [Fact]
        public void UpdateSulfuras()
        {
            IList<SuperItem> SuperItems = new List<SuperItem> { new SuperItem { Name = Sulfuras_Hand_Of_Ragnaros, SellIn = 25, Quality = 40 } };
            GildedRoseService app = new GildedRoseService();
            app.UpdateQuality(SuperItems);
            Assert.Equal(Sulfuras_Hand_Of_Ragnaros, SuperItems[0].Name);
            Assert.Equal(40, SuperItems[0].Quality);
            Assert.Equal(25, SuperItems[0].SellIn);
        }
        [Fact]
        public void UpdateBackStagePasses()
        {
            IList<SuperItem> SuperItems = new List<SuperItem> { new SuperItem { Name = Backstage_Passes, SellIn = 5, Quality = 40 } };
            GildedRoseService app = new GildedRoseService();
            app.UpdateQuality(SuperItems);
            Assert.Equal(Backstage_Passes, SuperItems[0].Name);
            Assert.Equal(43, SuperItems[0].Quality);
            Assert.Equal(4, SuperItems[0].SellIn);
        }
        [Fact]
        public void UpdateAgedBrie()
        {
            IList<SuperItem> SuperItems = new List<SuperItem> { new SuperItem { Name = Aged_Brie, SellIn = 0, Quality = 41 } };
            GildedRoseService app = new GildedRoseService();
            app.UpdateQuality(SuperItems);
            Assert.Equal(Aged_Brie, SuperItems[0].Name);
            Assert.Equal(43, SuperItems[0].Quality);
            Assert.Equal(-1, SuperItems[0].SellIn);
        }


    }
}