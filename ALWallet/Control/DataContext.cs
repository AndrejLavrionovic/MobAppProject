using ALWallet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Data.Json;
using Windows.Storage;
using Windows.UI.Xaml;

namespace ALWallet.Control {
    class DataContext {

        // list of accounts
        private List<Account> _accounts;

        public DataContext() {
            App myApp = (Application.Current) as App;
            _accounts = myApp._getListOfAcc;
        }
        
        
        //// retrieve data and populate list
        //private async void populateAccount() {
        //    Account acc;
        //    TransactionMod trMod;
        //    DebtMod dMod;
        //    LendMod lMod;


        //    var jsonFile = await Package.Current.InstalledLocation.GetFileAsync("Data\\alwallet.txt");
        //    var fileContent = await FileIO.ReadTextAsync(jsonFile); // json string
        //    var jsonArr = JsonArray.Parse(fileContent); // get json Array from string

        //    // getting data
        //    foreach(var item in jsonArr) {
        //        acc = new Account();

        //        // account
        //        var account = item.GetObject()["account"].GetObject();

        //        acc.accname = account["accountname"].ToString();

        //        // balance
        //        var bal = account["balance"].GetObject();

        //        List<double> balanceList = new List<double>();
        //        balanceList.Add(Convert.ToDouble(bal["start"].ToString()));
        //        balanceList.Add(Convert.ToDouble(bal["current"].ToString()));
        //        balanceList.Add(Convert.ToDouble(bal["outstanding"].ToString()));
        //        acc.balance = balanceList;

        //        // transactions
        //        var trs = account["transactions"].GetArray();
        //        List<TransactionMod> trList = new List<TransactionMod>();

        //        foreach (var o in trs) {
        //            trMod = new TransactionMod();
        //                var tr = o.GetObject();
        //                trMod.type = tr["type"].ToString();
        //                trMod.date = convertIntoDate(tr["date"].ToString());
        //                trMod.category = tr["category"].ToString();
        //                trMod.description = tr["description"].ToString();
        //                trMod.ammount = Convert.ToDouble(tr["ammount"].ToString());
        //            trList.Add(trMod);
        //        }

        //        // debt
        //        var ds = account["debt"].GetArray();
        //        List<DebtMod> debts = new List<DebtMod>();

        //        foreach (var o in ds) {
        //            dMod = new DebtMod();

        //            var d = o.GetObject();
        //            dMod.from = d["from"].ToString();
        //            dMod.date = convertIntoDate(d["date"].ToString());
        //            dMod.ammount = Convert.ToDouble(d["ammount"].ToString());

        //            debts.Add(dMod);
        //        }

        //        // lend
        //        var ls = account["lend"].GetArray();
        //        List<LendMod> lends = new List<LendMod>();

        //        foreach (var o in ls) {
        //            lMod = new LendMod();

        //            var l = o.GetObject();
        //            lMod.to = l["to"].ToString();
        //            lMod.date = convertIntoDate(l["date"].ToString());
        //            lMod.ammount = Convert.ToDouble(l["ammount"].ToString());

        //            lends.Add(lMod);
        //        }

        //        acc.transactons = trList;
        //        acc.debts = debts;
        //        acc.lends = lends;

        //        //acc.accname = ob["accountname"].ToString();
        //        //JsonObject bal = ob["balance"].GetObject();

        //        this._accounts.Add(acc);
        //    }
        //}

        //private DateTime convertIntoDate(string date) {

        //    DateTime d;

        //    if (date.Contains('\"')) {
        //        string trimmed = date.Trim('\"');
        //        d = Convert.ToDateTime(trimmed);
        //    }
        //    else {
        //        d = Convert.ToDateTime(date);
        //    }

        //    return d;
        //}

        public List<Account> getAccList() {
            //populateAccount();
            return this._accounts;
        }
    }
}
