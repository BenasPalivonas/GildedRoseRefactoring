using GildedRose.Models;

namespace csharpcore
{
    public class IsAgedBrie : IAgedBrie
    {
        public void DecreaseQualityIfNotAgedBrie(SuperItem item)
        {
            item.IncreaseQuality();
        }
    }
}
