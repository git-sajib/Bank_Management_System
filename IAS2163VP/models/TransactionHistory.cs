using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAS2163VP.models
{
    class TransactionHistory
    {
        public int Id { get; set; }
        public Staff ApprovedBy { get; set; }
        public Account Account { get; set; }
        public DateTime Date { get; set; }
        public int Type { get; set; }
        public int Amount { get; set; }
    }
}
