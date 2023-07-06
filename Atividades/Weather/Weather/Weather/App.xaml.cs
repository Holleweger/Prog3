using System;
using TinyNavigationHelper.Abstraction;
using Weather.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Weather
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Bootstrapper.Init();
            MainPage = new NavigationPage(new MainView());
            NavigationHelper.Current.SetRootView("MainView", true);


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
