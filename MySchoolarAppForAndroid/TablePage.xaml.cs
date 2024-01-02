using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MySchoolarAppForAndroid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TablePage : ContentPage
    {
        TableView tableView;
        SwitchCell switchCell;
        ImageCell imageCell;
        TableSection photoSection;

        public TablePage()
        {
            photoSection = new TableSection();
            switchCell = new SwitchCell { Text = "More..." };
            switchCell.OnChanged += SwitchCell_OnChanged;
            imageCell = new ImageCell { Text = "Photo:", ImageSource="Capricorn.jpg", Detail = "6apaH" };

            tableView = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot("Andmed: ")
                {
                    new TableSection("MainInfo: ")
                    {
                        new EntryCell
                        {
                            Label = "Name: ",
                            Placeholder = "Enter name",
                            Keyboard = Keyboard.Default,
                        }
                    },
                    new TableSection("ContactInfo: ")
                    {
                        new EntryCell
                        {
                            Label = "Phone: ",
                            Placeholder = "Enter number",
                            Keyboard = Keyboard.Telephone,
                        },
                        new EntryCell
                        {
                            Label = "E-mail: ",
                            Placeholder = "Enter yours e-mail",
                            Keyboard = Keyboard.Email,
                        },
                        switchCell
                    },
                    photoSection
                }
            };
            Content = tableView;
        }

        private void SwitchCell_OnChanged(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                photoSection.Title = "Photo: ";
                photoSection.Add(imageCell);
                switchCell.Text = "Peida";
            }
            else
            {
                photoSection.Title = "";
                photoSection.Remove(imageCell);
                switchCell.Text = "More...";
            }
        }
    }
}