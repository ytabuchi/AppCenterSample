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
    public class ThirdPage : ContentPage
    {
        public ThirdPage()
        {
            var label = new Label
            {
                Text = "Third Page",
                HorizontalTextAlignment = TextAlignment.Center,
            };

            var button1 = new Button
            {
                Text = "Crash test!",
            };
            button1.Clicked += Button1_Clicked;

            var button2 = new Button
            {
                Text = "Crash test!",
            };
            button2.Clicked += Button2_Clicked;


            Title = "Third Page";
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Children = {
                    label,
                    button1,
                    button2
                }
            };
        }

        void Button1_Clicked(object sender, EventArgs e) =>
            Crashes.GenerateTestCrash();

        void Button2_Clicked(object sender, EventArgs e)
        {
            throw new SystemException();
        }
    }
}

