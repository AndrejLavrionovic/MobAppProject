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
using SQLite.Net;
using ALWallet.Control;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ALWallet {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class sqlite : Page {

        // list of accounts
        private SQLiteConnection conn;
        private SQLiteCommand com;
        private DataContext dc;
        private List<Categories> categories;
        private App myApp;

        public sqlite() {
            this.InitializeComponent();

            myApp = (Application.Current) as App;

            string path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "db1.sqlite");
            this.conn = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);

            dc = new DataContext();
            categories = dc.getAllCategories();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e) {

            spCatList.Children.Clear();

            List<string> cats = (from c in conn.Table<Categories>()
                                 select c.name).ToList();

            if (cats.Count > 0) {
                TextBlock t;
                foreach (string cat in cats) {
                    t = new TextBlock();
                    t.Text = cat;

                    spCatList.Children.Add(t);
                }
            }
            else {
                TextBlock t = new TextBlock();
                t.Text = "Table Categories is empty.";
                spCatList.Children.Add(t);
            }
        }

        private void btnCat_Click(object sender, RoutedEventArgs e) {

            // adding new cat
            Categories category = new Categories(tbxCat.Text);
            if (dc.createNewCategory(category) == 1) {

                spCatList.Children.Clear();

                List<string> cats = (from c in conn.Table<Categories>()
                                     select c.name).ToList();

                if (cats.Count > 0) {
                    TextBlock t;
                    foreach (string cat in cats) {
                        t = new TextBlock();
                        t.Text = cat;

                        spCatList.Children.Add(t);
                    }
                }
            }
            else {
                TextBlock t = new TextBlock();
                t.Text = "Table Categories is empty.";
                spCatList.Children.Add(t);
            }

            tbxCat.Text = "";
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e) {

            var item = (Categories)cbUpdateFrom.SelectedItem;
            string catName = item.name;
            int catId = item.id;

            Categories c = new Categories(tbxUpdateTo.Text);
            c.id = catId;

            if (c.id == catId)
                conn.Update(c);

            tbxUpdateTo.Text = "";
            cbUpdateFrom.SelectedIndex = -1;

        }


        private void lbIcons_SelectionChanged(object sender, SelectionChangedEventArgs e) {

            if (lbiBack.IsSelected) {
                myApp._accountId = 0;
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
    }
}
