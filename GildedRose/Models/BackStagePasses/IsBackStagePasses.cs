namespace csharpcore
{
    public class IsBackStagePasses : IBackStagePasses
    {
        public void IncreaseIfBackStagePasses(Item item)
        {
            item.IncreaseIfReachingExpiry();
            item.IncreaseIfCloseToExpiry();
        }
        public void DecreaseQualityIfNotBackStagePasses(Item item)
        {
            item.Quality = 0;
        }
    }
}
