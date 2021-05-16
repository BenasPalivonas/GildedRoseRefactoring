namespace csharpcore
{
    public class NotAgedBrie : IAgedBrie
    {
        public void DecreaseQualityIfNotAgedBrie(Item item)
        {
            item.BackStagePasses.DecreaseQualityIfNotBackStagePasses(item);
        }
    }
}
