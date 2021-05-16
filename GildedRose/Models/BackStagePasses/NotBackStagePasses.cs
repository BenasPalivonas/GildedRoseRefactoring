namespace csharpcore
{
    public partial class Item
    {
        public class NotBackStagePasses : IBackStagePasses
        {
            public void IncreaseIfBackStagePasses(Item item)
            {
            }
            public void DecreaseQualityIfNotBackStagePasses(Item item)
            {
                item.Sulfuras.DecreaseQualityIfNotSulfuras(item);
            }
        }
    }
}
