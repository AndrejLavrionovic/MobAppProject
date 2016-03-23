using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALWallet.Model {
    class TransactionMod {
        public string type { get; set; }
        public string date { get; set; }
        public string category { get; set; }
        public string description { get; set; }
        public double ammount { get; set; }
    }
}
