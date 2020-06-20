using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App.CardTools.Controls
{
    public class CustomEntry : Entry
    {
        public CustomEntry()
        {
            //BackgroundColor = Color.Red;
            TextColor = App.ThemeColors.TextOnPrimary;
            ClearButtonVisibility = ClearButtonVisibility.WhileEditing;
            BackgroundColor = App.ThemeColors.Primary;
            //PlaceholderColor = App.Style.SecondaryTextColor;

        }
    }
}
