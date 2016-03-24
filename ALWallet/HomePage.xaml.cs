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

        List<Account> accounts;
        public HomePage() {
            this.InitializeComponent();

            // 1 - Check if any account exist
            DataContext dc = new DataContext();
            accounts = dc.getAllAcc();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e) {

            //TextBlock tbAccount;
            //TextBlock tbBalance;
            //StackPanel spAccList;
            //if (accounts != null) {
            //    foreach(var acc in accounts) {
            //        string accName = acc.accname;
            //        double bal = acc.balance[1];
            //        tbAccount = new TextBlock();
            //        tbBalance = new TextBlock();

            //        tbAccount.Width = 200;
            //        tbBalance.Width = 100;

            //        tbAccount.Text = accName;
            //        tbBalance.Text = "Bal: " + String.Format("{0:c}",bal);

            //        spAccList = new StackPanel();
            //        spAccList.Orientation = Orientation.Horizontal;
            //        spAccList.Children.Add(tbAccount);
            //        spAccList.Children.Add(tbBalance);

            //        spAccListContainer.Children.Add(spAccList);
            //    }
            //}
        }

        private void BtnNewAcc_Click(object sender, RoutedEventArgs e) {
            throw new NotImplementedException();
        }
    }
}
