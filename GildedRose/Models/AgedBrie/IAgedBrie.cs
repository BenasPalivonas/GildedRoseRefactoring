using GildedRose.Models;

namespace csharpcore
{
    public interface IAgedBrie
    {
        public void DecreaseQualityIfNotAgedBrie(SuperItem item);
    }
}
