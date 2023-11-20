using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MySchoolarAppForAndroid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrameGridPage : ContentPage
    {
        Grid grid;
        Random random;
        Button[,] buttons;
        Label label;
        Dictionary<Button, Color> originalButtonColors;
        Dictionary<Button, bool> buttonColorsBool;

        public FrameGridPage()
        {
            random = new Random();
            grid = new Grid { };
            buttons = new Button[3, 2];
            originalButtonColors = new Dictionary<Button, Color>();
            buttonColorsBool = new Dictionary<Button, bool>();

            for (int row = 0; row < 3; row++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(row + 1, GridUnitType.Star) });

                for (int col = 0; col < 2; col++)
                {
                    Button button = new Button
                    {
                        Text = row.ToString() + col.ToString(),
                        BorderColor = Color.White,
                        CornerRadius = 10,
                        BackgroundColor = Color.FromRgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255))
                    };

                    button.Clicked += Button_Clicked;

                    // Сохраняем изначальный цвет кнопки
                    originalButtonColors.Add(button, button.BackgroundColor);
                    buttonColorsBool.Add(button, false);

                    buttons[row, col] = button;

                    grid.Children.Add(button, col, row);
                }
            }

            Button b = new Button
            {
                Text = "To Start Page",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };
            b.Clicked += B_Clicked;
            grid.Children.Add(b, 0, 4);
            Grid.SetColumnSpan(b, 2);

            label = new Label { Text = "Button nr. :   ", BackgroundColor = Color.RosyBrown, TextColor = Color.Black, FontSize = 24 };
            grid.Children.Add(label, 0, 3);
            Grid.SetColumnSpan(label, 2);

            Content = grid;
        }


        private void Button_Clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (buttonColorBool(button))
            {
                button.BackgroundColor = Color.FromRgb(random.Next(1, 255), random.Next(1, 255), random.Next(1, 255));

                label.Text = "Button nr. :   " + button.Text;
            }
            else
            {
                button.BackgroundColor = originalButtonColors[button];
            }
        }


        private bool buttonColorBool(Button button)
        {
            return button.BackgroundColor == originalButtonColors[button];
        }


        private async void B_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}

