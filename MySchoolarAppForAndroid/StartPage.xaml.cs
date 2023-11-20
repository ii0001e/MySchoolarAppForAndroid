using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MySchoolarAppForAndroid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            Button Ent_btn = new Button
            {
                Text = "Entry Page",
                BackgroundColor = Color.Azure,
            };


            Button Timer_btn = new Button
            {
                Text = "Timer Page",
                BackgroundColor = Color.Azure,
            };

            Button Clicker_btn = new Button
            {
                Text = "Clicker",
                BackgroundColor = Color.DimGray,
            };

            Button Grid_btn = new Button
            {
                Text = "Grid Page",
                BackgroundColor = Color.Azure,
            };

            StackLayout st = new StackLayout
            {
                Children = { Ent_btn, Timer_btn, Clicker_btn, Grid_btn },
                BackgroundColor = Color.Beige,

            };

            Content = st;
            Ent_btn.Clicked += Ent_btn_Clicked;
            Timer_btn.Clicked += Timer_btn_Clicked;
            Clicker_btn.Clicked += Clicker_btn_Clicked;
            Grid_btn.Clicked += Grid_btn_Clicked;
        }

        private async void Clicker_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BoxView_Page());
        }

        private async void Grid_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FrameGridPage());
        }

        private async void Timer_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TimerPage());
        }

        private async void Ent_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EntryPage());
        }

    }
}