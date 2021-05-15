using csharpcore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Services.Items
{
    public interface IItems
    {
        public List<Item> GetItems();
    }
}
