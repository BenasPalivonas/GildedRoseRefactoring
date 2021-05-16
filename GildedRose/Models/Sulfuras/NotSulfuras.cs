namespace csharpcore
{
    public partial class Item
    {
        public class NotSulfuras : ISulfuras
        {
            public void DecreaseSellInIfNotSulfuras(Item item)
            {
                item.SellIn -= 1;
            }
            public void DecreaseQualityIfNotSulfuras(Item item)
            {
                if (item.Quality > 0)
                {
                    item.Quality -= 1;
                }
            }
        }
    }
}
