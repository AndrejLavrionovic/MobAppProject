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

        public List<string> getListOfCategories() {
            List<string> names = new List<string>();
            names.Add("Advertising");
            names.Add("Car");
            names.Add("Contractors");
            names.Add("Education & Traning");
            names.Add("Employee Benefits");
            names.Add("Meals & Entertainment");
            names.Add("Office Expenses");
            names.Add("Personal");
            names.Add("Postage");
            names.Add("Professional Services");
            names.Add("Rent or Lease");
            names.Add("Suplies");
            names.Add("Sport & Tourism");
            names.Add("Travel");
            names.Add("Utilities");
            names.Add("Other Expenses");

            return names;
        }
    }
}
