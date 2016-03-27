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
using SQLite.Net;
using System.IO;

namespace ALWallet.Control {
    class DataContext {

        // list of accounts
        private SQLiteConnection conn;

        public DataContext() {
            string path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "alwallet.sqlite");
            this.conn = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
        }

        public List<Account> getAllAcc() {

            List<Account> accounts = null;

            var query = conn.Table<Account>();
            int c = query.Count();

            if (query.Count() > 0) {

                accounts = new List<Account>();
                foreach (var message in query) {
                    accounts.Add((Account)message);
                }
                return accounts;
            }
            else return null;
        }

        public int createNewAccount(Account acc) {
            int rows = conn.Insert(acc);
            return rows;
        }
    }
}
