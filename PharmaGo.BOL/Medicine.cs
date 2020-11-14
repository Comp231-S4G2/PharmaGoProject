using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaGo.BOL
{
    public class Medicine
    {
        public long MedId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
