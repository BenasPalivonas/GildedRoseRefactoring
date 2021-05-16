using GildedRose.Models;

namespace csharpcore
{
    public class NotAgedBrie : IAgedBrie
    {
        public void DecreaseQualityIfNotAgedBrie(SuperItem item)
        {
            item.BackStagePasses.DecreaseQualityIfNotBackStagePasses(item);
        }
    }
}
