using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace ALWallet.Model {
    public class DebtMod {

        [PrimaryKey, NotNull, AutoIncrement]
        public int id { get; set; }
        [NotNull]
        public string from { get; set; }
        [NotNull]
        public DateTime date { get; set; }
        [NotNull]
        public double ammount { get; set; }
        [NotNull]
        public int accid { get; set; }

        //constructors
        public DebtMod() { }

        public DebtMod(string from, DateTime date, double ammount) {
            this.from = from;
            this.date = date;
            this.ammount = ammount;
        }
    }
}
