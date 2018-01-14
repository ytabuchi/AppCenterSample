using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;

namespace AppCenterSample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppCenterSample.MainPage();
        }

        protected override void OnStart()
        {
            if (Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.UWP)
                AppCenter.Start("uwp=2b977979-ebbc-40f8-b6d2-cddb98312ac1;",
                    typeof(Analytics));
            else
                AppCenter.Start("android=a981827b-441f-4ab1-990e-e582d18d60bf;" + "ios=233ad039-4e6d-4baf-8824-3845db2f2907;",
                    typeof(Analytics), typeof(Crashes));
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
