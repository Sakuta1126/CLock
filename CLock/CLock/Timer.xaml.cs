using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CLock
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Timer : ContentPage
    {
        decimal time, timetoend = 0;
        public Timer()
        {
            InitializeComponent();
        }

        private void timerstart_Clicked(object sender, EventArgs e)
        {
        
            Count();
        }
        public void Count()
        {
            if (timeroff.Text == "")
            {
                DisplayAlert("Information", "Insert value", "OK");
            }
            else
            {
                time = int.Parse(timeroff.Text) * 60;
            }
            Device.StartTimer(new TimeSpan(0, 0, 0, 1), () =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    if (time < timetoend)
                    {
                        Console.Beep();
                        DisplayAlert("Information", "END", "OK");
                    }
                    timertime.Text = Math.Floor(timetoend / 60).ToString() + ":" + timetoend.ToString();
                    timetoend++;
                });
                if (time < timetoend)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            });
        }
    }
}