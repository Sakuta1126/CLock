﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CLock
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Navigation : TabbedPage
    {
        public Navigation()
        {
            InitializeComponent();
        }
    }
}