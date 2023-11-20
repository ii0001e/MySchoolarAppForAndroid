using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MySchoolarAppForAndroid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BoxView_Page : ContentPage
    {
        Label numberI;
        Editor editor;
        int i = 0;

        BoxView boxView;
        public BoxView_Page()
        {
            int r = 0, g = 0, b = 0;



            boxView = new BoxView
            {
                Color = Color.FromRgb(r, g, b),
                BindingContext = "Click",
                CornerRadius = 10,
                WidthRequest = 200,
                HeightRequest = 400,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            Button back = new Button
            {
                Text = "To Start Page",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Start,
            };

            back.Clicked += Back_Clicked;

            Button restart = new Button
            {
                Text = "Restart",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Start,
            };

            restart.Clicked += Restart_Clicked;

            TapGestureRecognizer tap = new TapGestureRecognizer();

            tap.Tapped += Tap_Tapped;

            boxView.GestureRecognizers.Add(tap);

            numberI = new Label
            {
                Text = "Pealkiri",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                TextColor = Color.DarkOrange,
                BackgroundColor = Color.Brown,
                FontSize = 35
            };


            StackLayout st = new StackLayout
            {
                Children = { numberI, back, restart, boxView },

            };
            Content = st;
        }


        private void Restart_Clicked(object sender, EventArgs e)
        {
            boxView.Color = Color.FromRgb(0, 0, 0);
            boxView.BindingContext = "Click";
            boxView.CornerRadius = 10;
            boxView.WidthRequest = 200;
            boxView.TranslationX = 0;
            boxView.TranslationY = 0;
            boxView.HeightRequest = 400;
            boxView.HorizontalOptions = LayoutOptions.Center;
            boxView.VerticalOptions = LayoutOptions.CenterAndExpand;
            i = 0;
            numberI.Text = i.ToString();
        }

        private async void Back_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        Random rnd;
        private void Tap_Tapped(object sender, EventArgs e)
        {

            rnd = new Random();
            boxView.Color = Color.FromRgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
            boxView.WidthRequest = rnd.Next(50, 250);
            boxView.HeightRequest = rnd.Next(50, 500);

            boxView.TranslationX = rnd.Next((int)(-Xamarin.Forms.Application.Current.MainPage.Width + boxView.WidthRequest), (int)(Xamarin.Forms.Application.Current.MainPage.Width - boxView.WidthRequest));
            boxView.TranslationY = rnd.Next((int)(-Xamarin.Forms.Application.Current.MainPage.Height + boxView.HeightRequest), (int)(Xamarin.Forms.Application.Current.MainPage.Height - boxView.HeightRequest));

            i++; // Увеличиваем i при каждом нажатии
            numberI.Text = i.ToString();

        }
    }
}