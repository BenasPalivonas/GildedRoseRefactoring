namespace csharpcore
{
    public class IsAgedBrie : IAgedBrie
    {
        public void DecreaseQualityIfNotAgedBrie(Item item)
        {
            item.IncreaseQuality();
        }
    }
}
