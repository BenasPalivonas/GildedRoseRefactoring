
namespace csharpcore
{
    public class Item
    {
        private const string Aged_Brie = "Aged Brie";
        private const string Sulfuras_Hand_Of_Ragnaros = "Sulfuras, Hand of Ragnaros";
        private const string Backstage_Passes = "Backstage passes to a TAFKAL80ETC concert";
        private const int Max_Quality = 50;
        private const int Reaching_Expiry_Date = 11;
        private const int Close_To_Expiry = 6;
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                AgedBrie = this._name.Equals(Aged_Brie) ? new IsAgedBrie() : new NotAgedBrie();
                Sulfuras = this._name.Equals(Sulfuras_Hand_Of_Ragnaros) ? new IsSulfuras() : new NotSulfuras();
                BackStagePasses = this._name.Equals(Backstage_Passes) ? new IsBackStagePasses() : new NotBackStagePasses();
            }
        }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public IAgedBrie AgedBrie;

        public ISulfuras Sulfuras;

        public IBackStagePasses BackStagePasses;

        public void HandleSellInExpired()
        {
            if (SellIn < 0)
            {
                AgedBrie.DecreaseQualityIfNotAgedBrie(this);
            }
        }
        public void UpdateQuality()
        {
            if (AgedBrie is not IsAgedBrie && BackStagePasses is not IsBackStagePasses)
            {
                Sulfuras.DecreaseQualityIfNotSulfuras(this);
            }
            else
            {
                IncreaseQualityIncludingBackstagePasses();
            }
        }
        public void IncreaseIfCloseToExpiry()
        {
            if (SellIn < Close_To_Expiry)
            {
                IncreaseQuality();
            }
        }

        public void IncreaseIfReachingExpiry()
        {
            if (SellIn < Reaching_Expiry_Date)
            {
                IncreaseQuality();
            }
        }

        public void IncreaseQuality()
        {
            if (Quality < Max_Quality)
            {
                Quality += 1;
            }
        }

        public void IncreaseQualityIncludingBackstagePasses()
        {
            if (Quality < Max_Quality)
            {
                Quality += 1;
                BackStagePasses.IncreaseIfBackStagePasses(this);
            }
        }
    }
}
