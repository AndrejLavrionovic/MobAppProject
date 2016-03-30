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
    public sealed partial class Borrowed : Page {


        private DataContext dc;
        private App myApp;
        private DebtMod dm;
        public Borrowed() {
            this.InitializeComponent();

            myApp = (Application.Current) as App;
            dc = new DataContext();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e) {
            tblAccountName.Text = myApp._accountName;
        }

        private void btnHamburger_Click(object sender, RoutedEventArgs e) {
            splSideMenu.IsPaneOpen = !splSideMenu.IsPaneOpen;
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
        }

        private void btnBorrow_Click(object sender, RoutedEventArgs e) {


            DateTime d = dpDate.Date.DateTime;
            double a = Convert.ToDouble(tbxAmmount.Text);
            string from = tbxFrom.Text;

            dm = new DebtMod();

            dm.date = d;
            dm.ammount = a;
            dm.from = from;
            dm.accid = myApp._accountId;

            if (dc.addDebt(dm) == 1) {

                dpDate.Date = DateTime.Now;
                tbxAmmount.Text = "";
                tbxFrom.Text = "";

                Account acc = dc.getAccount(myApp._accountId);
                double current = acc.current;
                double newCurrent = current + a;
                acc.current = newCurrent;

                if (dc.updateAccount(acc) == 1) {
                    TextBox tb = new TextBox();
                    tb.Text = "Saved successfully.";
                    spMsg.Children.Add(tb);
                }
            }
        }
    }
}
