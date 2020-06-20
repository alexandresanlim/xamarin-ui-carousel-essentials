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

        public static void LoadTheme(MaterialColor theme = null)
        {
           
            MaterialColor.SetOnCurrentResourceThemeColor(theme);


            var service = DependencyService.Get<IStatusBar>();
            service?.SetStatusBarColor(ThemeColors.PrimaryDark);
        }

        public static MaterialColor ThemeColors => MaterialColor.GetByCurrentResourceThemeColor();
    }
}
