using App.CardTools.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App.CardTools
{
    public partial class App
    {
        public static MenuStyle Style => new MenuStyle
        {
            PrimaryColor = (Color)App.Current.Resources["primaryColor"],
            SecondaryColor = (Color)App.Current.Resources["secondaryColor"],
            PrimaryDarkColor = (Color)App.Current.Resources["primaryDarkColor"],
            SecondaryDarkColor = (Color)App.Current.Resources["secondaryDarkColor"],
            PrimaryTextColor = (Color)App.Current.Resources["primaryTextColor"],
            SecondaryTextColor = (Color)App.Current.Resources["secondaryTextColor"],
        };
    }
}
