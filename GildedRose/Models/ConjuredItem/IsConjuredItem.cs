using csharpcore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Models.ConjuredItem
{
    public class IsConjuredItem : IConjuredItem
    {
        public void DegradeQuality(SuperItem item)
        {
            item.Quality -= 1;
        }
    }
}
