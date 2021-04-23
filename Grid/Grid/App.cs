using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Grid483W.Data;
using Grid483W.Models;

namespace Grid483W
{
    public partial class App : Application
    {
        private static KeyDatabaseController keyDatabase;

        public App()
        {

            MainPage = new NavigationPage(new MainGrid(4, 3));
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        public static KeyDatabaseController KeyDatabase
        {
            get
            {
                if (keyDatabase == null)
                {
                    keyDatabase = new KeyDatabaseController();
                }

                return keyDatabase;
            }
        }
    }
}
