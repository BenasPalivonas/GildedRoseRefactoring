using GildedRose.Models;
using Xunit;
namespace csharpcore
{
    public class SuperItemTests
    {
        private const string Aged_Brie = "Aged Brie";
        private const string Sulfuras_Hand_Of_Ragnaros = "Sulfuras, Hand of Ragnaros";
        private const string Backstage_Passes = "Backstage passes to a TAFKAL80ETC concert";
        private const string Conjured_Item = "Conjured shirt";
        private const int Max_Quality = 50;
        private const int Reaching_Expiry_Date = 11;
        private const int Close_To_Expiry = 6;
        [Fact]
        public void IncreaseQualityWhenQualityIsMax()
        {
            var SuperItem = new SuperItem { Name = "Test", SellIn = Max_Quality, Quality = 50 };
            SuperItem.IncreaseQuality();
            Assert.Equal(50, SuperItem.Quality);
        }
        [Fact]
        public void IncreaseQualityIncludingBackstagePasses_ReachingExpiry()
        {
            var SuperItem = new SuperItem { Name = Backstage_Passes, SellIn = Reaching_Expiry_Date - 1, Quality = 15 };
            SuperItem.IncreaseQualityIncludingBackstagePasses();
            Assert.Equal(17, SuperItem.Quality);
        }
        [Fact]
        public void IncreaseQualityIncludingBackstagePasses_CloseToExpiry()
        {
            var SuperItem = new SuperItem { Name = Backstage_Passes, SellIn = Close_To_Expiry - 1, Quality = 15 };
            SuperItem.IncreaseQualityIncludingBackstagePasses();
            Assert.Equal(18, SuperItem.Quality);
        }
        [Fact]
        public void UpdateQuality()
        {
            var SuperItem = new SuperItem { Name = "test", SellIn = 30, Quality = 50 };
            SuperItem.UpdateQuality();
            Assert.Equal("test", SuperItem.Name);
            Assert.Equal(49, SuperItem.Quality);
            Assert.Equal(30, SuperItem.SellIn);
        }
        [Fact]
        public void UpdateQualityIfAgedBrie()
        {
            var SuperItem = new SuperItem { Name = Aged_Brie, SellIn = -1, Quality = 48 };
            SuperItem.UpdateQuality();
            Assert.Equal(Aged_Brie, SuperItem.Name);
            Assert.Equal(49, SuperItem.Quality);
            Assert.Equal(-1, SuperItem.SellIn);
        }
        [Fact]
        public void UpdateQualityIfSulfuras()
        {
            var SuperItem = new SuperItem { Name = Sulfuras_Hand_Of_Ragnaros, SellIn = 15, Quality = 48 };
            SuperItem.UpdateQuality();
            Assert.Equal(Sulfuras_Hand_Of_Ragnaros, SuperItem.Name);
            Assert.Equal(48, SuperItem.Quality);
            Assert.Equal(15, SuperItem.SellIn);
        }
        [Fact]
        public void UpdateQualityIfBackstagePasses()
        {
            var SuperItem = new SuperItem { Name = Backstage_Passes, SellIn = 15, Quality = 12 };
            SuperItem.UpdateQuality();
            Assert.Equal(Backstage_Passes, SuperItem.Name);
            Assert.Equal(13, SuperItem.Quality);
            Assert.Equal(15, SuperItem.SellIn);
        }
        [Fact]
        public void UpdateQuality_IfConjuredItem()
        {
            var SuperItem = new SuperItem { Name = Conjured_Item, SellIn = 25, Quality = 25 };
            SuperItem.UpdateQuality();
            Assert.Equal(Conjured_Item, SuperItem.Name);
            Assert.Equal(23, SuperItem.Quality);
            Assert.Equal(25, SuperItem.SellIn);
        }
        [Fact]
        public void UpdateQuality_IfSellInExpired()
        {
            var SuperItem = new SuperItem { Name = "test", SellIn = -1, Quality = 50 };
            SuperItem.UpdateQuality();
            SuperItem.HandleSellInExpired();
            Assert.Equal("test", SuperItem.Name);
            Assert.Equal(48, SuperItem.Quality);
            Assert.Equal(-1, SuperItem.SellIn);
        }
        [Fact]
        public void UpdateQuality_IfSellInExpired_ConjuredItem()
        {
            var SuperItem = new SuperItem { Name = Conjured_Item, SellIn = -1, Quality = 50 };
            SuperItem.UpdateQuality();
            SuperItem.HandleSellInExpired();
            Assert.Equal(Conjured_Item, SuperItem.Name);
            Assert.Equal(46, SuperItem.Quality);
            Assert.Equal(-1, SuperItem.SellIn);
        }
        [Fact]
        public void HandleSellInExpired_NotExpired()
        {
            var SuperItem = new SuperItem { Name = "test", SellIn = 14, Quality = 11 };
            SuperItem.HandleSellInExpired();
            Assert.Equal("test", SuperItem.Name);
            Assert.Equal(14, SuperItem.SellIn);
            Assert.Equal(11, SuperItem.Quality);
        }
        [Fact]
        public void HandleSellInExpired_Expired()
        {
            var SuperItem = new SuperItem { Name = "test", SellIn = -1, Quality = 11 };
            SuperItem.HandleSellInExpired();
            Assert.Equal("test", SuperItem.Name);
            Assert.Equal(-1, SuperItem.SellIn);
            Assert.Equal(10, SuperItem.Quality);
        }
        [Fact]
        public void HandleSellInExpired_Sulfuras()
        {
            var SuperItem = new SuperItem { Name = Sulfuras_Hand_Of_Ragnaros, SellIn = -1, Quality = 25 };
            SuperItem.HandleSellInExpired();
            Assert.Equal(Sulfuras_Hand_Of_Ragnaros, SuperItem.Name);
            Assert.Equal(-1, SuperItem.SellIn);
            Assert.Equal(25, SuperItem.Quality);
        }
        [Fact]
        public void HandleSellInExpired_AgedBrie()
        {
            var SuperItem = new SuperItem { Name = Aged_Brie, SellIn = -1, Quality = 25 };
            SuperItem.HandleSellInExpired();
            Assert.Equal(Aged_Brie, SuperItem.Name);
            Assert.Equal(-1, SuperItem.SellIn);
            Assert.Equal(26, SuperItem.Quality);
        }
        [Fact]
        public void HandleSellInExpired_BackstagePasses()
        {
            var SuperItem = new SuperItem { Name = Backstage_Passes, SellIn = -1, Quality = 25 };
            SuperItem.HandleSellInExpired();
            Assert.Equal(Backstage_Passes, SuperItem.Name);
            Assert.Equal(-1, SuperItem.SellIn);
            Assert.Equal(0, SuperItem.Quality);
        }
        [Fact]
        public void DecreaseSellIn_NormalItem()
        {
            var SuperItem = new SuperItem { Name = "test", SellIn = 14, Quality = 11 };
            SuperItem.Sulfuras.DecreaseSellInIfNotSulfuras(SuperItem);
            Assert.Equal("test", SuperItem.Name);
            Assert.Equal(13, SuperItem.SellIn);
            Assert.Equal(11, SuperItem.Quality);
        }
        [Fact]
        public void DecreaseSellIn_Sulfuras()
        {
            var SuperItem = new SuperItem { Name = Sulfuras_Hand_Of_Ragnaros, SellIn = 14, Quality = 11 };
            SuperItem.Sulfuras.DecreaseSellInIfNotSulfuras(SuperItem);
            Assert.Equal(Sulfuras_Hand_Of_Ragnaros, SuperItem.Name);
            Assert.Equal(14, SuperItem.SellIn);
            Assert.Equal(11, SuperItem.Quality);
        }
        [Fact]
        public void DecreaseSellIn_AgedBrie()
        {
            var SuperItem = new SuperItem { Name = Aged_Brie, SellIn = 14, Quality = 11 };
            SuperItem.Sulfuras.DecreaseSellInIfNotSulfuras(SuperItem);
            Assert.Equal(Aged_Brie, SuperItem.Name);
            Assert.Equal(13, SuperItem.SellIn);
            Assert.Equal(11, SuperItem.Quality);
        }
        [Fact]
        public void DecreaseSellIn_BackstagePasses()
        {
            var SuperItem = new SuperItem { Name = Backstage_Passes, SellIn = 14, Quality = 11 };
            SuperItem.Sulfuras.DecreaseSellInIfNotSulfuras(SuperItem);
            Assert.Equal(Backstage_Passes, SuperItem.Name);
            Assert.Equal(13, SuperItem.SellIn);
            Assert.Equal(11, SuperItem.Quality);
        }
        [Fact]
        public void DecreaseSellIn_ConjuredItem()
        {
            var SuperItem = new SuperItem { Name = Conjured_Item, SellIn = 14, Quality = 11 };
            SuperItem.Sulfuras.DecreaseSellInIfNotSulfuras(SuperItem);
            Assert.Equal(Conjured_Item, SuperItem.Name);
            Assert.Equal(13, SuperItem.SellIn);
            Assert.Equal(11, SuperItem.Quality);
        }
    }
}
