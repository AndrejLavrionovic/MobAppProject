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
using SQLite.Net;

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
            if(accounts == null) {
                lvAccounts.Visibility = Visibility.Collapsed;
                spLVHeader.Visibility = Visibility.Collapsed;
                spCreateNewAccount.Visibility = Visibility.Visible;
            }
        }

        private void btnNewAcc_Click_1(object sender, RoutedEventArgs e) {

            lvAccounts.Visibility = Visibility.Visible;
            spLVHeader.Visibility = Visibility.Visible;
            spCreateNewAccount.Visibility = Visibility.Collapsed;
            this.Frame.Navigate(typeof(NewAccount));
        }
    }
}
