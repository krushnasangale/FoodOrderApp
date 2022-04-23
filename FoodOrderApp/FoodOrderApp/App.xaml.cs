using FoodOrderApp.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodOrderApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new SettingsPage());

            string uname = Preferences.Get("Username", string.Empty);
            if (string.IsNullOrEmpty(uname))
            {
                MainPage = new NavigationPage(new LoginView());
            }
            else
            {
                MainPage = new NavigationPage(new ProductsView());
            }
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
    }
}
