using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALWallet.Model {
    class Account {

        public string accname {get; set;}
        public List<Double> balance { get; set; }
        public List<TransactionMod> transactons { get; set; }
        public List<DeptMod> depts { get; set; }
        public List<LendMod> lends { get; set; }
    }
}
