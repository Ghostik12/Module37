﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeApp2.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RoomsPage : ContentPage
	{
        public const string ADD_BUTTON_TEXT = "Добавить комнату";

        public RoomsPage()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, EventArgs e)
        {

        }
    }
}