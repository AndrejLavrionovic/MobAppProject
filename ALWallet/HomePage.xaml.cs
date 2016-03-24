using ALWallet.Control;
using ALWallet.Model;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ALWallet {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page {
        public HomePage() {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e) {
            DataContext dc = new DataContext();

            // 1 - Check if any account exist
            List<Account> accounts = dc.getAccList();

            TextBlock tb = new TextBlock();
            if (accounts != null) {
                Account a = accounts[0];
                TransactionMod trs = a.transactons[0];

                tb.Text = trs.date.ToString("dd/MM/yyyy");
            }
            else {
                tb.Text = "Create Account.";
            }
            spList.Children.Add(tb);
        }

        private void BtnNewAcc_Click(object sender, RoutedEventArgs e) {
            throw new NotImplementedException();
        }
    }
}
