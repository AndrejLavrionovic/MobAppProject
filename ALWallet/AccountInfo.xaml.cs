using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ALWallet.Control;
using ALWallet.Model;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ALWallet {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AccountInfo : Page {

        private App myApp;
        private Account a;
        private DataContext dc;

        public AccountInfo() {
            this.InitializeComponent();

            myApp = (Application.Current) as App;
            dc = new DataContext();
            a = dc.getAccount(myApp._accountId);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e) {
            tblAccountName.Text = String.Format("{0}", a.accname);
            tblBalance.Text = String.Format("{0:c}", a.current);
            tblExpenses.Text = String.Format("{0:c}", dc.getAllAmmount(myApp._accountId, DateTime.Now, "w"));
            tblIncome.Text = String.Format("{0:c}", dc.getAllAmmount(myApp._accountId, DateTime.Now, "d"));
            tblDebt.Text = String.Format("{0:c}", dc.getDebtsSum(myApp._accountId));
            tblLend.Text = String.Format("{0:c}", dc.getLendsSum(myApp._accountId));
        }

        private void lbIcons_SelectionChanged(object sender, SelectionChangedEventArgs e) {

            if (lbiBack.IsSelected) {
                myApp._accountId = 0;
                myApp._accountName = "";
                this.Frame.Navigate(typeof(HomePage));
            }
            else if (lbiHome.IsSelected) {
                this.Frame.Navigate(typeof(AccountInfo));
            }
            else if (lbiTransactions.IsSelected) {
                this.Frame.Navigate(typeof(Transactions));
            }
            else if (lbiBorrow.IsSelected) {
                this.Frame.Navigate(typeof(Borrowed));
            }
            else if (lbiLend.IsSelected) {
                this.Frame.Navigate(typeof(Lent));
            }
            else if (lbiSqlite.IsSelected) {
                this.Frame.Navigate(typeof(sqlite));
            }
        }

        private void btnHamburger_Click(object sender, RoutedEventArgs e) {
            splSideMenu.IsPaneOpen = !splSideMenu.IsPaneOpen;
        }

        private void btnDeleteTrans_Click(object sender, RoutedEventArgs e) {

        }
    }
}
