using csharpcore;
using GildedRose.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Services.ItemsService
{
    public interface IItemsService
    {
        public List<SuperItem> GetItems();
    }
}
