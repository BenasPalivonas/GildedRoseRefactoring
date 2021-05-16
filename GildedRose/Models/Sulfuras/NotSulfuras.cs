using GildedRose.Models;

namespace csharpcore
{
    public class NotSulfuras : ISulfuras
    {
        public void DecreaseSellInIfNotSulfuras(SuperItem item)
        {
            item.SellIn -= 1;
        }
        public void DecreaseQualityIfNotSulfuras(SuperItem item)
        {
            if (item.Quality > 0)
            {
                item.Quality -= 1;
                item.ConjuredItem.DegradeQuality(item);
            }
        }
    }
}
