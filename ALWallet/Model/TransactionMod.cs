using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace ALWallet.Model {
    class TransactionMod {

        [PrimaryKey, NotNull, AutoIncrement]
        public int id { get; set; }
        [NotNull]
        public string type { get; set; }
        [NotNull]
        public DateTime date { get; set; }
        public int categoryid { get; set; }
        public string description { get; set; }
        [NotNull]
        public double ammount { get; set; }
        [NotNull]
        public int accid { get; set; }

        // constructors
        public TransactionMod() { }

        public TransactionMod(string type, DateTime date, double ammount, int accid) {
            this.type = type;
            this.date = date;
            this.ammount = ammount;
            this.accid = accid;
        }

        public TransactionMod(string type, DateTime date, double ammount, int accid, int categoryid) {
            this.type = type;
            this.date = date;
            this.ammount = ammount;
            this.accid = accid;
            this.categoryid = categoryid;
        }

        public TransactionMod(string type, DateTime date, double ammount, int accid, int categoryid, string description) {
            this.type = type;
            this.date = date;
            this.ammount = ammount;
            this.accid = accid;
            this.categoryid = categoryid;
            this.description = description;
        }
    }
}
