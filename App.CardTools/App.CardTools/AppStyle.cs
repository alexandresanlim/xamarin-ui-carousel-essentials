using App.CardTools.Models;
using App.CardTools.Models._1___Interface;
using App.CardTools.Models._2___Layout;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App.CardTools
{
    public partial class App
    {

        public static void LoadTheme()
        {
            MaterialColor.SetOnCurrentResourceThemeColor();

            var service = DependencyService.Get<IStatusBar>();
            service?.SetStatusBarColor(ThemeColors.PrimaryDark);
        }

        public static MaterialColor ThemeColors => new MaterialColor
        {
            Primary = (Color)App.Current.Resources["primaryColor"],
            Secondary = (Color)App.Current.Resources["secondaryColor"],
            PrimaryDark = (Color)App.Current.Resources["primaryDarkColor"],
            SecondaryDark = (Color)App.Current.Resources["secondaryDarkColor"],
            TextOnPrimary = (Color)App.Current.Resources["primaryTextColor"],
            TextOnSecondary = (Color)App.Current.Resources["secondaryTextColor"],
        };
    }
}
