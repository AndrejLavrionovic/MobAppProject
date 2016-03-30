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
    public sealed partial class Lent : Page {


        private DataContext dc;
        private App myApp;
        private LendMod lm;
        public Lent() {
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

        private void btnLend_Click(object sender, RoutedEventArgs e) {

            if (isValid()) {

                DateTime d = dpDate.Date.DateTime;
                double a = Convert.ToDouble(tbxAmmount.Text);
                string to = tbxTo.Text;

                lm = new LendMod();

                lm.date = d;
                lm.ammount = a;
                lm.to = to;
                lm.accid = myApp._accountId;

                if (dc.addLend(lm) == 1) {

                    dpDate.Date = DateTime.Now;
                    tbxAmmount.Text = "";
                    tbxTo.Text = "";

                    Account acc = dc.getAccount(myApp._accountId);
                    double current = acc.current;
                    double newCurrent = current - a;
                    acc.current = newCurrent;

                    if (dc.updateAccount(acc) == 1) {
                        TextBox tb = new TextBox();
                        tb.Text = "Saved successfully.";
                        spMsg.Children.Add(tb);
                    }
                }
            }
        }

        private bool isValid() {



            // check if spErrors is visible end make is not visible if it is.
            // alse if spErrors has childs then remove all.
            if (spErrors.Visibility == Visibility.Visible) {
                spErrors.Visibility = Visibility.Collapsed;
                spErrors.Children.Clear();
            }

            // validation
            int err = 0;
            bool[] error = { false, false, false };
            double result = 0.00;
            if (!Double.TryParse(tbxAmmount.Text, out result)) {
                err++;
                error[2] = true;
            }
            if (tbxAmmount.Text == "") {
                err++;
                error[0] = true;
            }
            if (tbxTo.Text == "") {
                err++;
                error[1] = true;
            }

            if (err > 0) {
                TextBlock tblErr;

                if (error[0] == true) {
                    tblErr = new TextBlock();
                    tblErr.Text = "Enter ammount.";
                    tblErr.Height = 30;

                    spErrors.Children.Add(tblErr);
                }
                if (error[1] == true) {
                    tblErr = new TextBlock();
                    tblErr.Text = "Who you lent to?";
                    tblErr.Height = 30;

                    spErrors.Children.Add(tblErr);
                }
                if (error[2] == true) {
                    tblErr = new TextBlock();
                    tblErr.Text = "Bad ammount value. Number must be entered.";
                    tblErr.Height = 30;

                    spErrors.Children.Add(tblErr);
                }
                spErrors.Visibility = Visibility.Visible;
                return false;
            }
            else return true;
        }
    }
}
