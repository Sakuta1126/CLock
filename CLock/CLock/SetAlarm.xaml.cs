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
            List<Alarm> alarms;
     
        public SetAlarm()
        {
            InitializeComponent();
            Update();
            StartAlarmChecking();
           
        }
        public async void Update()
        {
            alarms = await App.Database.ReadAlarms();

          
            foreach (var alarm in alarms)
            {
                DateTime currentTime = DateTime.Now;
                DateTime alarmDateTime = new DateTime(
                    currentTime.Year,
                    currentTime.Month,
                    currentTime.Day,
                    alarm.Time.Hours,
                    alarm.Time.Minutes,
                    0); 

              
                if (alarmDateTime < currentTime)
                {
                  
                    alarmDateTime = alarmDateTime.AddDays(1);
                }

             
                alarm.Time = alarmDateTime - currentTime;
            }

            ListaAlarmow.ItemsSource = alarms;
        }


        private async void setalarmBtn_Clicked(object sender, EventArgs e)
        {
            if (alarmoff.Time != null)
            {
                Alarm alarm = new Alarm { Time = alarmoff.Time };
                await App.Database.AddAlarm(alarm);
                await DisplayAlert("Information", "You set an alarm", "Ok");
            }
            else
            {
                await DisplayAlert("Error", "Please select a valid time for the alarm", "Ok");
            }
        
            Update();
        }
       
        private async void RemoveAlaram_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var alarm = (Alarm)button.BindingContext;
            await App.Database.DeleteAlarm(alarm);
            
            Update();
        }
        private void StartAlarmChecking()
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                foreach (var alarm in alarms)
                {
                    DateTime currentTime = DateTime.Now;
                    DateTime alarmDateTime = new DateTime(
                        currentTime.Year,
                        currentTime.Month,
                        currentTime.Day,
                        alarm.Time.Hours,
                        alarm.Time.Minutes,
                        0); 

                    if (alarmDateTime == currentTime)
                    {
                        Device.BeginInvokeOnMainThread(async () =>
                        {
                            await DisplayAlert("Alarm", "It's time!", "Ok");
                        });
                    }
                }

               
                return true;
            });
        }


    }
}