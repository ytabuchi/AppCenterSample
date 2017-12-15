using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;


namespace XFMyFirstApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new XFMyFirstApp.MainPage();
        }

        protected override void OnStart()
        {
            if (Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.UWP)
                AppCenter.Start(Secrets.Key, typeof(Analytics));
            else
                AppCenter.Start(Secrets.Key, typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
