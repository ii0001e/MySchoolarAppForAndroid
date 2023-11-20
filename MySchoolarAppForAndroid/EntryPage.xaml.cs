using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MySchoolarAppForAndroid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntryPage
    {
        Label label;
        Editor editor;
        int i = 0;

        public EntryPage()
        {
            editor = new Editor
            {
                Placeholder = "Sisesta siia tekst",
                BackgroundColor = Color.AntiqueWhite,
                TextColor = Color.DarkOliveGreen
            };

            editor.TextChanged += Editor_TextChanged;

            label = new Label
            {
                Text = "Pealkiri",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                TextColor = Color.DarkOrange,
                BackgroundColor = Color.Brown
            };

            Button b = new Button
            {
                Text = "To Start Page",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };

            b.Clicked += B_Clicked;

            StackLayout st = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children = { label, editor, b },
                BackgroundColor = Color.BurlyWood
            };

            Content = st;
        }

        private async void B_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void Editor_TextChanged(object sender, TextChangedEventArgs e)
        {

            int countA = e.NewTextValue?.Count(c => c == 'A') ?? 0;
            label.Text = "A: " + countA.ToString();
        }
    }

}
