﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeApp2
{
    public class RgbExtension : IMarkupExtension
    {
        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return Color.FromRgb(Red, Green, Blue);
        }
    }
}
