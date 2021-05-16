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

        private string _name;
        public string Name { get {
                return _name;
            } set {
                _name = value;
                AgedBrie = this._name.Equals("Aged Brie") ? new IsAgedBrie() : new NotAgedBrie();
                Sulfuras = this._name.Equals("Sulfuras, Hand of Ragnaros") ? new IsSulfuras() : new NotSulfuras();
                BackStagePasses = this._name.Equals("Backstage passes to a TAFKAL80ETC concert") ? new IsBackStagePasses() : new NotBackStagePasses();
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
            if (_name != "Aged Brie" && _name != "Backstage passes to a TAFKAL80ETC concert")
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
            if (SellIn < 6)
            {
                IncreaseQuality();
            }
        }

        public void IncreaseIfReachingExpiry()
        {
            if (SellIn < 11)
            {
                IncreaseQuality();
            }
        }

        public void IncreaseQuality()
        {
            if (Quality < 50)
            {
                Quality += 1;
            }
        }

        public void IncreaseQualityIncludingBackstagePasses()
        {
            if (Quality < 50)
            {
                Quality += 1;
               BackStagePasses.IncreaseIfBackStagePasses(this);
            }
        }
    }
}
