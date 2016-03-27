using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace ALWallet.Model {
    public class Account {

        [PrimaryKey, AutoIncrement, NotNull] 
        public int id { get; set; }
        [NotNull]
        public string accname {get; set;}
        [NotNull]
        public int start { get; set; }
        public int current { get; set; }
        [NotNull]
        public DateTime created { get; set; }

        // constructor
        public Account() { }

        public Account(string accname, int start) {
            this.accname = accname;
            this.start = start;
        }
    }
}
