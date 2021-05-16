using Xunit;
namespace csharpcore
{
    public class ItemTests
    {
        private const string Aged_Brie = "Aged Brie";
        private const string Sulfuras_Hand_Of_Ragnaros = "Sulfuras, Hand of Ragnaros";
        private const string Backstage_Passes = "Backstage passes to a TAFKAL80ETC concert";
        private const int Max_Quality = 50;
        private const int Reaching_Expiry_Date = 11;
        private const int Close_To_Expiry = 6;
        [Fact]
        public void IncreaseQualityWhenQualityIsMax()
        {
            var Item = new Item { Name = "Test", SellIn = Max_Quality, Quality = 50 };
            Item.IncreaseQuality();
            Assert.Equal(50, Item.Quality);
        }
        [Fact]
        public void IncreaseQualityIncludingBackstagePasses_ReachingExpiry()
        {
            var Item = new Item { Name = Backstage_Passes, SellIn = Reaching_Expiry_Date - 1, Quality = 15 };
            Item.IncreaseQualityIncludingBackstagePasses();
            Assert.Equal(17, Item.Quality);
        }
        [Fact]
        public void IncreaseQualityIncludingBackstagePasses_CloseToExpiry()
        {
            var Item = new Item { Name = Backstage_Passes, SellIn = Close_To_Expiry - 1, Quality = 15 };
            Item.IncreaseQualityIncludingBackstagePasses();
            Assert.Equal(18, Item.Quality);
        }
        [Fact]
        public void UpdateQuality()
        {
            var Item = new Item { Name = "test", SellIn = 30, Quality = 50 };
            Item.UpdateQuality();
            Assert.Equal("test", Item.Name);
            Assert.Equal(49, Item.Quality);
            Assert.Equal(30, Item.SellIn);
        }
        [Fact]
        public void UpdateQualityIfAgedBrie()
        {
            var Item = new Item { Name = Aged_Brie, SellIn = -1, Quality = 48 };
            Item.UpdateQuality();
            Assert.Equal(Aged_Brie, Item.Name);
            Assert.Equal(49, Item.Quality);
            Assert.Equal(-1, Item.SellIn);
        }
        [Fact]
        public void UpdateQualityIfSulfuras()
        {
            var Item = new Item { Name = Sulfuras_Hand_Of_Ragnaros, SellIn = 15, Quality = 48 };
            Item.UpdateQuality();
            Assert.Equal(Sulfuras_Hand_Of_Ragnaros, Item.Name);
            Assert.Equal(48, Item.Quality);
            Assert.Equal(15, Item.SellIn);
        }
        [Fact]
        public void UpdateQualityIfBackstagePasses()
        {
            var Item = new Item { Name = Backstage_Passes, SellIn = 15, Quality = 12 };
            Item.UpdateQuality();
            Assert.Equal(Backstage_Passes, Item.Name);
            Assert.Equal(13, Item.Quality);
            Assert.Equal(15, Item.SellIn);
        }
        [Fact]
        public void HandleSellInExpired_NotExpired()
        {
            var Item = new Item { Name = "test", SellIn = 14, Quality = 11 };
            Item.HandleSellInExpired();
            Assert.Equal("test", Item.Name);
            Assert.Equal(14, Item.SellIn);
            Assert.Equal(11, Item.Quality);
        }
        [Fact]
        public void HandleSellInExpired_Expired()
        {
            var Item = new Item { Name = "test", SellIn = -1, Quality = 11 };
            Item.HandleSellInExpired();
            Assert.Equal("test", Item.Name);
            Assert.Equal(-1, Item.SellIn);
            Assert.Equal(10, Item.Quality);
        }
        [Fact]
        public void HandleSellInExpired_Sulfuras()
        {
            var Item = new Item { Name = Sulfuras_Hand_Of_Ragnaros, SellIn = -1, Quality = 25 };
            Item.HandleSellInExpired();
            Assert.Equal(Sulfuras_Hand_Of_Ragnaros, Item.Name);
            Assert.Equal(-1, Item.SellIn);
            Assert.Equal(25, Item.Quality);
        }
        [Fact]
        public void HandleSellInExpired_AgedBrie()
        {
            var Item = new Item { Name = Aged_Brie, SellIn = -1, Quality = 25 };
            Item.HandleSellInExpired();
            Assert.Equal(Aged_Brie, Item.Name);
            Assert.Equal(-1, Item.SellIn);
            Assert.Equal(26, Item.Quality);
        }
        [Fact]
        public void HandleSellInExpired_BackstagePasses()
        {
            var Item = new Item { Name = Backstage_Passes, SellIn = -1, Quality = 25 };
            Item.HandleSellInExpired();
            Assert.Equal(Backstage_Passes, Item.Name);
            Assert.Equal(-1, Item.SellIn);
            Assert.Equal(0, Item.Quality);
        }
    }
}
