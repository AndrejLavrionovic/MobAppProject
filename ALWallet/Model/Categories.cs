using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace ALWallet.Model {
    class Categories {

        [PrimaryKey, NotNull, AutoIncrement]
        public int id { get; set; }
        [NotNull]
        public string name { get; set; }

        // constructors
        public Categories() { }
        public Categories(string name) {
            this.name = name;
        }
    }
}
