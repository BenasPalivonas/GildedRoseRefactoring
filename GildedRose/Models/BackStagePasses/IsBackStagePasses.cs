using GildedRose.Models;

namespace csharpcore
{
    public class IsBackStagePasses : IBackStagePasses
    {
        public void IncreaseIfBackStagePasses(SuperItem item)
        {
            item.IncreaseIfReachingExpiry();
            item.IncreaseIfCloseToExpiry();
        }
        public void DecreaseQualityIfNotBackStagePasses(SuperItem item)
        {
            item.Quality = 0;
        }
    }
}
