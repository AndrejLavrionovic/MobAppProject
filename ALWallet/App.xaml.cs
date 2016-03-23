﻿using ALWallet.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace ALWallet
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {

        public List<Account> _getListOfAcc;
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            Microsoft.ApplicationInsights.WindowsAppInitializer.InitializeAsync(
                Microsoft.ApplicationInsights.WindowsCollectors.Metadata |
                Microsoft.ApplicationInsights.WindowsCollectors.Session);
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {

#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
            {
                this.DebugSettings.EnableFrameRateCounter = true;
            }
#endif

            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                if(_getListOfAcc == null) {
                    populateAccount();
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                rootFrame.Navigate(typeof(MainPage), e.Arguments);
            }
            // Ensure the current window is active
            Window.Current.Activate();

        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }

        // retrieve data and populate list
        private async void populateAccount() {
            Account acc;
            TransactionMod trMod;
            DebtMod dMod;
            LendMod lMod;
            _getListOfAcc = new List<Account>();


            var jsonFile = await Package.Current.InstalledLocation.GetFileAsync("Data\\alwallet.txt");
            var fileContent = await FileIO.ReadTextAsync(jsonFile); // json string
            var jsonArr = JsonArray.Parse(fileContent); // get json Array from string

            // getting data
            foreach (var item in jsonArr) {
                acc = new Account();

                // account
                var account = item.GetObject()["account"].GetObject();

                acc.accname = account["accountname"].ToString();

                // balance
                var bal = account["balance"].GetObject();

                List<double> balanceList = new List<double>();
                balanceList.Add(Convert.ToDouble(bal["start"].ToString()));
                balanceList.Add(Convert.ToDouble(bal["current"].ToString()));
                balanceList.Add(Convert.ToDouble(bal["outstanding"].ToString()));
                acc.balance = balanceList;

                // transactions
                var trs = account["transactions"].GetArray();
                List<TransactionMod> trList = new List<TransactionMod>();

                foreach (var o in trs) {
                    trMod = new TransactionMod();
                    var tr = o.GetObject();
                    trMod.type = tr["type"].ToString();
                    trMod.date = convertIntoDate(tr["date"].ToString());
                    trMod.category = tr["category"].ToString();
                    trMod.description = tr["description"].ToString();
                    trMod.ammount = Convert.ToDouble(tr["ammount"].ToString());
                    trList.Add(trMod);
                }

                // debt
                var ds = account["debt"].GetArray();
                List<DebtMod> debts = new List<DebtMod>();

                foreach (var o in ds) {
                    dMod = new DebtMod();

                    var d = o.GetObject();
                    dMod.from = d["from"].ToString();
                    dMod.date = convertIntoDate(d["date"].ToString());
                    dMod.ammount = Convert.ToDouble(d["ammount"].ToString());

                    debts.Add(dMod);
                }

                // lend
                var ls = account["lend"].GetArray();
                List<LendMod> lends = new List<LendMod>();

                foreach (var o in ls) {
                    lMod = new LendMod();

                    var l = o.GetObject();
                    lMod.to = l["to"].ToString();
                    lMod.date = convertIntoDate(l["date"].ToString());
                    lMod.ammount = Convert.ToDouble(l["ammount"].ToString());

                    lends.Add(lMod);
                }

                acc.transactons = trList;
                acc.debts = debts;
                acc.lends = lends;

                this._getListOfAcc.Add(acc);
            }
        }

        private DateTime convertIntoDate(string date) {

            DateTime d;

            if (date.Contains('\"')) {
                string trimmed = date.Trim('\"');
                d = Convert.ToDateTime(trimmed);
            }
            else {
                d = Convert.ToDateTime(date);
            }

            return d;
        }
    }
}
