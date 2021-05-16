using GildedRose.Models;

namespace csharpcore
{
    public class NotBackStagePasses : IBackStagePasses
    {
        public void IncreaseIfBackStagePasses(SuperItem item)
        {
        }
        public void DecreaseQualityIfNotBackStagePasses(SuperItem item)
        {
            item.Sulfuras.DecreaseQualityIfNotSulfuras(item);
        }
    }
}
