using GildedRose.Models;

namespace csharpcore
{
    public interface IBackStagePasses
    {
        public void IncreaseIfBackStagePasses(SuperItem item);
        public void DecreaseQualityIfNotBackStagePasses(SuperItem item);
    }
}
