namespace csharpcore
{
    public partial class Item
    {
        public interface IAgedBrie
        {
            public void DecreaseQualityIfNotAgedBrie(Item item);
        }
    }
}
