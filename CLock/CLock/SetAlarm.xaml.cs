using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace CLock
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SetAlarm : ContentPage
    {
        public SetAlarm()
        {
            InitializeComponent();
            
        }

        private void setalarmBtn_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Information", "You set an alarm", "Ok");
            Count();
        }
        public void Count()
        {
            Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1), () =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    if (DateTime.Now.ToString("hh:mm") == alarmoff.Time.ToString().Substring(0, alarmoff.Time.ToString().Length - 3))
                    {
                        Console.Beep();
                        DisplayAlert("Information", "Alarm!", "Ok");
                    }
                });
                if (DateTime.Now.ToString("hh:mm") == alarmoff.Time.ToString().Substring(0, alarmoff.Time.ToString().Length - 3))
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