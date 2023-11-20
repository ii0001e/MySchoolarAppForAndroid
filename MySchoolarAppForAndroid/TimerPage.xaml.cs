using System;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MySchoolarAppForAndroid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimerPage : ContentPage
    {
        private bool isRunning = false;
        private int i = 0;
        private int a = 0;
        public TimerPage()
        {
            InitializeComponent();
        }

        private async void btn_tagasi_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

            timer_start.Text = "Stop";
            if (!isRunning)
            {
                isRunning = true;
                while (isRunning)
                {
                    time_value.Text = i.ToString();
                    i++;
                    a = 0;
                    for (int j = 0; j <= 10; j++)
                    {
                        time_value.Text = i.ToString() + ":" + a.ToString() + " s.";
                        a = a + 1;
                        await Task.Delay(100);
                    }
                    a = 0;
                }
            }
            else
            {
                isRunning = false;
                i = 0;
                time_value.Text = i.ToString();
                timer_start.Text = "Start";
            }

        }
    }
}