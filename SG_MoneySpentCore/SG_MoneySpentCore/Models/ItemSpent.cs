using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SG_MoneySpentCore.Models
{
    public class ItemSpent
    {
        public string Id { get; set; }
        public double Value { get; set; }
        public string CategoryId { get; set; }
    }
}
