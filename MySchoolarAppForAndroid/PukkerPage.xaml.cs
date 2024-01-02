using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MySchoolarAppForAndroid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PukkerPage : ContentPage
    {
        Picker Picker;
        WebView webView;
        StackLayout stackLayout;
        Entry entry;
        Button btnHome, btnBack, btnForward;

        string[] lehel = new string[4] { "https://moodle.edu.ee", "https://www.tthk.ee/", "https://tahvel.edu.ee/#/", "https://thk.edupage.org/timetable/view.php?fullscreen=1" };
        int ind = 0;

        public PukkerPage()
        {
            Picker = new Picker
            {
                Title = "Lehed"
            };
            Picker.Items.Add("Moodle");
            Picker.Items.Add("Tthk");
            Picker.Items.Add("Tahvel");
            Picker.Items.Add("Tunniplaan");
            Picker.SelectedIndexChanged += Picker_SelectedIndexChanged;

            entry = new Entry
            {
                Placeholder = "Enter URL",
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            btnHome = new Button
            {
                Text = "Go URL",
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Command = new Command(() => LoadUrl("https://" + entry.Text)),
                FontFamily = "ComicSansMS3.ttf#ComicSansMS3"
            };

            btnBack = new Button
            {
                Text = "Back",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Command = new Command(() => GoToPrevious())
            };

            btnForward = new Button
            {
                Text = "Forward",
                HorizontalOptions = LayoutOptions.EndAndExpand,
                Command = new Command(() => GoToNext())
            };

            webView = new WebView();

            SwipeGestureRecognizer swipe = new SwipeGestureRecognizer();
            swipe.Swiped += Swipe_Swiped;
            swipe.Direction = SwipeDirection.Right;

            var buttonsGrid = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = GridLength.Auto }
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = GridLength.Star },
                    new ColumnDefinition { Width = GridLength.Star },
                    new ColumnDefinition { Width = GridLength.Star }
                }
            };

            buttonsGrid.Children.Add(btnHome, 0, 0);
            buttonsGrid.Children.Add(btnBack, 1, 0);
            buttonsGrid.Children.Add(btnForward, 2, 0);

            stackLayout = new StackLayout { Children = { entry, Picker, buttonsGrid, webView } };
            Content = stackLayout;

            stackLayout.GestureRecognizers.Add(swipe);
        }

        private void Swipe_Swiped(object sender, SwipedEventArgs e)
        {
            if (e.Direction == SwipeDirection.Right)
            {
                GoToPrevious();
            }
            else if (e.Direction == SwipeDirection.Left)
            {
                GoToNext();
            }
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadUrl(lehel[Picker.SelectedIndex]);
        }

        private void LoadUrl(string url)
        {
            if (webView != null)
            {
                stackLayout.Children.Remove(webView);
            }

            webView = new WebView
            {
                Source = new UrlWebViewSource { Url = url },
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };

            stackLayout.Children.Add(webView);
        }

        private void GoToPrevious()
        {
            ind = (ind - 1 + lehel.Length) % lehel.Length;
            LoadUrl(lehel[ind]);
        }

        private void GoToNext()
        {
            ind = (ind + 1) % lehel.Length;
            LoadUrl(lehel[ind]);
        }

    }
}
