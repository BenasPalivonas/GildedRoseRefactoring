using GildedRose.Attributes;

namespace csharpcore
{
    public class Item
    {
        public interface IAgedBrie {
            public void DecreaseQualityIfNotAgedBrie(Item item);
        }

        public class IsAgedBrie:IAgedBrie
        {
            public void DecreaseQualityIfNotAgedBrie(Item item)
            { 
                item.IncreaseQuality();
            }
        }
        public class NotAgedBrie : IAgedBrie
        {
            public void DecreaseQualityIfNotAgedBrie(Item item)
            {
                item.BackStagePasses.DecreaseQualityIfNotBackStagePasses(item);
            }
        }
        public interface ISulfuras {
            public void DecreaseSellInIfNotSulfuras(Item item);
            public void DecreaseQualityIfNotSulfuras(Item item);
        }
        public class IsSulfuras:ISulfuras {
            public void DecreaseSellInIfNotSulfuras(Item item)
            {
            }
            public void DecreaseQualityIfNotSulfuras(Item item)
            {
            }
        }
        public class NotSulfuras : ISulfuras {
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
        public interface IBackStagePasses {
            public void IncreaseIfBackStagePasses(Item item);
            public void DecreaseQualityIfNotBackStagePasses(Item item);
        }
        public class IsBackStagePasses:IBackStagePasses {
            public void IncreaseIfBackStagePasses(Item item)
            {
                    item.IncreaseIfReachingExpiry();
                    item.IncreaseIfCloseToExpiry();
            }
            public void DecreaseQualityIfNotBackStagePasses(Item item)
            {
                    item.Quality = 0;
            }
        }
        public class NotBackStagePasses : IBackStagePasses {
            public void IncreaseIfBackStagePasses(Item item)
            {
            }
            public void DecreaseQualityIfNotBackStagePasses(Item item)
            {
                    item.Sulfuras.DecreaseQualityIfNotSulfuras(item);
            }
        }

        private const string Aged_Brie = "Aged Brie";
        private const string Sulfuras_Hand_Of_Ragnaros = "Sulfuras, Hand of Ragnaros";
        private const string Backstage_Passes = "Backstage passes to a TAFKAL80ETC concert";
        private const int Max_Quality = 50;
        private const int Reaching_Expiry_Date = 11;
        private const int Close_To_Expiry = 6;
        private string _name;
        public string Name { get {
                return _name;
            } set {
                _name = value;
                AgedBrie = this._name.Equals(Aged_Brie) ? new IsAgedBrie() : new NotAgedBrie();
                Sulfuras = this._name.Equals(Sulfuras_Hand_Of_Ragnaros) ? new IsSulfuras() : new NotSulfuras();
                BackStagePasses = this._name.Equals(Backstage_Passes) ? new IsBackStagePasses() : new NotBackStagePasses();
            } }
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
            //Could do a type check
            if (_name != Aged_Brie && _name != Backstage_Passes)
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
