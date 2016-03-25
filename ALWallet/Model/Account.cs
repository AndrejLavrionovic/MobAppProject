using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALWallet.Model {
    public class Account {

        public string accname {get; set;}
        public List<double> balance { get; set; }
        public List<TransactionMod> transactons { get; set; }
        public List<DebtMod> debts { get; set; }
        public List<LendMod> lends { get; set; }

        // constructor
        public Account() { }

        public Account(string accname, List<double> balance, List<TransactionMod> transactions, List<DebtMod> debts, List<LendMod> lends) {
            this.accname = accname;
            this.balance = balance;
            this.transactons = transactons;
            this.debts = debts;
            this.lends = lends;
        }
    }
}
