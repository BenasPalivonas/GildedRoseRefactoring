using csharpcore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Models.ConjuredItem
{
    public class NotConjuredItem : IConjuredItem
    {
        public void DegradeQuality(Item item)
        {
        }
    }
}
