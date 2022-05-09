using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk_Peterson
{
    class DeskQuote
    {
        public string CustomerName { get; set; }
        public DateTime QuoteDate { get; set; }
        public decimal QuotePrice { get; set; }
        public Desk Desk { get; set; }
    }
}
