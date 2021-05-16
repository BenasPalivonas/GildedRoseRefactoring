namespace csharpcore
{
    public partial class Item
    {
        public interface ISulfuras
        {
            public void DecreaseSellInIfNotSulfuras(Item item);
            public void DecreaseQualityIfNotSulfuras(Item item);
        }
    }
}
