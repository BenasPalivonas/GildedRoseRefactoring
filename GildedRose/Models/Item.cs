namespace csharpcore
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public void HandleSellInExpired()
        {
            if (SellIn < 0)
            {
                DecreaseQualityIfNotAgedBrie();
            }
        }

        public void DecreaseQualityIfNotAgedBrie()
        {
            if (Name != "Aged Brie")
            {
                DecreaseQualityIfNotBackStagePasses();
            }
            else
            {
                IncreaseQuality();
            }
        }

        public void UpdateQuality()
        {
            if (Name != "Aged Brie" && Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                DecreaseQualityIfNotSulfuras();
            }
            else
            {
                IncreaseQualityIncludingBackstagePasses();
            }
        }

        public void DecreaseSellInIfNotSulfuras()
        {
            if (Name != "Sulfuras, Hand of Ragnaros")
            {
                SellIn -= 1;
            }
        }

        public void IncreaseIfBackStagePasses()
        {
            if (Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                IncreaseIfReachingExpiry();
                IncreaseIfCloseToExpiry();
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

        public void DecreaseQualityIfNotBackStagePasses()
        {
            if (Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                DecreaseQualityIfNotSulfuras();
            }
            else
            {
                Quality = 0;
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
                IncreaseIfBackStagePasses();
            }
        }

        public void DecreaseQualityIfNotSulfuras()
        {
            if (Quality > 0)
            {
                if (Name != "Sulfuras, Hand of Ragnaros")
                {
                    Quality -= 1;
                }
            }
        }

    }
}
