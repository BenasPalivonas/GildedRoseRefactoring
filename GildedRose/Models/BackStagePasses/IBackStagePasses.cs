namespace csharpcore
{
    public partial class Item
    {
        public interface IBackStagePasses
        {
            public void IncreaseIfBackStagePasses(Item item);
            public void DecreaseQualityIfNotBackStagePasses(Item item);
        }
    }
}
