using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MySchoolarAppForAndroid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Image_Page : ContentPage
    {
        Switch sw;
        Image img;
        public Image_Page()
        {
            img = new Image { Source = "smile.jpg" };

            var tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;
            tap.NumberOfTapsRequired = 2;
            img.GestureRecognizers.Add(tap);
            sw = new Switch
            {
                IsToggled = true,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
            };
            sw.Toggled += Sw_Toggled;
            Content = new StackLayout { Children = { sw, img } };
        }
        int taps = 0;
        private void Tap_Tapped(object sender, EventArgs e)
        {
            taps++;
            Image img = (Image)sender;
            if (taps % 2 == 0)
            {
                img.Source = "smile.jpg";
            }
            else
            {
                img.Source = "SmileImg.jpg";
            }
        }

        private void Sw_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                img.IsVisible = true;

            }
            else
            {
                img.IsVisible = false;
            }
        }
    }
}