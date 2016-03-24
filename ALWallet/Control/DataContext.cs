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

        public List<Account> getAllAcc() {
            return this._accounts;
        }
    }
}
