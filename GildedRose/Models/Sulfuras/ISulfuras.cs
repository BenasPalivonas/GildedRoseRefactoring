using GildedRose.Models;

namespace csharpcore
{
    public interface ISulfuras
    {
        public void DecreaseSellInIfNotSulfuras(SuperItem item);
        public void DecreaseQualityIfNotSulfuras(SuperItem item);
    }
}
