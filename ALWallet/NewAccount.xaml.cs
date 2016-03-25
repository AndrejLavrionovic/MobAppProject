using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Media;
using ALWallet.Model;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ALWallet {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NewAccount : Page {
        public NewAccount() {
            this.InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e) {
            if (Frame.CanGoBack)
                Frame.GoBack();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e) {

            if (isValid()) {

                // account name
                string accName = tbxAccount.Text;
                // list of balance
                List<double> balance = new List<double>();
                balance.Add(Convert.ToDouble(tbxBalance.Text));
                balance.Add(Convert.ToDouble(tbxBalance.Text));
                balance.Add(Convert.ToDouble(tbxBalance.Text));

                // list of Transactions, debts and lends = null
                List<TransactionMod> tr = null;
                List<DebtMod> dm = null;
                List<LendMod> lm = null;

                // instnce of Account
                Account account = new Account(accName, balance, tr, dm, lm);

                // include account into global list
                addAccount(account);

                tbxAccount.Text = "";
                tbxBalance.Text = "";

                // Navigate to transactions
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
            int[] error = { 0, 0, 0 };
            double result = 0.00;
            if (!Double.TryParse(tbxBalance.Text, out result)) {
                err++;
                error[2] = 1;
            }
            if (tbxBalance.Text == "") {
                err++;
                error[1] = 1;
            }
            if (tbxAccount.Text == "") {
                err++;
                error[0] = 1;
            }

            if (err > 0) {
                TextBlock tblErr;

                if (error[0] == 1) {
                    tblErr = new TextBlock();
                    tblErr.Text = "Account name must be entered.";
                    tblErr.Height = 30;

                    spErrors.Children.Add(tblErr);
                }
                if (error[1] == 1) {
                    tblErr = new TextBlock();
                    tblErr.Text = "Starting balance must be entered.";
                    tblErr.Height = 30;

                    spErrors.Children.Add(tblErr);
                }
                if (error[2] == 1) {
                    tblErr = new TextBlock();
                    tblErr.Text = "Bad value. Number must be entered into balance field.";
                    tblErr.Height = 30;

                    spErrors.Children.Add(tblErr);
                }
                spErrors.Visibility = Visibility.Visible;
                return false;
            }
            else return true;
        }

        private void addAccount(Account acc) {

            App myApp = (Application.Current) as App;
            myApp._getListOfAcc.Add(acc);
        }
    }
}
