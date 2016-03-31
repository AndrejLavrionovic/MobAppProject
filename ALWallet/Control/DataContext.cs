using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALWallet.Model;
using SQLite.Net;
using System.IO;

namespace ALWallet.Control {
    class DataContext {

        // list of accounts
        private SQLiteConnection conn;
        private SQLiteCommand com;

        public DataContext() {
            string path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "db3.sqlite");
            this.conn = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
        }

        public List<Account> getAllAcc() {

            List<Account> accounts = null;
            try {
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
            catch (SQLiteException) {

                return null;
            }
        }

        public int createNewAccount(Account acc) {

            try {
                int rows = conn.Insert(acc);
                return rows;
            }
            catch (SQLiteException) {
                return 0;
            }
            
        }

        public int createNewCategory(Categories c) {
            int rows = conn.Insert(c);
            return rows;
        }

        public int addNewTransaction(TransactionMod tr) {
            int rows = conn.Insert(tr);
            return rows;
        }

        public Account getAccount(int accountid) {
            Account a = (from acc in conn.Table<Account>()
                         where acc.id == accountid
                         select acc).FirstOrDefault();

            if (a != null)
                return a;
            else
                return null;
        }

        public int updateAccount(Account acc) {
            int rows = conn.Update(acc);

            if (rows == 1)
                return rows;
            else return 0;
        }

        public List<TransactionMod> getAllTransactions(int accountid) {
            List<TransactionMod> trs = (from tr in conn.Table<TransactionMod>()
                                        where tr.accid == accountid
                                        select tr).ToList();

            if (trs.Count() > 0)
                return trs;
            else return null;
        }

        public List<Categories> getAllCategories() {
            List<Categories> cats = (from c in conn.Table<Categories>()
                                     select c).ToList();

            if (cats.Count() > 0)
                return cats;
            else return null;
        }

        public double getAllAmmount(int accountid, DateTime d, string type) {

            int firstday = 1;
            int lastday = System.DateTime.DaysInMonth(d.Year, d.Month);

            DateTime startPeriod = new DateTime(d.Year, d.Month, firstday);
            DateTime endPeriod = new DateTime(d.Year, d.Month, lastday, 23, 59, 59, 999);

            double sum = 0;

            try {

                List<double> trs = (from tr in conn.Table<TransactionMod>()
                                    where tr.accid == accountid
                                    where tr.type == type
                                    where tr.date >= startPeriod
                                    where tr.date <= endPeriod
                                    select tr.ammount).ToList();

                if (trs.Count() > 0) {

                    foreach (double tran in trs) {
                        sum += tran;
                    }
                    return sum;
                }
                else return 0;
            }
            catch (NotSupportedException) {

                return 0;
            }
        }

        public int addDebt(DebtMod dm) {
            int rows = conn.Insert(dm);
            return rows;
        }

        public int addLend(LendMod lm) {
            int rows = conn.Insert(lm);
            return rows;
        }

        public List<LendMod> getLends(int accountid) {
            List<LendMod> lends = (from l in conn.Table<LendMod>()
                                   where l.accid == accountid
                                   select l).ToList();

            if (lends.Count() > 0)
                return lends;
            else return null;
        }

        public List<DebtMod> getDebts(int accountid) {
            List<DebtMod> debts = (from d in conn.Table<DebtMod>()
                                   where d.accid == accountid
                                   select d).ToList();

            if (debts.Count() > 0)
                return debts;
            else return null;
        }

        public double getDebtsSum(int accountid) {

            double sum = 0;

            try {

                List<double> dbs = (from d in conn.Table<DebtMod>()
                                    where d.accid == accountid
                                    select d.ammount).ToList();

                if (dbs.Count() > 0) {

                    foreach (double db in dbs) {
                        sum += db;
                    }
                    return sum;
                }
                else return 0;
            }
            catch (NotSupportedException) {

                return 0;
            }
        }

        public double getLendsSum(int accountid) {

            double sum = 0;

            try {

                List<double> lds = (from l in conn.Table<LendMod>()
                                    where l.accid == accountid
                                    select l.ammount).ToList();

                if (lds.Count() > 0) {

                    foreach (double ld in lds) {
                        sum += ld;
                    }
                    return sum;
                }
                else return 0;
            }
            catch (NotSupportedException) {

                return 0;
            }
        }
    }
}
