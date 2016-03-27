using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace ALWallet.Model {
    public class LendMod {

        [PrimaryKey, NotNull, AutoIncrement]
        public int id { get; set; }
        [NotNull]
        public string to { get; set; }
        [NotNull]
        public DateTime date { get; set; }
        [NotNull]
        public double ammount { get; set; }
        [NotNull]
        public int accid { get; set; }

        // constructors
        public LendMod() { }

        public LendMod(string to, DateTime date, double ammount) {
            this.to = to;
            this.date = date;
            this.ammount = ammount;
        }
    }
}
