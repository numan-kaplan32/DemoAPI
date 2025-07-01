using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Develop.Core.CoreEntityFolder;

namespace Develop.Data.Tables
{
    public class Product : CoreEntity
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }

    }
}
