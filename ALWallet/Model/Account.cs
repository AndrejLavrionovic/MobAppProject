using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALWallet.Model {
    public class Account {

        //private List<Account> balance;

        public string accname {get; set;}
        public List<Double> balance { get; set; }
        public List<TransactionMod> transactons { get; set; }
        public List<DebtMod> debts { get; set; }
        public List<LendMod> lends { get; set; }
    }
}
