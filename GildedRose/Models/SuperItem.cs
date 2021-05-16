using csharpcore;
using GildedRose.Models.ConjuredItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Models
{
    // I added SuperItem class, because the refactoring guide said you can't change Item class
    public class SuperItem : Item
    {
        private const string Aged_Brie = "Aged Brie";
        private const string Sulfuras_Hand_Of_Ragnaros = "Sulfuras, Hand of Ragnaros";
        private const string Backstage_Passes = "Backstage passes to a TAFKAL80ETC concert";
        private const int Max_Quality = 50;
        private const int Reaching_Expiry_Date = 11;
        private const int Close_To_Expiry = 6;

        public IAgedBrie AgedBrie;

        public ISulfuras Sulfuras;

        public IBackStagePasses BackStagePasses;

        public IConjuredItem ConjuredItem;

        private string _name;
        public new string Name
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
                ConjuredItem = this._name.Contains("Conjured") ? new IsConjuredItem() : new NotConjuredItem();
            }
        }
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
