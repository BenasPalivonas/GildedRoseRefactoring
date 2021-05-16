namespace csharpcore
{
    public interface ISulfuras
    {
        public void DecreaseSellInIfNotSulfuras(Item item);
        public void DecreaseQualityIfNotSulfuras(Item item);
    }
}
