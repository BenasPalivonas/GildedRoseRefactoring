using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Attributes
{
    public class ItemType : Attribute
    {
        public string Type { get; }
        public ItemType(string type)
        {
            Type = type;
        }
    }
}
