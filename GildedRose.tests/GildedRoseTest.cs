using Xunit;
using System.Collections.Generic;
using GildedRose.Services.GildedRose;

namespace csharpcore
{
    public class GildedRoseTest
    {
        [Fact]
        public void foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRoseService app = new GildedRoseService();
            app.UpdateQuality(Items);
            Assert.Equal("foo", Items[0].Name);
        }
    }
}