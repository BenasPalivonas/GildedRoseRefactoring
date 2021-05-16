namespace csharpcore
{
    public interface IBackStagePasses
    {
        public void IncreaseIfBackStagePasses(Item item);
        public void DecreaseQualityIfNotBackStagePasses(Item item);
    }
}
