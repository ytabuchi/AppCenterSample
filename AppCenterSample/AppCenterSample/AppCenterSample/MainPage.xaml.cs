using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppCenterSample
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        async void Button1_Clicked(object sender, System.EventArgs e)
        {
            Analytics.TrackEvent("Navigation", new Dictionary<string, string>{
                {"MainPage", "SecondPage"}
            });
            await Navigation.PushAsync(new SecondPage());
        }

        async void Button2_Clicked(object sender, System.EventArgs e)
        {
            Analytics.TrackEvent("Navigation", new Dictionary<string, string>{
                {"MainPage", "ThirdPage"}
            });
            await Navigation.PushAsync(new ThirdPage());
        }
    }
}
