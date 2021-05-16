namespace csharpcore
{
    public partial class Item
    {
        public class IsAgedBrie : IAgedBrie
        {
            public void DecreaseQualityIfNotAgedBrie(Item item)
            {
                item.IncreaseQuality();
            }
        }
    }
}
