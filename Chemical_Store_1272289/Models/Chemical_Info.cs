using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chemical_Store_1272289.Models
{
    public class Chemical_Info
    {
        public int ChemicalId { get; set; }
        public string ChemicalName { get; set; }
        public int Storage_Unit { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
