using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MySchoolarAppForAndroid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage1 : ContentPage
    {
        List<ContentPage> pages = new List<ContentPage>() { new EntryPage(), new BoxView_Page(), new TimerPage(), new EntryPage(), new FrameGridPage(), new Image_Page(), new HoroscopeMenu() };
        List<string> tekst = new List<string> { "Ava Entry leht", "Ava BoxView leht", "Ava Timer leht", "Ava StepperSlider leht", "Ava Grid leht", "Ava Image leht", "Ava Horoscope menu" };
        StackLayout st;
        public StartPage1()
        {
            //InitializeComponent ();
            st = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.YellowGreen
            };

            for (int i = 0; i < pages.Count; i++)
            {
                Button button = new Button
                {
                    Text = tekst[i],
                    TabIndex = i,
                    BackgroundColor = Color.Red,
                    TextColor = Color.White,


                };
                st.Children.Add(button);
                button.Clicked += Button_Clicked;

            }
            ScrollView sv = new ScrollView { Content = st };
            Content = sv;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            await Navigation.PushAsync(pages[btn.TabIndex]);
        }
    }
}