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
using ALWallet.Model;
using ALWallet.Control;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ALWallet {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Transactions : Page {

        private List<Categories> categories;
        private DataContext dc;
        private TransactionMod tr;

        private App myApp;
        public Transactions() {
            this.InitializeComponent();

            myApp = (Application.Current) as App;
            dc = new DataContext();

            categories = dc.getAllCategories();
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

        private void btnW_Click(object sender, RoutedEventArgs e) {

            // Instance of transactionmod
            tr = new TransactionMod();

            string t = "w";
            DateTime d = dpDate.Date.DateTime;
            double a = Convert.ToDouble(tbxAmmount.Text);
            int aid = myApp._accountId;

            // setting up fields
            tr.type = t;
            tr.date = d;
            tr.ammount = a;
            tr.accid = aid;
            if (cbCategory.SelectedIndex != -1) {
                var item = (Categories)cbCategory.SelectedItem;
                tr.categoryid = item.id;
            }
            if (tbxDescription.Text != null) {
                tr.description = tbxDescription.Text;
            }

            if (dc.addNewTransaction(tr) == 1) {

                dpDate.Date = DateTime.Now;
                tbxAmmount.Text = "";
                cbCategory.SelectedIndex = -1;
                tbxDescription.Text = "";

                Account acc = dc.getAccount(myApp._accountId);
                double current = acc.current;
                double newCurrent = current - a;
                acc.current = newCurrent;

                if (dc.updateAccount(acc) == 1) {
                    TextBox tb = new TextBox();
                    tb.Text = "New transaction was saved.";
                    spMsg.Children.Add(tb);
                }
            }

        }

        private void btnD_Click(object sender, RoutedEventArgs e) {


            // Instance of transactionmod
            tr = new TransactionMod();

            string t = "d";
            DateTime d = dpDate.Date.DateTime;
            double a = Convert.ToDouble(tbxAmmount.Text);
            int aid = myApp._accountId;

            // setting up fields
            tr.type = t;
            tr.date = d;
            tr.ammount = a;
            tr.accid = aid;
            if (cbCategory.SelectedIndex != -1) {
                var item = (Categories)cbCategory.SelectedItem;
                tr.categoryid = item.id;
            }
            if (tbxDescription.Text != null) {
                tr.description = tbxDescription.Text;
            }

            if (dc.addNewTransaction(tr) == 1) {
                dpDate.Date = DateTime.Now;
                tbxAmmount.Text = "";
                cbCategory.SelectedIndex = -1;
                tbxDescription.Text = "";

                Account acc = dc.getAccount(myApp._accountId);
                double current = acc.current;
                double newCurrent = current + a;
                acc.current = newCurrent;

                if (dc.updateAccount(acc) == 1) {
                    TextBox tb = new TextBox();
                    tb.Text = "New transaction was saved.";
                    spMsg.Children.Add(tb);
                }
            }
        }
    }
}
