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
        public double start { get; set; }
        public double current { get; set; }
        [NotNull]
        public DateTime created { get; set; }

        // constructor
        public Account() { }

        public Account(string accname, double start) {
            this.accname = accname;
            this.start = start;
        }
        public Account(string accname, double start, double current, DateTime created) {
            this.accname = accname;
            this.start = start;
            this.current = current;
            this.created = created;
        }

        //public Account(int id, string accname, double start, double current, DateTime created) {
        //    this.id = id;
        //    this.accname = accname;
        //    this.start = start;
        //    this.current = current;
        //    this.created = created;
        //}
    }
}
