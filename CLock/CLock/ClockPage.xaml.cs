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
    public partial class ClockPage : ContentPage
    {
        public ClockPage()
        {
            InitializeComponent();
            Datasub.Text = DateTime.Now.ToString("dd MMM yyyy");
            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
            Device.BeginInvokeOnMainThread(() =>
                {
                    Timesub.Text = DateTime.Now.ToString("hh : mm : ss");

                });
            return true;
            });
        }
    }
}