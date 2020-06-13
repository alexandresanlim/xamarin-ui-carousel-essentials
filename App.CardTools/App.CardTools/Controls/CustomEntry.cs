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
            TextColor = App.Style.SecondaryTextColor;
            ClearButtonVisibility = ClearButtonVisibility.WhileEditing;
            BackgroundColor = App.Style.PrimaryColor;
            //PlaceholderColor = App.Style.SecondaryTextColor;

        }
    }
}
